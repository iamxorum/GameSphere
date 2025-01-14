# GameSphere | UniBuc - AAMS Group Project
**GameSphere** este o platformă care conectează pasionații de jocuri de societate pentru întâlniri locale, turnee și sesiuni de jocuri casuale. Găsește jucători cu aceleași interese, descoperă jocuri noi și organizează evenimente cu ușurință. GameSphere face ca reunirea comunității de jocuri de masă să fie simplă, oferind experiențe de distracție și interacțiune captivantă.

# Cerinte functionale

### Gestionarea evenimentelor de boardgame
- Crearea de evenimente, specificând:
  - Locul de desfășurare.
  - Jocurile disponibile.
  - Data și ora evenimentului.
- Înregistrarea utilizatorilor la evenimente.

### Propuneri
- Posibilitatea de a propune noi jocuri.

### Selecția jocului pentru eveniment
- Organizatorul poate alege un joc pentru eveniment 
- Comunicarea deciziei către participanți.

### Validarea participării
- Check-in pentru confirmarea participării la evenimente.

### Baza de date a jocurilor
- Include detalii despre jocuri:
  - Număr minim/maxim de participanți.
  - Reguli detaliate.

### Sistemul de badge-uri
- Badge-uri acordate utilizatorilor pentru:
  - Prima participare la un eveniment
 
# Cerințe nonfuncționale

### Înregistrare și autentificare securizată
-  Parolele utilizatorilor trebuie stocate criptat
-  Parolele utilizatorilor trebuie să fie complexe (cel puțin o literă mare, cel puțin un caracter special, cel puțin o cifră, minim 10 caractere)


 ### Contribuțiile echipei în cadrul proiectului:
