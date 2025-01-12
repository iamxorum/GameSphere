# GameSphere | UniBuc - AAMS Group Project
**GameSphere** is a platform that connects board game enthusiasts for local meetups, tournaments, and casual play. Find like-minded players, discover new games, and organize events effortlessly. GameSphere makes it easy to bring the tabletop gaming community together for fun and engaging experiences.

# Design Patterns

### Model-View-Controller (MVC)

Am folosit arhitectura **Model-View-Controller** pentru că permite separarea clară a logicii aplicației, interfeței utilizator și gestionării datelor, ceea ce face codul mai ușor de întreținut, extins și testat.


![Models](https://github.com/user-attachments/assets/f8a9ab7a-0188-4ab2-b676-ef704b3d9c41) ![Views](https://github.com/user-attachments/assets/717fd691-a7a3-436f-aafd-bb92e9c8a5ae) ![Controllers](https://github.com/user-attachments/assets/310a5d03-1636-443b-885c-9bbef1f262d6)

Utilizatorul interacționează cu View-ul, iar Controller-ul preia și procesează inputul primit. Apoi, Controller-ul actualizează Modelul, care gestionează datele și logica aplicației. În final, View-ul reflectă modificările realizate în Model, oferind utilizatorului o interfață actualizată.

### Repository Pattern

Am utilizat **Repository Pattern** pentru că ajută la organizarea codului și face aplicația mai modulară. Prin utilizarea acestuia, am putut să separăm logicile de acces la date de restul aplicației, să reutilizăm metodele de acces și să pregătim aplicația pentru eventuale schimbări ale sursei de date în viitor.

![Repositories](https://github.com/user-attachments/assets/7f8bca06-ecda-46f2-926c-f05ebf5429a8)

### Builder Pattern

Am folosit **Builder Pattern** pentru a configura și înregistra serviciile aplicației într-un mod organizat. Acesta permite adăugarea treptată a componentelor, precum repository-urile și serviciile, oferind flexibilitate și separare clară a responsabilităților. Prin `builder.Services`, am înregistrat dependințele necesare (repository-uri, servicii, Identity, Entity Framework), asigurând o inițializare eficientă și ușor de întreținut a aplicației.

![Builder](https://github.com/user-attachments/assets/c85ede65-e95e-4d2d-b670-fe49585c34b6)


