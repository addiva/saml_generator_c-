using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace Luxottica.Utils
{
    public class Metadata
    {
        public static string generateMetadata()
        {
            string entityID = Luxottica.Global.GlobalProperties.EntityID;
            string ssoLocation = Luxottica.Global.GlobalProperties.SsoLocation;
            string sloLocation = Luxottica.Global.GlobalProperties.SloLocation;
            string privateKeyStr = Luxottica.Global.GlobalProperties.PrivateKeyStr;
            string certificateStr = Luxottica.Global.GlobalProperties.CertificateStr;

            X509Certificate2 certificate = new X509Certificate2(Encoding.UTF8.GetBytes(certificateStr));
            RSA privateKey = RSA.Create();
            privateKey.ImportFromPem(privateKeyStr.ToCharArray());

            XmlDocument doc = new XmlDocument();
            XmlElement entityDescriptor = doc.CreateElement("md:EntityDescriptor", "urn:oasis:names:tc:SAML:2.0:metadata");
            entityDescriptor.SetAttribute("entityID", entityID);
            doc.AppendChild(entityDescriptor);

            XmlElement idpSSODescriptor = doc.CreateElement("md:IDPSSODescriptor", "urn:oasis:names:tc:SAML:2.0:metadata");
            idpSSODescriptor.SetAttribute("protocolSupportEnumeration", "urn:oasis:names:tc:SAML:2.0:protocol");
            entityDescriptor.AppendChild(idpSSODescriptor);

            XmlElement keyDescriptor = doc.CreateElement("md:KeyDescriptor", "urn:oasis:names:tc:SAML:2.0:metadata");
            keyDescriptor.SetAttribute("use", "signing");
            idpSSODescriptor.AppendChild(keyDescriptor);

            XmlElement keyInfo = doc.CreateElement("ds:KeyInfo", "http://www.w3.org/2000/09/xmldsig#");
            keyDescriptor.AppendChild(keyInfo);

            XmlElement x509Data = doc.CreateElement("ds:X509Data", "http://www.w3.org/2000/09/xmldsig#");
            keyInfo.AppendChild(x509Data);

            XmlElement x509Certificate = doc.CreateElement("ds:X509Certificate", "http://www.w3.org/2000/09/xmldsig#");
            x509Certificate.InnerText = Convert.ToBase64String(certificate.RawData);
            x509Data.AppendChild(x509Certificate);

            XmlElement singleLogoutServiceRedirect = doc.CreateElement("md:SingleLogoutService", "urn:oasis:names:tc:SAML:2.0:metadata");
            singleLogoutServiceRedirect.SetAttribute("Binding", "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect");
            singleLogoutServiceRedirect.SetAttribute("Location", sloLocation);
            idpSSODescriptor.AppendChild(singleLogoutServiceRedirect);

            XmlElement singleLogoutServicePost = doc.CreateElement("md:SingleLogoutService", "urn:oasis:names:tc:SAML:2.0:metadata");
            singleLogoutServicePost.SetAttribute("Binding", "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST");
            singleLogoutServicePost.SetAttribute("Location", sloLocation);
            idpSSODescriptor.AppendChild(singleLogoutServicePost);

            XmlElement nameIDFormat = doc.CreateElement("md:NameIDFormat", "urn:oasis:names:tc:SAML:2.0:metadata");
            nameIDFormat.InnerText = "urn:oasis:names:tc:SAML:2.0:nameid-format:transient";
            idpSSODescriptor.AppendChild(nameIDFormat);

            XmlElement singleSignOnServiceRedirect = doc.CreateElement("md:SingleSignOnService", "urn:oasis:names:tc:SAML:2.0:metadata");
            singleSignOnServiceRedirect.SetAttribute("Binding", "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect");
            singleSignOnServiceRedirect.SetAttribute("Location", ssoLocation);
            idpSSODescriptor.AppendChild(singleSignOnServiceRedirect);

            XmlElement singleSignOnServicePost = doc.CreateElement("md:SingleSignOnService", "urn:oasis:names:tc:SAML:2.0:metadata");
            singleSignOnServicePost.SetAttribute("Binding", "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST");
            singleSignOnServicePost.SetAttribute("Location", ssoLocation);
            idpSSODescriptor.AppendChild(singleSignOnServicePost);
            
            return doc.OuterXml;
        }
    }
}
