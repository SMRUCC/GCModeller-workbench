@echo off

SET R_HOME=../../Apps/Rstudio/bin
SET Rscript=%R_HOME%/Rscript

"%Rscript%" ./http.R --listen 19612 --wwwroot ../../web/ --attach ../../Apps/Rstudio/packages/Rserver.zip

pause