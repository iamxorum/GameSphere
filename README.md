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


Diagrama de secventa 

Diagrama de secvență arată interacțiunile dintre Admin, Player, Other Player, App și Database în cadrul aplicației GameSphere. Procesul include:

Crearea unui joc de către Admin, cu salvarea detaliilor jocului în baza de date.
Crearea unui eveniment de către Player, cu stocarea detaliilor în baza de date.
Înregistrarea unui alt utilizator (Other Player) la eveniment.
Selectarea unui joc pentru eveniment de către Player, cu actualizarea bazei de date.
Check-in-ul la eveniment al Other Player, cu validarea și înregistrarea participării.
Evaluarea condițiilor pentru acordarea unui badge, urmată de salvarea acestuia pentru utilizatorul eligibil.
Aceasta evidențiază fluxul complet de la crearea conținutului până la interacțiunile utilizatorilor la evenimente și recompensarea lor.

![Sequence diagram](https://github.com/user-attachments/assets/6c1c4f2c-6acc-462d-82d7-88dfe98e75f6)


