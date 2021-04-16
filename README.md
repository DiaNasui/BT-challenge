# BT-challenge
Jobs Processing Console App

Functionalitate:

1) Avem o baza de date JobsDB cu o tabela de Tasks, care pastreaza notificari (specific pt functionalitatea aleasa) si date despre notificari (nume, descriere, data creearii,
tipul taskului, un flag care semnaleaza daca s-a trimis sau nu notificarea si data trimiterii sau null daca notificarea nu a fost trimisa).

2) Avem un Serviciu de WEB API pt notificari unde putem sa:
a) Extragem valorile din tabel / notificarile inserate in tabelul tasks (\GetJobs)
b) Extragem o notificare specifica dupa un anumit ID (\GetJobById?id=)
c) Inseram o notificare (\Init?task)
d) Modificam flagul ca fiind ne trimisa notificarea(\Reject?id=)
e) Modificam flagul ca fiind trimisa/procesata notificara (\Confirm?id=)

3) Avem console app care parcurge lista notificarilor din DB si pe cele marcate ca fiind netrimise le trimite ca mail cu Subject fiind numele notificarii 
si Body descrierea notificarii (date luate din tabelul de tasks) pe o anumita adresa de email. In continuare dupa trimiterea mail-ului notificarile sunt updatate in baza de date
ca fiind trimise prin apelarea unui API din Serviciul existent.

Dat fiind faptul ca, functionalitatea si codul acopera o situatie reala, am creat un job cu Task Scheduler care ruleaza Console Application in fiecare zi la o anumita ora si
executa scenariul descris mai sus.

Bineinteles, codul si aplicatia pot fi extinse atat la nivel de DB cat si la nivel de cod, acesta fiind un simplu exemplu care acopera o situatie reala.
In ideea de a fi scalabila solutia si anume apelarea pt fiecare notificare din tabel a unui API din serviciu, astfel incat sa fie cat mai performante / eficiente call urile
spre API dar si in cazul in care pe partea de baze de date se extind numarul notificarilor aplicatia sa functioneze atat pt 100 de notificari cat si pt 100000 de notificari 
m-am gandit la asyncrounous programming.
