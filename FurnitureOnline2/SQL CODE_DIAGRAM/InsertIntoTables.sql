INSERT INTO Category (Name, HiddenCategory) VALUES
('Skrivbord', 0),
('Soffgrupp', 0),
('Bokhylla', 0),
('Nattduksbord', 0),
('Taklampa', 0)

INSERT INTO Supplier (Name, City, Adress, ZipCode, HiddenSupplier) VALUES
('IKEA', 'Stockholm', 'Kungsgatan 35', '14124', 0),
('Mio', 'G�teborg', 'Regeringsgatan 12', '12623', 0),
('Norrmalms m�bler', 'Stockholm', 'Nils Holgerssons v. 135', '12492', 0),
('M�belvaruhuset AB', 'Bor�s', 'Brogatan 24','12859', 0),
('Chilli', 'Malm�', 'Karl-Fredriks torg 8', '14338', 0)


INSERT INTO Products (ArticleNumber, Name, Description, CategoryId, CurrentPrice, Moms, SupplierId, ChosenItem, stockUnit, Color, Material, HiddenArticle) VALUES
(120160,'Gisela Skrivbord','Stabilt och tidl�st skrivbord', 1, 3549, 0.8, 9, 0, 40, 'Tr�f�rg','Tr�skiva och metallben', 0),

