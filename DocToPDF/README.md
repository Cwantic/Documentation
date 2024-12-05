---
layout: default
title: 
nav_exclude: true
---

# Creation de la documentation en PDF

1) Mettre temporairement l'imprimante "**Microsoft Print to PDf**" comme imprimante par défaut.

---

2) Lancer Git bash

---

2) coller "cd xxx\\CWANTIC\\Documentation\\DocToPDF" où xxx est le chemin vers le projet GIT.

>ATTENTION : utiliser le double \ \ plutôt que le \

* JOSEPH : "cd C:\\CWANTIC\\MetaPiping\\Documentation\\DocToPDF"
* SEB : "cd C:\\Users\\sebas\\Documents\\Git\\CWANTIC\\Documentation\\DocToPDF"
---

3) Copier le contenu du fichier "1_justTheDocs_To_HTML.bash" et le coller dans Git bash -> cela génèrera des fichiers TXT dans le dossier PDF

---

4) Double click sur le fichier "2_HTML_To_PDF.bat" -> une liste de PDF se créera

---

5) Double click sur le fichier "3_MakePDF.bat" -> Documentation_MetaPiping.pdf se créera (les txt et pdf intermédiaires seront effacés)

---

6) Remettre l'imprimante originale comme imprimante par défaut