@echo off

SET R_HOME=../../Apps/Rstudio/bin
SET Rserve=%R_HOME%/Rserve

"%Rserve%" --start --port "7452" --tcp "3838" --rweb "../../fastRWeb/" --n_threads "8" /@set --internal_pipeline=TRUE

pause