(120161, 'Function plus skrivbord', 'Function Plus �r en skrivbordsserie best�endes av skrivbord i flera olika f�rger och utf�rande. 

I serien hittar du stilrena och enkla skrivbord med mer eller mindre f�rvaringsm�jligheter. 

Function Plus �r en snygg kombination av vitt och ek g�r det till en l�ttmatchad m�bel eftersom det passar b�de i kombination vita m�bler och med ekm�bler.', 1, 2599, 0.8, 10, 0, 10, 'Vit', 'Tr�', 0),

(120162, 'Vasagle Datorbord L-form', 'Snygg och stabil datorbord smidigt med L form som ger mer arbetsyta.', 1, 2679, 0.8, 11, 0, 25, 'Brunt', 'Tr� och metall', 0),

(120163, 'Hampton Skrivbord', 'Hampton �r ett lantligt skrivbord i klassisk form som lyfter hemmakontoret till en helt ny niv�. 
Hampton ger en rymlig och bra yta till att sitta och arbeta ikapp ost�rt hemma, kanske pyssla med ett kreativt projekt.', 1, 1499, 0.8, 12, 1, 15, 'Vit', 'Massivt ugnsstorkat Mahogny', 0),

(120164, 'Mazel skrivbord', 'Detta skrivbord �r en h�rlig kombination mellan skrivbord och hylla d� benen �r utformade med hyllanpassad f�rvaring', 1, 3780, 0.8, 13, 0, 5, 'Vit/valn�t', 'Tr�', 0),

(120165, 'Andrew soffgrupp', 'Denna soffgrupp blir en hemtrevlig detalj till vardagsrummet. 

Gruppen har stilrena proportioner och ger ett n�tt intryck som full�ndas av fina detaljer i form av stilriktiga hjul och kl�dda knappar p� ryggkuddarna. 

Gruppen best�r av en 2-sits soffa samt f�t�lj och fotpall.', 2, 12489, 0.8, 9, 0, 17, 'Beige', 'Sammet', 0),

(120166, 'Kivik soffgrupp', 'Kryp upp i den sk�na soffan KIVIK. 

Den gener�sa storleken, de l�ga armst�den och memoryskummet som formar sig efter din kropp g�r att du g�rna h�nger, slappar och slumrar i soffan timme efter timme.', 2, 14.995, 0.8, 10, 0, 10, 'Skiftebo/m�rkgr�', 'H�gelastisk polyeter.', 0),

(120167, 'Chesterfield LYX soffgrupp', 'Chesterfield Lyx �r soffgruppen med extravagant framtoning i en klassisk l�cker stil. 

F� ett (n�stan) komplett och stils�kert vardagsrum genom att satsa p� en tidl�s soffgrupp som erbjuder b�de 2-sits, 3-sits och en charmerande f�t�lj i ett och samma paket. 

M�blerna har en stoppad sits som garanterar h�g komfort och den vackert knappbestr�dda designen blir ett vackert inslag i hemmet.', 2, 20.699, 0.8, 11, 0, 8, 'M�rkbl�', 'Sammet', 0),

(120168, 'Howard Classic Soffgrupp', 'Howard Classic soffgrupp med en 3,5-sits och en 3-sits soffa samt en f�t�lj och en fotpall �r en prisv�rd soffgrupp med god komfort och h�g stilk�nsla. 

Med den h�r soffgruppen kan du sk�nka vardagsrummet lite extra elegans. Med stilfulla detaljer och mjukt rundade former �r m�blerna lika snygga som sk�na. 

V�lj mellan olika utf�randen och hitta en howardsoffgrupp som passar hemma hos just dig!', 2, 11.459, 0.8, 12, 0, 5, 'Gr�', 'Tyg', 0),

(120169, 'Billys Bokhylla', 'Flyttbara hyllplan; anpassa avst�nd efter behov.

En enkel enhet kan vara tillr�cklig f�rvaring f�r ett begr�nsat utrymme eller grunden till en st�rre f�rvaring om dina behov f�r�ndras.

Denna m�bel m�ste f�rankras i v�gg med medf�ljande beslag.

Olika v�ggmaterial kr�ver olika typer av f�stbeslag. Anv�nd beslag som passar v�ggarna i ditt hem, s�ljes separat.

2 hyllplan medf�ljer.

Komplettera g�rna med d�rrar i olika f�rger och utf�rande.

Designer: Gillis Lundgren', 3, 399.00, 0.8, 13, 1, 45, 'Vit', 'Tr�', 0),

(120170, 'Loide v�gghylla', 'Loide �r stilren och trendig med fokus p� den skandinaviska stilen. 

Med trivsam formgivning i noggrant utvalda material erbjuder Loide ett brett sortiment stils�kra m�bler.', 3, 895.00, 0.8, 9, 0, 15,

'Beige', 'Ek', 0),

(120171, 'Blobok bokhylla', 'Stilren och funktionell bokhylla f�r f�rvaring', 3, 1279.90, 0.8, 10, 0, 15, 'Vit med inslag av tr�', 'Tr�', 0 ),

(120172, 'Hasselvik hylla', 'Hasslevik hylla med klassisk design och noga utvalda material. 
Den vackra tr�looken �r ett prisv�rt alternativ som kombinerar f�rvaring och design p� ett enast�ende vis.', 3, 899, 0.8, 11, 0, 10, 'Gr�', 'Metall', 0),

(120173, 'Brief bokhylla', 'Industriell, snygg och praktisk golvhylla', 3, 2755, 0.8, 12, 0, 7, 'M�rkbrun/Svart', 'Tr�/Metall', 0),

(120174, 'Vikhammer', 'Stilren och enkel design som passar fint med lite h�gre s�ngar. 

Om en bra bok har h�llit dig vaken kan du l�gga undan den i en av de mjukst�ngande l�dorna � tyst och stilla och utan att v�cka n�gon annan.', 4, 599.50, 0.8, 13, 0, 22, 'Svart', 'Sp�nskiva. Akrylf�rg', 0),

(120175, 'Myrvallen nattduksbord', 'Tidl�s praktikst och fint s�ngbord som monteras p� v�ggen', 4, 5689, 0.8, 9, 0, 14, 'Vit', 'Melamin', 0),

(120176, 'Marco s�ngbord', 'Marco s�ngbord �r ett charmigt nattduksbord som hj�lper dig att h�lla ordning i ditt sovrum. 

Med fyra rymliga l�dor i olika stil har du gott om plats f�r f�rvaring. Med en lekfull stil, olika f�rger och former p� l�dorna drar Marco blickarna till sig och lyfter rummet. 

H�ga, vinklade ben �r en snygg detalj, ger ett luftigt intryck och underl�ttar dessutom st�dningen.', 4, 1495, 0.8, 10, 0, 15, 'Vit/Bl�/Brun', 'Tr�', 0),

(120177,'Colima S�ngbord', 'Tidl�st och praktikst s�ngbord', 4, 1100, 0.8, 11, 0, 8, 'Vit', 'Tr�', 0),

(120178, 'Wilmer s�ngbord', 'Wilmer �r ett s�ngbord/avlastningsbord i rustik utformning med naturinspirerade materialval. 

Den gedigna bordsskivan �r av �tervunnet almtr� och underredet best�r av en stadig, svart metall. 

Wilmer blir det utm�rkta nattduksbordet brevid s�ngen att s�tta s�nglampan p�. ', 4, 2295, 0.8, 12, 0, 10, 'Valn�t', 'Tr�', 0),

(120179, 'Wexi� Design Capella Pendellampa', 'Ny taklampa i mattsvart metall och med fyra r�kf�rgade glas. Passar bra i moderna milj�er. 
R�kf�rgade glaset �r inte bara snyggt utan f�rhindrar dessutom bl�ndning.
Ljusk�llor ing�r ej.', 5, 1379, 0.8, 13, 0, 8, 'Svart', 'Metall', 0),

(120180, 'Slokhatten Taklampa', 'Med dess solhattsliknande form sprids ljuset i en behaglig radie runt om i rummet utan att ta �ver resterande m�blemang allt f�r mycket.

En intressant taklampa som v�cker sommark�nslor. Limited edition och ljusk�llor ing�r ej', 5, 1295.55, 0.8, 9, 1, 10, 'Svart', 'Metall', 0 ),

(120181, 'Lucide pendellampa', 'Modern, enkelmonterad och fin taklampa. 
Ljusk�llor ing�r ej.', 5, 749, 0.8, 10, 0, 12, 'Svart', 'Metall', 0),

(120182, 'Medley Plafond', 'Denna magnifika taklampa med futuristisk och klassisk stil lyser upp rummet med galmour. Ljusk�llor ing�r ej.', 5, 6532, 0.8, 11, 0, 5, 'Silver', 'Metall', 0),

(120183, 'Trio Lighting Sorrento Pendellampa', 'Snygg taklampa som ser dyrare ut �n vad den faktiskt �r. Ljusk�llor ing�r ej.', 5, 4256, 0.8, 12, 0, 7, 'Kromf�rgad', 'Metall/Krom', 0)


INSERT INTO Customer (FirstName, LastName, Adress, ZipCode, City, Email, PhoneNumber, IdNumber, UserName, Password, Membership) VALUES
('Konrad', 'Ekbom', 'Blomstergatan 13', '16941', 'Bor�s', 'Konny75@hotmail.com', '072 54 89 21', '197504041237','Konny75', 'Blombom135!#', 1),
('Mariette', 'Von Holme', 'Akvarellv�gen 70', '15945', 'G�teborg', 'Mariette.V.H@hotmail.com', '073 67 33 02', '195505108467','Mvh70', '�lskarkatter2!', 1)

INSERT INTO Payment (Method, Specification) VALUES
('Faktura', 'F� varorna f�rst och betala efter 14 dagar eller dela upp betalningen'),
('Swish', 'Skanna QR kod och betala med Swish-appen'),
('Kort', 'Direktbetalning med kortnummer via PayPal')

INSERT INTO Shipping (Name, Price, Specification) VALUES 
('PostNord', 49, 'Levererar till brevl�da om varan f�r plats. Annars l�mnas varan p� n�rmaste PostNord-ombud.'),
('DHL', 59, 'Varan levereras direkt till d�rren. 
Du f�r SMS tv� timmar innan ankomst. Var redo med ID-kort'),
('Instabox', 29,'Varan l�mnas i n�rmaste Instabox-sk�p och du f�r SMS som notis med l�senord')


Select * from Customer