@echo off
setlocal enabledelayedexpansion

:: Définir le répertoire contenant les fichiers PDF
set originaldir=%CD%
cd PDF
set dir=%CD%

:: Créer une liste des fichiers PDF dans le répertoire
dir /b /a-d "%dir%\*.pdf" > fichiers.txt

:: Initialiser une variable pour stocker les noms de fichiers
set "fichiers="

:: Lire la liste des fichiers et les ajouter à la variable
for /f "tokens=*" %%a in (fichiers.txt) do (
    set "fichiers=!fichiers! "%%a""
)

:: Utiliser pdftk pour fusionner les fichiers PDF
pdftk %fichiers% cat output %originaldir%\Documentation_MetaPiping.pdf

:: Supprimer le fichier temporaire contenant la liste des fichiers
del fichiers.txt

:: supprimer les fichiers txt et pdf
set "extension=.txt"
del *%extension% /s /q
set "extension=.pdf"
del *%extension% /s /q

echo Fusion des fichiers PDF terminée.
pause