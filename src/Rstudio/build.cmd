@echo off

SET drive=%~d0
SET R_HOME=%drive%/GCModeller\src\R-sharp\App\net6.0
SET pkg_repo=../../Apps/Rstudio/packages

%R_HOME%/Rscript.exe --build /src ./Rserver /save %pkg_repo%/Rserver.zip --skip-src-build 
%R_HOME%/R#.exe --install.packages %pkg_repo%/Rserver.zip

pause