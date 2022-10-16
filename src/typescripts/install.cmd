@echo off

REM compile of the typescript projects at first

REM cd biocad_desktop
REM tsc
REM cd ..

REM and then we could
REM install the compiled typescript project into the web source folder
SET jscompress=java -jar ./tools/closure-compiler-v20181125.jar
SET built=./build
SET app_release=../../web/javascript/
SET jump=linq_js

echo "Google GCC engine found at:"
echo %jscompress%

goto :%jump%

REM ----===== google gcc function =====----
:exec_gcc
SETLOCAL

REM the function accept one required parameter:
REM 
REM _src: the filename of the target compiled typescript 
REM       output javascript file to run gcc compression.
REM
REM
SET _src=%1
SET logfile="%built%/logs/%_src%.txt"
SET _js_src=%built%/%_src%.js
SET _js_min=%app_release%/%_src%.min.js

echo "Do javascript script minify compression... package %_src%!"
echo "  --> %_js_src%"
echo "  --> minify: %_js_min%"

REM clean works and rebuild libraries
%jscompress% --js %_js_src% --js_output_file "%_js_min%" 

@echo:
echo "build package %_src% job done!"
@echo:
@echo:
@echo:
echo --------------------------------------------------------
@echo:
@echo:

ENDLOCAL & SET _result=0
goto :%jump%

REM ----===== end of function =====----

:linq_js

SET jump=linq_end
CALL :exec_gcc linq
:linq_end


:biocad_desktop_js

SET jump=biocad_desktop_end
CALL :exec_gcc biocad_desktop
:biocad_desktop_end

:sampleinfo_js
SET jump=sampleinfo_end
CALL :exec_gcc sampleinfo_editor
:sampleinfo_end


echo "all done!"
pause

exit 0