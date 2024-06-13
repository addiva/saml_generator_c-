namespace Luxottica.Global
{
    public static class GlobalProperties
    {
        // set with IDP entity ID || if this changes do update the metadata or the samlResponse will be considered as invalid
        public static string EntityID { get; set; } = "MAX";

        // put url of SP
        public static string Destination { get; set; } = "maxiii";

        // set with SP entity ID
        public static string Audience { get; set; } = "Leonardo-QU";

        // put your website, no need for real endpoints
        public static string SsoLocation { get; set; } = "test.max.xom";
        public static string SloLocation { get; set; } = "test.max.xom";

        // create your own key
        public static string PrivateKeyStr { get; set; } = @"-----BEGIN PRIVATE KEY-----
MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDSKf6u1+xL+/2+
TVsH268yX5xatlO+nvGnkZlPjoVK2loABJbSacy8d2M8e89TwycDv92wVr//lOD+
MOg9G+prm9Lrlj4SQFOTHyR/fJ7kOJ5yIxN6xjRjIAKSikSuIpZnOvOhQf1wO0ni
E0nSVVk170MdA3ijBRaRdB53NeNqSVvoYe6QT9OBQwGeyIEz1cJjIXi5qBcBw/pc
1becHMbS6F4lvqc8PFsFCFlodtdcmA72EZE2abxwveqvCTYXKbaPMqURyKWagx45
NPdTuRrOamDlhV3Ii7jTSTu78qp7Sbbf/qNfjzw3uQ0DcRQ4XrarzE1kkH4vGdIB
Z429UZIfAgMBAAECggEAHgw3B5SDilGa88xniXYVVGRrHGUZEBX1gvnEK6W61Prn
Bz2gurC5vvBq1cj12Yn7WAPklEOy673DdVRUv/fvyjbbLyep9D4SNOSs+TU+Gm8l
6Devn0wbTVjURVNTgnobeuLo1lNzAsrXQ2VylonxWU6+D7XhV51wnpc1i+G+hAF6
fSoDDei0S63+HjRqDtQy4GKPLNApW7WUZlsz/cn8pKp4cEIxWnKe7ZFp0pRRaLZu
n03cQ3F+qfdwlcvKijvqeTjfZpCkZqrju5GGPgw8cTAuakhwZieXW7poT6flAnRB
JUNoJCTODwZgfnr1nQHlFpKu4YUzdAs5rGKb+xtqYQKBgQD8Ox3uT6sxsHzoFJAk
fSarrCVJTXIXYzf0RnrMFKbJ8hAsNBLrlwIgIGyNPdVA3INyl6IdscZc3vblM++O
VLX/URjjQJQyTUkpY94V00W6IvX/6R7Xpi9d7JCBeCE2IReROT9O7vlfL4QP3cfT
ClMuto7VhhYxv8hHYE5sx7zHqQKBgQDVTfSZeOB1w2DoTTmAomeR3Owh43V9Bv9s
+xly5/XI5T142ZxjmVDsedPul2un9S8FdB1/1Ooh5I7VeJONscYK7HuM1FF+abbp
rHyy2UlKHj3NRk70VPW/9CuHxgaMfqmbQVDb6SfO1GTeaiSif7+9Rrfh3rGt8Amj
xoVBlq8IhwKBgA4f6V8tCvMvZO9CJ4hDkeTPMQ9XzOnOXpXJVJsVFPn+GjW/fMfA
nxfZePq32bdWIe5K24M6L1eIDN9s9x9LUx3HFtOzDBl9BnnQ4+DpAeCYkJoSHe4J
mmFyG+2EIqf7VmyFfiwXadOQv5571vLUgy/8fScr6RZEHR0SIZIp5UJxAoGBALqP
fCffOTLGt7N2F50SblN9Tmo1b0TzIeRHmnKNvsL+/Uz9x3K1Xbn2tA4yEc7M+1th
u4taxYzvQp4i36tGmVhkjYsXCE/wVjL60fX7ZcaVvKgVnmjFBkvlW01dPc0T23QX
JImy20ZjLfX6ECCwaxs5BwteozjmgQflUheTm3NxAoGAJmkHnTf/KiviUOQnYEOs
hUMi0dOEVdNW6YpgqbupaKmflHD1GEtbMD2bp0d5+WpzGxQEsrjuHhF7LI4P3XnS
8yBIbxqGXJrn6b5mxRH50j/Go6myM63ZmpeLdL/CByWHjhkRLaEq/ZwdMqlQ6twm
axrNjp66llDQHG8ne3ZrWgU=
-----END PRIVATE KEY-----";

        // create your own certificate
        public static string CertificateStr { get; set; } = @"-----BEGIN CERTIFICATE-----
MIIDwDCCAqgCCQCscwr4QWU2kDANBgkqhkiG9w0BAQsFADCBoTELMAkGA1UEBhMC
SVQxEjAQBgNVBAgMCUxvbWJhcmRpYTEPMA0GA1UEBwwGTWlsYW5vMRIwEAYDVQQK
DAlMdXhvdHRpY2ExFDASBgNVBAsMC0l0IExlb25hcmRvMRIwEAYDVQQDDAlMZW9u
ZGFyZG8xLzAtBgkqhkiG9w0BCQEWIG1hc3NpbWlsaWFuby5xb2thakBsdXhvdHRp
Y2EuY29tMB4XDTI0MDUyMzEyMzMyMVoXDTI1MDUyMzEyMzMyMVowgaExCzAJBgNV
BAYTAklUMRIwEAYDVQQIDAlMb21iYXJkaWExDzANBgNVBAcMBk1pbGFubzESMBAG
A1UECgwJTHV4b3R0aWNhMRQwEgYDVQQLDAtJdCBMZW9uYXJkbzESMBAGA1UEAwwJ
TGVvbmRhcmRvMS8wLQYJKoZIhvcNAQkBFiBtYXNzaW1pbGlhbm8ucW9rYWpAbHV4
b3R0aWNhLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANIp/q7X
7Ev7/b5NWwfbrzJfnFq2U76e8aeRmU+OhUraWgAEltJpzLx3Yzx7z1PDJwO/3bBW
v/+U4P4w6D0b6mub0uuWPhJAU5MfJH98nuQ4nnIjE3rGNGMgApKKRK4ilmc686FB
/XA7SeITSdJVWTXvQx0DeKMFFpF0Hnc142pJW+hh7pBP04FDAZ7IgTPVwmMheLmo
FwHD+lzVt5wcxtLoXiW+pzw8WwUIWWh211yYDvYRkTZpvHC96q8JNhcpto8ypRHI
pZqDHjk091O5Gs5qYOWFXciLuNNJO7vyqntJtt/+o1+PPDe5DQNxFDhetqvMTWSQ
fi8Z0gFnjb1Rkh8CAwEAATANBgkqhkiG9w0BAQsFAAOCAQEAzqCeg7ufizu9MpZe
lIyUF8mGXbbcE+YlEUiqjVLxyE4vEQIqKDcaaflSb82rS9KyDZzPjVUXf7BAPUx4
yLxkcdE16D1QS36ZmjWyA+zRY3pN6VPyROu7mC1IaYcp/jExbQdNOr8I6+8aS3s6
zITtsE6amUsTTAsPwfXDCOLJldC8gHyMvKmzuBKORpZRgWr+8BWVGNLEK8+PTqjA
hPkkuuKOdPLLuCx4foqthnJu97ix76VTqoJoWDjY4/pJz16MRSTuKJeqtFTk/OPs
OZQn7OT2kZHBiyAHE3lIF59i13t5Y1utHLHMey/ZT0iImCHitWxvtBIaQB0++pFz
RsNkfg==
-----END CERTIFICATE-----";
    }
}