O centralizare a diagramelor din cadrul echipei, cât și contribuția fiecărui membru se pot găsi în tabelul de mai jos:
![image](https://github.com/user-attachments/assets/c9010235-9bb2-4f88-8a62-1239616844bf)



# Design Patterns

### Model-View-Controller (MVC)

Am folosit arhitectura **Model-View-Controller** pentru că permite separarea clară a logicii aplicației, interfeței utilizator și gestionării datelor, ceea ce face codul mai ușor de întreținut, extins și testat.


![Models](https://github.com/user-attachments/assets/f8a9ab7a-0188-4ab2-b676-ef704b3d9c41) ![Views](https://github.com/user-attachments/assets/717fd691-a7a3-436f-aafd-bb92e9c8a5ae) ![Controllers](https://github.com/user-attachments/assets/310a5d03-1636-443b-885c-9bbef1f262d6)

Utilizatorul interacționează cu View-ul, iar Controller-ul preia și procesează inputul primit. Apoi, Controller-ul actualizează Modelul, care gestionează datele și logica aplicației. În final, View-ul reflectă modificările realizate în Model, oferind utilizatorului o interfață actualizată.

### Repository Pattern

Am utilizat **Repository Pattern** pentru că ajută la organizarea codului și face aplicația mai modulară. Prin utilizarea acestuia, am putut să separăm logicile de acces la date de restul aplicației, să reutilizăm metodele de acces și să pregătim aplicația pentru eventuale schimbări ale sursei de date în viitor.

![Repositories](https://github.com/user-attachments/assets/7f8bca06-ecda-46f2-926c-f05ebf5429a8)

### Builder Pattern

Am folosit **Builder Pattern** pentru a configura și înregistra serviciile aplicației într-un mod organizat. Acesta permite adăugarea treptată a componentelor, precum repository-urile și serviciile, oferind o separare clară a responsabilităților. Prin `builder.Services`, am înregistrat dependințele necesare (repository-uri, servicii, Identity, Entity Framework), asigurând o inițializare eficientă și ușor de întreținut a aplicației.

![Builder](https://github.com/user-attachments/assets/c85ede65-e95e-4d2d-b670-fe49585c34b6)

### Diagrama de Clase UML

Diagrama UML ilustrează structura claselor și relațiile dintre componentele principale ale aplicației **GameSphere**. Aceasta include următoarele elemente cheie:

#### Componenta Database
- Gestionează conexiunea la baza de date
- Metode principale:
  - `getInstance()`: Database
  - `connect()`: Connection
  - `closeConnection()`: void

#### Repository-uri
1. **BadgeRepository**
   - Gestionează operațiile legate de badge-uri
   - Metode principale:
     - `findById()`: void
     - `createBadge()`: void
     - `deleteBadge()`: void
     - `updateBadge()`: void

2. **UserRepository**
   - Gestionează operațiile legate de utilizatori
   - Metode principale:
     - `login()`: void
     - `create()`: void
     - `update()`: void
     - `delete()`: void

3. **EventRepository**
   - Gestionează operațiile legate de evenimente
   - Metode principale:
     - `findById()`: void
     - `findAll()`: void

4. **GameRepository**
   - Gestionează operațiile legate de jocuri
   - Metode principale:
     - `findById()`: void
     - `findAll()`: void

#### Entități Principale
1. **Badge**
   - Atribute: badgeId, name, description, privileges
   - Metode: assignBadge(), removeBadge()
pap
2. **Player**
   - Atribute: userId, username, password, email, age, etc.
   - Metode pentru gestionarea evenimentelor și interacțiunilor

3. **Event**
   - Atribute: eventId, name, startDate, maxParticipants
   - Relații cu Player și Game

4. **Game**
   - Atribute: gameId, name
   - Asocieri cu Event prin EventGameAssociation

#### Asocieri
- **BadgeUserAssociation**: Leagă badge-urile de utilizatori
- **EventGameAssociation**: Leagă evenimentele de jocuri
- Implementarea interfeței **Reportable** pentru generarea rapoartelor

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/UML.jpeg)

### Diagrama Bazei de Date

Baza de date a aplicației **GameSphere** este structurată în jurul mai multor entități cheie care gestionează informațiile necesare pentru funcționarea platformei:

#### Entități Principale:
- **Player (Jucător)**
  - `id`: varchar(255) - identificator unic (PK)
  - `username`: varchar(50) - numele de utilizator
  - `email`: varchar(50) - adresa de email
  - `password`: varchar(50) - parola criptată

- **Event (Eveniment)**
  - `id`: int - identificator unic (PK)
  - `name`: varchar(50) - numele evenimentului
  - `location`: varchar(255) - locația
  - `start_date`: date - data evenimentului
  - `max_players`: int - numărul maxim de participanți
  - `owner_id`: varchar(255) (FK) - ID-ul organizatorului
  - `chosen_game_id`: int (FK) - ID-ul jocului ales

- **Game (Joc)**
  - `id`: varchar(255) - identificator unic (PK)
  - `name`: varchar(50) - numele jocului
  - `max_participants`: varchar(50) - numărul maxim de participanți
  - `rules`: varchar(50) - regulile jocului

#### Tabele de Legătură:
- **PlayerEvent**
  - Leagă jucătorii de evenimentele la care participă
  - Conține `event_id` și `player_id` ca chei externe

- **PlayerRole**
  - Gestionează rolurile utilizatorilor în aplicație
  - Conține `player_id` și `role_id` ca chei externe

- **EventGame**
  - Asociază jocurile cu evenimentele
  - Conține `game_id` și `event_id` ca chei externe

#### Relații:
- Un jucător poate participa la multiple evenimente (1:N prin PlayerEvent)
- Un eveniment poate avea mai mulți participanți (1:N prin PlayerEvent)
- Un jucător poate avea multiple roluri (1:N prin PlayerRole)
- Un eveniment este asociat cu un singur joc ales (1:1 prin chosen_game_id)

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/ERD_Diagram.jpeg)

### Diagrama de Secventa 

Diagrama de secvență arată interacțiunile dintre Admin, Player, Other Player, App și Database în cadrul aplicației GameSphere. Procesul include:

Crearea unui joc de către Admin, cu salvarea detaliilor jocului în baza de date.
Crearea unui eveniment de către Player, cu stocarea detaliilor în baza de date.
Înregistrarea unui alt utilizator (Other Player) la eveniment.
Selectarea unui joc pentru eveniment de către Player, cu actualizarea bazei de date.
Check-in-ul la eveniment al Other Player, cu validarea și înregistrarea participării.
Evaluarea condițiilor pentru acordarea unui badge, urmată de salvarea acestuia pentru utilizatorul eligibil.
Aceasta evidențiază fluxul complet de la crearea conținutului până la interacțiunile utilizatorilor la evenimente și recompensarea lor.

![Sequence diagram](https://github.com/iamxorum/GameSphere/blob/main/assets/Sequence_diagram.png)

### Diagrama de Componente

Diagrama de componente prezintă arhitectura sistemului GameSphere, în care interfața utilizatorului comunică printr-un API Gateway cu servicii specializate pentru utilizatori, evenimente și jocuri. Aceste servicii interacționează cu baza de date utilizând operațiuni CRUD pentru a gestiona datele necesare funcționalităților aplicației.

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/components_diagram.png)

### Diagrama de Activitate

Diagrama de activitate ilustrează fluxul principal al aplicației, începând cu autentificarea utilizatorului și verificarea rolului său. Adminii au posibilitatea de a crea jocuri, care sunt salvate în baza de date, în timp ce Jucătorii pot iniția evenimente. Utilizatorii pot vizualiza evenimentele disponibile și își pot exprima preferințele pentru jocuri. Creatorul evenimentului are responsabilitatea de a alege jocul ce va fi jucat, luând în considerare preferințele participanților. Un pas esențial în acest proces este verificarea numărului de participanți: dacă limita maximă nu a fost atinsă, utilizatorul se poate înregistra la eveniment. În caz contrar, înregistrarea este refuzată. În continuare are loc evenimentul, iar la final, sunt acordate badge-uri. Diagrama evidențiază pașii esențiali și deciziile cheie din cadrul acestui proces.

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/activitydiagram.png)

### Diagrama de Pachete

Pachetele oferă o modalitate de a grupa elementele și de a stabili dependențele dintre componentele aplicației.

- Pachetul Controllers gestionează cererile utilizatorilor și le transmite către Services. Totodată, preia datele procesate din alte pachete și le trimite către Views, unde sunt afișate utilizatorilor.
- Services conține logica principală a aplicației, procesează datele și apelează metodele din Repositories pentru interacțiunea cu baza de date. Totodată, acest pachet folosește Models pentru a manipula datele.
- Pachetul Repositories accesează direct baza de date, folosind Data pentru operații CRUD. În același timp, folosesc Models pentru reprezentarea și manipularea datelor din baza de date.
- Models este format din structuri de date care definesc entitățile aplicației, precum jocuri, evenimente sau utilizatori.
- Pachetul Data gestionează conexiunea și interacțiunea cu baza de date, inclusiv popularea acesteia cu date inițiale.
- Views afișează informațiile utilizatorilor sub formă de elemente vizuale, având la bază datele primite de la Controller

Diagrama folosește următoarele relații:
- uses: Indică utilizarea directă a elementelor, precum clase sau metode, dintr-un alt pachet.
- import: Afișează că anumite module sunt utilizate global în alte secțiuni, fiind esențiale pentru funcționarea întregii aplicații.
- renders: Reflectă transmiterea datelor către utilizatori sub formă vizuală.

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/packagediagram.png)

