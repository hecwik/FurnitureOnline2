INSERT INTO Category (Name, HiddenCategory) VALUES
('Skrivbord', 0),
('Soffgrupp', 0),
('Bokhylla', 0),
('Nattduksbord', 0),
('Taklampa', 0)

INSERT INTO Supplier (Name, City, Adress, ZipCode, HiddenSupplier) VALUES
('IKEA', 'Stockholm', 'Kungsgatan 35', '14124', 0),
('Mio', 'Göteborg', 'Regeringsgatan 12', '12623', 0),
('Norrmalms möbler', 'Stockholm', 'Nils Holgerssons v. 135', '12492', 0),
('Möbelvaruhuset AB', 'Borås', 'Brogatan 24','12859', 0),
('Chilli', 'Malmö', 'Karl-Fredriks torg 8', '14338', 0)


INSERT INTO Products (ArticleNumber, Name, Description, CategoryId, CurrentPrice, Moms, SupplierId, ChosenItem, stockUnit, Color, Material, HiddenArticle) VALUES
(120160,'Gisela Skrivbord','Stabilt och tidlöst skrivbord', 1, 3549, 0.8, 9, 0, 40, 'Träfärg','Träskiva och metallben', 0),

(120161, 'Function plus skrivbord', 'Function Plus är en skrivbordsserie beståendes av skrivbord i flera olika färger och utförande. 

I serien hittar du stilrena och enkla skrivbord med mer eller mindre förvaringsmöjligheter. 

Function Plus är en snygg kombination av vitt och ek gör det till en lättmatchad möbel eftersom det passar både i kombination vita möbler och med ekmöbler.', 1, 2599, 0.8, 10, 0, 10, 'Vit', 'Trä', 0),

(120162, 'Vasagle Datorbord L-form', 'Snygg och stabil datorbord smidigt med L form som ger mer arbetsyta.', 1, 2679, 0.8, 11, 0, 25, 'Brunt', 'Trä och metall', 0),

(120163, 'Hampton Skrivbord', 'Hampton är ett lantligt skrivbord i klassisk form som lyfter hemmakontoret till en helt ny nivå. 
Hampton ger en rymlig och bra yta till att sitta och arbeta ikapp ostört hemma, kanske pyssla med ett kreativt projekt.', 1, 1499, 0.8, 12, 1, 15, 'Vit', 'Massivt ugnsstorkat Mahogny', 0),

(120164, 'Mazel skrivbord', 'Detta skrivbord är en härlig kombination mellan skrivbord och hylla då benen är utformade med hyllanpassad förvaring', 1, 3780, 0.8, 13, 0, 5, 'Vit/valnöt', 'Trä', 0),

(120165, 'Andrew soffgrupp', 'Denna soffgrupp blir en hemtrevlig detalj till vardagsrummet. 

Gruppen har stilrena proportioner och ger ett nätt intryck som fulländas av fina detaljer i form av stilriktiga hjul och klädda knappar på ryggkuddarna. 

Gruppen består av en 2-sits soffa samt fåtölj och fotpall.', 2, 12489, 0.8, 9, 0, 17, 'Beige', 'Sammet', 0),

(120166, 'Kivik soffgrupp', 'Kryp upp i den sköna soffan KIVIK. 

Den generösa storleken, de låga armstöden och memoryskummet som formar sig efter din kropp gör att du gärna hänger, slappar och slumrar i soffan timme efter timme.', 2, 14.995, 0.8, 10, 0, 10, 'Skiftebo/mörkgrå', 'Högelastisk polyeter.', 0),

(120167, 'Chesterfield LYX soffgrupp', 'Chesterfield Lyx är soffgruppen med extravagant framtoning i en klassisk läcker stil. 

Få ett (nästan) komplett och stilsäkert vardagsrum genom att satsa på en tidlös soffgrupp som erbjuder både 2-sits, 3-sits och en charmerande fåtölj i ett och samma paket. 

Möblerna har en stoppad sits som garanterar hög komfort och den vackert knappbeströdda designen blir ett vackert inslag i hemmet.', 2, 20.699, 0.8, 11, 0, 8, 'Mörkblå', 'Sammet', 0),

(120168, 'Howard Classic Soffgrupp', 'Howard Classic soffgrupp med en 3,5-sits och en 3-sits soffa samt en fåtölj och en fotpall är en prisvärd soffgrupp med god komfort och hög stilkänsla. 

Med den här soffgruppen kan du skänka vardagsrummet lite extra elegans. Med stilfulla detaljer och mjukt rundade former är möblerna lika snygga som sköna. 

Välj mellan olika utföranden och hitta en howardsoffgrupp som passar hemma hos just dig!', 2, 11.459, 0.8, 12, 0, 5, 'Grå', 'Tyg', 0),

(120169, 'Billys Bokhylla', 'Flyttbara hyllplan; anpassa avstånd efter behov.

En enkel enhet kan vara tillräcklig förvaring för ett begränsat utrymme eller grunden till en större förvaring om dina behov förändras.

Denna möbel måste förankras i vägg med medföljande beslag.

Olika väggmaterial kräver olika typer av fästbeslag. Använd beslag som passar väggarna i ditt hem, säljes separat.

2 hyllplan medföljer.

Komplettera gärna med dörrar i olika färger och utförande.

Designer: Gillis Lundgren', 3, 399.00, 0.8, 13, 1, 45, 'Vit', 'Trä', 0),

(120170, 'Loide vägghylla', 'Loide är stilren och trendig med fokus på den skandinaviska stilen. 

Med trivsam formgivning i noggrant utvalda material erbjuder Loide ett brett sortiment stilsäkra möbler.', 3, 895.00, 0.8, 9, 0, 15,

'Beige', 'Ek', 0),

(120171, 'Blobok bokhylla', 'Stilren och funktionell bokhylla för förvaring', 3, 1279.90, 0.8, 10, 0, 15, 'Vit med inslag av trä', 'Trä', 0 ),

(120172, 'Hasselvik hylla', 'Hasslevik hylla med klassisk design och noga utvalda material. 
Den vackra trälooken är ett prisvärt alternativ som kombinerar förvaring och design på ett enastående vis.', 3, 899, 0.8, 11, 0, 10, 'Grå', 'Metall', 0),

(120173, 'Brief bokhylla', 'Industriell, snygg och praktisk golvhylla', 3, 2755, 0.8, 12, 0, 7, 'Mörkbrun/Svart', 'Trä/Metall', 0),

(120174, 'Vikhammer', 'Stilren och enkel design som passar fint med lite högre sängar. 

Om en bra bok har hållit dig vaken kan du lägga undan den i en av de mjukstängande lådorna – tyst och stilla och utan att väcka någon annan.', 4, 599.50, 0.8, 13, 0, 22, 'Svart', 'Spånskiva. Akrylfärg', 0),

(120175, 'Myrvallen nattduksbord', 'Tidlös praktikst och fint sängbord som monteras på väggen', 4, 5689, 0.8, 9, 0, 14, 'Vit', 'Melamin', 0),

(120176, 'Marco sängbord', 'Marco sängbord är ett charmigt nattduksbord som hjälper dig att hålla ordning i ditt sovrum. 

Med fyra rymliga lådor i olika stil har du gott om plats för förvaring. Med en lekfull stil, olika färger och former på lådorna drar Marco blickarna till sig och lyfter rummet. 

Höga, vinklade ben är en snygg detalj, ger ett luftigt intryck och underlättar dessutom städningen.', 4, 1495, 0.8, 10, 0, 15, 'Vit/Blå/Brun', 'Trä', 0),

(120177,'Colima Sängbord', 'Tidlöst och praktikst sängbord', 4, 1100, 0.8, 11, 0, 8, 'Vit', 'Trä', 0),

(120178, 'Wilmer sängbord', 'Wilmer är ett sängbord/avlastningsbord i rustik utformning med naturinspirerade materialval. 

Den gedigna bordsskivan är av återvunnet almträ och underredet består av en stadig, svart metall. 

Wilmer blir det utmärkta nattduksbordet brevid sängen att sätta sänglampan på. ', 4, 2295, 0.8, 12, 0, 10, 'Valnöt', 'Trä', 0),

(120179, 'Wexiö Design Capella Pendellampa', 'Ny taklampa i mattsvart metall och med fyra rökfärgade glas. Passar bra i moderna miljöer. 
Rökfärgade glaset är inte bara snyggt utan förhindrar dessutom bländning.
Ljuskällor ingår ej.', 5, 1379, 0.8, 13, 0, 8, 'Svart', 'Metall', 0),

(120180, 'Slokhatten Taklampa', 'Med dess solhattsliknande form sprids ljuset i en behaglig radie runt om i rummet utan att ta över resterande möblemang allt för mycket.

En intressant taklampa som väcker sommarkänslor. Limited edition och ljuskällor ingår ej', 5, 1295.55, 0.8, 9, 1, 10, 'Svart', 'Metall', 0 ),

(120181, 'Lucide pendellampa', 'Modern, enkelmonterad och fin taklampa. 
Ljuskällor ingår ej.', 5, 749, 0.8, 10, 0, 12, 'Svart', 'Metall', 0),

(120182, 'Medley Plafond', 'Denna magnifika taklampa med futuristisk och klassisk stil lyser upp rummet med galmour. Ljuskällor ingår ej.', 5, 6532, 0.8, 11, 0, 5, 'Silver', 'Metall', 0),

(120183, 'Trio Lighting Sorrento Pendellampa', 'Snygg taklampa som ser dyrare ut än vad den faktiskt är. Ljuskällor ingår ej.', 5, 4256, 0.8, 12, 0, 7, 'Kromfärgad', 'Metall/Krom', 0)


INSERT INTO Customer (FirstName, LastName, Adress, ZipCode, City, Email, PhoneNumber, IdNumber, UserName, Password, Membership) VALUES
('Konrad', 'Ekbom', 'Blomstergatan 13', '16941', 'Borås', 'Konny75@hotmail.com', '072 54 89 21', '197504041237','Konny75', 'Blombom135!#', 1),
('Mariette', 'Von Holme', 'Akvarellvägen 70', '15945', 'Göteborg', 'Mariette.V.H@hotmail.com', '073 67 33 02', '195505108467','Mvh70', 'Älskarkatter2!', 1)

INSERT INTO Payment (Method, Specification) VALUES
('Faktura', 'Få varorna först och betala efter 14 dagar eller dela upp betalningen'),
('Swish', 'Skanna QR kod och betala med Swish-appen'),
('Kort', 'Direktbetalning med kortnummer via PayPal')

INSERT INTO Shipping (Name, Price, Specification) VALUES 
('PostNord', 49, 'Levererar till brevlåda om varan får plats. Annars lämnas varan på närmaste PostNord-ombud.'),
('DHL', 59, 'Varan levereras direkt till dörren. 
Du får SMS två timmar innan ankomst. Var redo med ID-kort'),
('Instabox', 29,'Varan lämnas i närmaste Instabox-skåp och du får SMS som notis med lösenord')


Select * from Customer