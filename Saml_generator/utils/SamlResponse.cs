using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace Luxottica.Utils
{
    public class SamlResponse
    {
        public static string generateSamlResponse(string userId, Dictionary<string, string> claims)
        {
            string destination = Luxottica.Global.GlobalProperties.Destination;
            string entityID = Luxottica.Global.GlobalProperties.EntityID;
            string audience = Luxottica.Global.GlobalProperties.Audience;
            string certificateStr = Luxottica.Global.GlobalProperties.CertificateStr;
            string privateKeyStr = Luxottica.Global.GlobalProperties.PrivateKeyStr;

            X509Certificate2 certificate = new X509Certificate2(Encoding.UTF8.GetBytes(certificateStr));
            RSA privateKey = RSA.Create();
            privateKey.ImportFromPem(privateKeyStr.ToCharArray());

            DateTime issueInstant = DateTime.UtcNow;
            DateTime notOnOrAfter = issueInstant.AddMinutes(10);
            DateTime notBefore = issueInstant.AddMinutes(-5);

            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(xmlDeclaration);

            XmlElement response = doc.CreateElement("saml2p:Response", "urn:oasis:names:tc:SAML:2.0:protocol");
            response.SetAttribute("Destination", destination);
            response.SetAttribute("ID", "_" + Guid.NewGuid().ToString("N"));
            response.SetAttribute("IssueInstant", issueInstant.ToString("o"));
            response.SetAttribute("Version", "2.0");
            doc.AppendChild(response);

            XmlElement issuer = doc.CreateElement("saml2:Issuer", "urn:oasis:names:tc:SAML:2.0:assertion");
            issuer.InnerText = entityID;
            response.AppendChild(issuer);

            XmlElement status = doc.CreateElement("saml2p:Status", "urn:oasis:names:tc:SAML:2.0:protocol");
            response.AppendChild(status);

            XmlElement statusCode = doc.CreateElement("saml2p:StatusCode", "urn:oasis:names:tc:SAML:2.0:protocol");
            statusCode.SetAttribute("Value", "urn:oasis:names:tc:SAML:2.0:status:Success");
            status.AppendChild(statusCode);

            XmlElement assertion = doc.CreateElement("saml2:Assertion", "urn:oasis:names:tc:SAML:2.0:assertion");
            assertion.SetAttribute("ID", "_" + Guid.NewGuid().ToString("N"));
            assertion.SetAttribute("IssueInstant", issueInstant.ToString("o"));
            assertion.SetAttribute("Version", "2.0");
            response.AppendChild(assertion);

            XmlElement assertionIssuer = doc.CreateElement("saml2:Issuer", "urn:oasis:names:tc:SAML:2.0:assertion");
            assertionIssuer.InnerText = entityID;
            assertion.AppendChild(assertionIssuer);

            XmlElement subject = doc.CreateElement("saml2:Subject", "urn:oasis:names:tc:SAML:2.0:assertion");
            assertion.AppendChild(subject);

            XmlElement nameID = doc.CreateElement("saml2:NameID", "urn:oasis:names:tc:SAML:2.0:assertion");
            nameID.SetAttribute("Format", "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
            nameID.InnerText = userId;
            subject.AppendChild(nameID);

            XmlElement subjectConfirmation = doc.CreateElement("saml2:SubjectConfirmation", "urn:oasis:names:tc:SAML:2.0:assertion");
            subjectConfirmation.SetAttribute("Method", "urn:oasis:names:tc:SAML:2.0:cm:bearer");
            subject.AppendChild(subjectConfirmation);

            XmlElement subjectConfirmationData = doc.CreateElement("saml2:SubjectConfirmationData", "urn:oasis:names:tc:SAML:2.0:assertion");
            subjectConfirmationData.SetAttribute("NotOnOrAfter", notOnOrAfter.ToString("o"));
            subjectConfirmationData.SetAttribute("Recipient", destination);
            subjectConfirmation.AppendChild(subjectConfirmationData);

            XmlElement conditions = doc.CreateElement("saml2:Conditions", "urn:oasis:names:tc:SAML:2.0:assertion");
            conditions.SetAttribute("NotBefore", notBefore.ToString("o"));
            conditions.SetAttribute("NotOnOrAfter", notOnOrAfter.ToString("o"));
            assertion.AppendChild(conditions);

            XmlElement audienceRestriction = doc.CreateElement("saml2:AudienceRestriction", "urn:oasis:names:tc:SAML:2.0:assertion");
            conditions.AppendChild(audienceRestriction);

            XmlElement audienceElement = doc.CreateElement("saml2:Audience", "urn:oasis:names:tc:SAML:2.0:assertion");
            audienceElement.InnerText = audience;
            audienceRestriction.AppendChild(audienceElement);

            XmlElement authnStatement = doc.CreateElement("saml2:AuthnStatement", "urn:oasis:names:tc:SAML:2.0:assertion");
            authnStatement.SetAttribute("AuthnInstant", issueInstant.ToString("o"));
            authnStatement.SetAttribute("SessionIndex", "_" + Guid.NewGuid().ToString("N"));
            assertion.AppendChild(authnStatement);

            XmlElement authnContext = doc.CreateElement("saml2:AuthnContext", "urn:oasis:names:tc:SAML:2.0:assertion");
            authnStatement.AppendChild(authnContext);

            XmlElement authnContextClassRef = doc.CreateElement("saml2:AuthnContextClassRef", "urn:oasis:names:tc:SAML:2.0:assertion");
            authnContextClassRef.InnerText = "UNSPECIFIED";
            authnContext.AppendChild(authnContextClassRef);

            XmlElement attributeStatement = doc.CreateElement("saml2:AttributeStatement", "urn:oasis:names:tc:SAML:2.0:assertion");
            assertion.AppendChild(attributeStatement);

            foreach (var claim in claims)
            {
                XmlElement attribute = doc.CreateElement("saml2:Attribute", "urn:oasis:names:tc:SAML:2.0:assertion");
                attribute.SetAttribute("Name", claim.Key);
                attributeStatement.AppendChild(attribute);

                XmlElement attributeValue = doc.CreateElement("saml2:AttributeValue", "urn:oasis:names:tc:SAML:2.0:assertion");
                attributeValue.SetAttribute("xsi:type", "xsd:string");
                attributeValue.InnerText = claim.Value;
                attribute.AppendChild(attributeValue);
            }
            PrivateKeyUtils.SignXml(assertion, privateKey, certificate);

            return doc.OuterXml;
        }
    }
}