setlocal enabledelayedexpansion
@echo off
	cd PDF
	
	set dir=%CD%
	
	set /a compteur=0
	
	for /f "tokens=*" %%A in ('dir /b /a-d "*.txt"') do (
		set "fichier=%dir%\%%~nxA"
		set /p html=<"!fichier!"
		set "pdf=!fichier:~0,-3!pdf"
		set /a compteur+=1
		wkhtmltopdf !html! !pdf!
	)

pause