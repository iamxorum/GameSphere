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
![image](https://github.com/user-attachments/assets/f307ba75-394d-421e-a933-f16329f6aa76)



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


### Diagrama de secventa 

Diagrama de secvență arată interacțiunile dintre Admin, Player, Other Player, App și Database în cadrul aplicației GameSphere. Procesul include:

Crearea unui joc de către Admin, cu salvarea detaliilor jocului în baza de date.
Crearea unui eveniment de către Player, cu stocarea detaliilor în baza de date.
Înregistrarea unui alt utilizator (Other Player) la eveniment.
Selectarea unui joc pentru eveniment de către Player, cu actualizarea bazei de date.
Check-in-ul la eveniment al Other Player, cu validarea și înregistrarea participării.
Evaluarea condițiilor pentru acordarea unui badge, urmată de salvarea acestuia pentru utilizatorul eligibil.
Aceasta evidențiază fluxul complet de la crearea conținutului până la interacțiunile utilizatorilor la evenimente și recompensarea lor.

![Sequence diagram](https://github.com/user-attachments/assets/6c1c4f2c-6acc-462d-82d7-88dfe98e75f6)

### Diagrama de componente

Diagrama de componente prezintă arhitectura sistemului GameSphere, în care interfața utilizatorului comunică printr-un API Gateway cu servicii specializate pentru utilizatori, evenimente și jocuri. Aceste servicii interacționează cu baza de date utilizând operațiuni CRUD pentru a gestiona datele necesare funcționalităților aplicației.

![image](https://github.com/user-attachments/assets/3258549a-1376-4cd4-a67d-279bc8277b03)

### Diagrama de Activitate

Diagrama de activitate ilustrează fluxul principal al aplicației, începând cu autentificarea utilizatorului și verificarea rolului său. Adminii au posibilitatea de a crea jocuri, care sunt salvate în baza de date, în timp ce Jucătorii pot iniția evenimente. Utilizatorii pot vizualiza evenimentele disponibile și își pot exprima preferințele pentru jocuri. Creatorul evenimentului are responsabilitatea de a alege jocul ce va fi jucat, luând în considerare preferințele participanților. Un pas esențial în acest proces este verificarea numărului de participanți: dacă limita maximă nu a fost atinsă, utilizatorul se poate înregistra la eveniment. În caz contrar, înregistrarea este refuzată. În continuare are loc evenimentul, iar la final, sunt acordate badge-uri. Diagrama evidențiază pașii esențiali și deciziile cheie din cadrul acestui proces.

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/activitydiagram.png)


### Diagrama de Pachete

Pachetele oferă o modalitate de a grupa elementele și de a stabili dependențele dintre componentele aplicației.

Controllers: Gestionează cererile utilizatorilor și le transmite către Services. Totodată, preia datele procesate din alte pachete și le trimite către Views, unde sunt afișate utilizatorilor.
Services: Conține logica principală a aplicației, procesează datele și apelează metodele din Repositories pentru interacțiunea cu baza de date.
Repositories: Accesează direct baza de date, folosind Data pentru operații CRUD. În același timp, folosesc Models pentru reprezentarea și manipularea datelor din baza de date.
Models: Definește structurile de date utilizate în aplicație, precum jocuri, evenimente sau utilizatori, și este folosit atât de Controller, cât și de Services.
Data: Stochează setările bazei de date și inițializarea datelor, accesate de Repositories pentru configurarea aplicației.
Views: Afișează informațiile utilizatorilor sub formă de elemente vizuale, bazându-se pe datele primite de la Controllers.

Diagrama folosește următoarele relații:
- uses: Indică utilizarea directă a elementelor, precum clase sau metode, dintr-un alt pachet.
- import: Afișează că anumite module sunt utilizate global în alte secțiuni, fiind esențiale pentru funcționarea întregii aplicații.
- renders: Reflectă transmiterea datelor către utilizatori sub formă vizuală.

![image](https://github.com/iamxorum/GameSphere/blob/main/assets/packagediagram.png)