### Diagrama de Structură

Diagrama de structură a aplicației GameSphere ilustrează arhitectura generală a sistemului, evidențiind interacțiunile dintre componentele principale. Aceasta include:

- Interfața Utilizatorului: Componenta care permite utilizatorilor să interacționeze cu aplicația.
- API Gateway: Punctul central de acces pentru toate cererile, care redirecționează traficul către serviciile corespunzătoare.
- Serviciile de Business: Acestea includ servicii pentru gestionarea utilizatorilor, evenimentelor, jocurilor și sistemului de badge-uri, fiecare având responsabilități specifice.
- Baza de Date: Structura care stochează informațiile despre utilizatori, evenimente, jocuri și badge-uri, utilizând operațiuni CRUD pentru gestionarea datelor.

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/Structural_diagram.png)

### Diagrama de Comportament

Diagrama de comportament descrie fluxul de interacțiune al utilizatorilor în cadrul aplicației GameSphere. Aceasta include:

- Autentificarea Utilizatorului: Procesul prin care utilizatorii se conectează la aplicație, cu validarea rolului lor (Admin sau Jucător).
- Gestionarea Evenimentelor: Fluxul de creare, vizualizare și participare la evenimente, inclusiv selecția jocului și validarea numărului de participanți.
- Sistemul de Badge-uri: Mecanismul prin care utilizatorii primesc recompense pentru participarea la evenimente.

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/Behavioural_diagram.jpeg)

### Diagrama Use Case

Diagrama use case ilustrează interacțiunile posibile ale diferitelor tipuri de utilizatori cu aplicația **GameSphere**. Aceasta prezintă funcționalitățile disponibile pentru fiecare rol de utilizator:

#### Actori și Funcționalități

1. **Guest User (Utilizator Neautentificat)**
   - Login (Autentificare)
   - Register (Înregistrare)

2. **Admin (Administrator)**
   - Add game (Adăugare joc nou în sistem)
   - Toate funcționalitățile unui utilizator autentificat

3. **Player (Jucător)**
   - Create event (Creare eveniment nou)
   - Sign in for an event (Înscriere la un eveniment)
   - Propose a game (Propunere joc nou)
   - Choose game (Alegere joc pentru eveniment)
   - Check-in at a event (Confirmare prezență la eveniment)
   - Add badge to player (Primire/vizualizare badge-uri)

#### Caracteristici Principale
- Ierarhie clară a rolurilor utilizatorilor
- Separare distinctă a funcționalităților administrative
- Funcționalități specifice pentru organizarea și participarea la evenimente
- Sistem de recompense prin badge-uri

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/UseCaseDiagram.png)

### Diagrama de Deployment

Diagrama de deployment ilustrează arhitectura fizică a sistemului **GameSphere**, prezentând distribuția componentelor și relațiile dintre acestea:

#### Componente Principale

1. **AppServer**
   - Device: Server de aplicație
   - Mediu de execuție: ASP.NET Core
   - Artefacte:
     - DLL Files (fișierele compilate ale aplicației)

2. **DatabaseServer**
   - Device: Server de bază de date
   - Engine: Microsoft SQL Server
   - Artefacte:
     - DB Schema (structura bazei de date)

3. **UserClient**
   - Device: Browser-ul utilizatorului
   - Componente:
     - Browser
     - HTML5 - Razor Views (interfața utilizator)

#### Conexiuni
- Comunicare între AppServer și DatabaseServer prin:
  - Protocol: ADO.NET (SQL Protocol)
  - Asigură accesul la baza de date

- Comunicare între UserClient și AppServer prin:
  - Protocol: TCP :80
  - Facilitează interacțiunea utilizatorului cu aplicația

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/Deployment_Diagram.jpg)
