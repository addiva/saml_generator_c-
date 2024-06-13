namespace Luxottica.Utils;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
public class PrivateKeyUtils
{
    public static void SignXml(XmlElement elementToSign, RSA privateKey, X509Certificate2 certificate){
        var signedXml = new System.Security.Cryptography.Xml.SignedXml(elementToSign);
        signedXml.SigningKey = privateKey;

        var keyInfo = new System.Security.Cryptography.Xml.KeyInfo();
        keyInfo.AddClause(new System.Security.Cryptography.Xml.KeyInfoX509Data(certificate));
        signedXml.KeyInfo = keyInfo;

        var reference = new System.Security.Cryptography.Xml.Reference();
        reference.Uri = "#" + elementToSign.GetAttribute("ID");

        var env = new System.Security.Cryptography.Xml.XmlDsigEnvelopedSignatureTransform();
        reference.AddTransform(env);
        var c14n = new System.Security.Cryptography.Xml.XmlDsigExcC14NTransform();
        reference.AddTransform(c14n);

        signedXml.AddReference(reference);

        signedXml.ComputeSignature();
        var xmlDigitalSignature = signedXml.GetXml();

        elementToSign.AppendChild(elementToSign.OwnerDocument.ImportNode(xmlDigitalSignature, true));
    }
}