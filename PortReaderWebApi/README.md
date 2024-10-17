## Creating the site
1. Create a new IIS site		
2. Binding HTTPS, all unassisgned, port 443													
3. Add a new host entry to C:\Windows\System32\drivers\etc 127.0.0.1 port-reader.com
4. Create a new self signed certificate for port-reader.com

##Self signed certificate

1	. open powershell as admin
$cert = New-SelfSignedCertificate -DnsName "port-reader.com" -CertStoreLocation "cert:\LocalMachine\My" -FriendlyName "port-reader-crt" -NotAfter (Get-Date).AddYears(100)
2	. A new entry is added to IIS -> Server Certificates
3	. It is also added to the Personal folder in the Certificates MMC -> Windows Key + R -> mmc -> File -> Add/Remove Snap-in -> Certificates -> Computer Account -> Local Computer -> Finish -> OK
4	. Paste it to the Trusted Root Certification Authorities -> Certificates
5. Bind the certificate to the site
