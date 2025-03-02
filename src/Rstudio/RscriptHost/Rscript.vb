﻿#Region "Microsoft.VisualBasic::7820b3f0d22e771302a9dbff306afdc9, win32_desktop\src\Rstudio\RscriptHost\Rscript.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:


    ' Code Statistics:

    '   Total Lines: 278
    '    Code Lines: 151 (54.32%)
    ' Comment Lines: 102 (36.69%)
    '    - Xml Docs: 57.84%
    ' 
    '   Blank Lines: 25 (8.99%)
    '     File Size: 12.33 KB


    ' Class Rscript
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Function: FromEnvironment
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.InteropService
Imports Microsoft.VisualBasic.ApplicationServices

' Microsoft VisualBasic CommandLine Code AutoGenerator
' assembly: ..\bin\Rscript.dll

' 
'  // 
'  // 
'  // 
'  // VERSION:   1.0.0.0
'  // ASSEMBLY:  Rscript, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
'  // COPYRIGHT: 
'  // GUID:      
'  // BUILT:     1/1/2000 12:00:00 AM
'  // 
' 
' 
'  < Rsharp.NetCore5.CLI >
' 
' 
' SYNOPSIS
' Rscript command [/argument argument-value...] [/@set environment-variable=value...]
' 
' All of the command that available in this program has been list below:
' 
'  --build:        build R# package
'  --check:        Verify a packed R# package is damaged or not or check the R# script problem 
'                  in a R package source folder
'  --lambda:       Execute R# function with parameters
'  --parallel:     Create a new parallel thread process for running a new parallel task
'  --slave:        Create a R# cluster node for run background or parallel task. This IPC command 
'                  will run a R# script file that specified by the ``/exec`` argument, and then 
'                  post back the result data json to the specific master listener
' 
' 
' ----------------------------------------------------------------------------------------------------
' 
'    1. You can using "Rscript ??<commandName>" for getting more details command help.
'    2. Using command "Rscript /CLI.dev [---echo]" for CLI pipeline development.
'    3. Using command "Rscript /i" for enter interactive console mode.

Namespace CLI


''' <summary>
''' Rsharp.NetCore5.CLI
''' </summary>
'''
Public Class Rscript : Inherits InteropService

    Public Const App$ = "Rscript.exe"

    Sub New(App$)
        Call MyBase.New(app:=App$)
    End Sub
        
''' <summary>
''' Create an internal CLI pipeline invoker from a given environment path. 
''' </summary>
''' <param name="directory">A directory path that contains the target application</param>
''' <returns></returns>
     <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Shared Function FromEnvironment(directory As String) As Rscript
          Return New Rscript(App:=directory & "/" & Rscript.App)
     End Function

''' <summary>
''' ```bash
''' --build [/src &lt;folder, default=./&gt; --skip-src-build /save &lt;Rpackage.zip&gt;]
''' ```
''' build R# package
''' </summary>
'''
''' <param name="src"> A folder path that contains the R source files and meta data files of the target R package, 
'''               a folder that exists in this folder path which is named &apos;R&apos; is required!
''' </param>
Public Function Compile(Optional src As String = "./", Optional save As String = "", Optional skip_src_build As Boolean = False) As Integer
Dim cli = GetCompileCommandLine(src:=src, save:=save, skip_src_build:=skip_src_build, internal_pipelineMode:=True)
    Dim proc As IIORedirectAbstract = RunDotNetApp(cli)
    Return proc.Run()
End Function
Public Function GetCompileCommandLine(Optional src As String = "./", Optional save As String = "", Optional skip_src_build As Boolean = False, Optional internal_pipelineMode As Boolean = True) As String
    Dim CLI As New StringBuilder("--build")
    Call CLI.Append(" ")
    If Not src.StringEmpty Then
            Call CLI.Append("/src " & """" & src & """ ")
    End If
    If Not save.StringEmpty Then
            Call CLI.Append("/save " & """" & save & """ ")
    End If
    If skip_src_build Then
        Call CLI.Append("--skip-src-build ")
    End If
     Call CLI.Append($"/@set --internal_pipeline={internal_pipelineMode.ToString.ToUpper()} ")


Return CLI.ToString()
End Function

''' <summary>
''' ```bash
''' --check --target &lt;package.zip&gt; [--debug]
''' ```
''' Verify a packed R# package is damaged or not or check the R# script problem in a R package source folder.
''' </summary>
'''

Public Function Check(target As String, Optional debug As Boolean = False) As Integer
Dim cli = GetCheckCommandLine(target:=target, debug:=debug, internal_pipelineMode:=True)
    Dim proc As IIORedirectAbstract = RunDotNetApp(cli)
    Return proc.Run()
End Function
Public Function GetCheckCommandLine(target As String, Optional debug As Boolean = False, Optional internal_pipelineMode As Boolean = True) As String
    Dim CLI As New StringBuilder("--check")
    Call CLI.Append(" ")
    Call CLI.Append("--target " & """" & target & """ ")
    If debug Then
        Call CLI.Append("--debug ")
    End If
     Call CLI.Append($"/@set --internal_pipeline={internal_pipelineMode.ToString.ToUpper()} ")


Return CLI.ToString()
End Function

''' <summary>
''' ```bash
''' --lambda &lt;delegate_name&gt; [--request &lt;/path/to/del_func_parameters.json, default=&quot;./.r_env/run.json&quot;&gt; --SetDllDirectory &lt;dll_directory&gt;]
''' ```
''' Execute R# function with parameters
''' </summary>
'''

Public Function execLambda(term As String) As Integer
Dim cli = GetexecLambdaCommandLine(term:=term, internal_pipelineMode:=True)
    Dim proc As IIORedirectAbstract = RunDotNetApp(cli)
    Return proc.Run()
End Function
Public Function GetexecLambdaCommandLine(term As String, Optional internal_pipelineMode As Boolean = True) As String
    Dim CLI As New StringBuilder("--lambda")
    Call CLI.Append(" ")
    Call CLI.Append($"{term}")
     Call CLI.Append($"/@set --internal_pipeline={internal_pipelineMode.ToString.ToUpper()} ")


Return CLI.ToString()
End Function

''' <summary>
''' ```bash
''' --parallel --master &lt;master_port&gt; [--host &lt;localhost&gt; --delegate &lt;delegate_name&gt; --redirect_stdout &lt;logfile.txt&gt;]
''' ```
''' Create a new parallel thread process for running a new parallel task.
''' </summary>
'''
''' <param name="master"> the TCP port of the master node.
''' </param>
Public Function parallelMode(master As String, Optional host As String = "", Optional [delegate] As String = "", Optional redirect_stdout As String = "") As Integer
Dim cli = GetparallelModeCommandLine(master:=master, host:=host, [delegate]:=[delegate], redirect_stdout:=redirect_stdout, internal_pipelineMode:=True)
    Dim proc As IIORedirectAbstract = RunDotNetApp(cli)
    Return proc.Run()
End Function
Public Function GetparallelModeCommandLine(master As String, Optional host As String = "", Optional [delegate] As String = "", Optional redirect_stdout As String = "", Optional internal_pipelineMode As Boolean = True) As String
    Dim CLI As New StringBuilder("--parallel")
    Call CLI.Append(" ")
    Call CLI.Append("--master " & """" & master & """ ")
    If Not host.StringEmpty Then
            Call CLI.Append("--host " & """" & host & """ ")
    End If
    If Not [delegate].StringEmpty Then
            Call CLI.Append("--delegate " & """" & [delegate] & """ ")
    End If
    If Not redirect_stdout.StringEmpty Then
            Call CLI.Append("--redirect_stdout " & """" & redirect_stdout & """ ")
    End If
     Call CLI.Append($"/@set --internal_pipeline={internal_pipelineMode.ToString.ToUpper()} ")


Return CLI.ToString()
End Function

''' <summary>
''' ```bash
''' --slave /exec &lt;script.R&gt; /args &lt;json_base64&gt; /request-id &lt;request_id&gt; /PORT=&lt;port_number&gt; [--debug /timeout=&lt;timeout in ms, default=1000&gt; /retry=&lt;retry_times, default=5&gt; /MASTER=&lt;ip, default=localhost&gt; --startups &lt;packageNames, default=&quot;&quot;&gt; /entry=&lt;function_name, default=run&gt; --attach &lt;debug_pkg_dir&gt;]
''' ```
''' Create a R# cluster node for run background or parallel task. This IPC command will run a R# script file that specified by the ``/exec`` argument, and then post back the result data json to the specific master listener.
''' </summary>
'''
''' <param name="exec"> a specific R# script for run as background task.
''' </param>
''' <param name="args"> The base64 text of the input arguments for running current R# script file, this is a json encoded text of the arguments. the json object should be a collection of [key =&gt; value[]] pairs.
''' </param>
''' <param name="entry"> the entry function name, by default is running the script from the begining to ends.
''' </param>
''' <param name="request_id"> the unique id for identify current slave progress in the master node when invoke post data callback.
''' </param>
''' <param name="MASTER"> the ip address of the master node, by default this parameter value is ``localhost``.
''' </param>
''' <param name="PORT"> the port number for master node listen to this callback post data.
''' </param>
''' <param name="retry"> How many times that this cluster node should retry to send callback data if the TCP request timeout.
''' </param>
''' <param name="startups"> A list of package names for load during the current slave process startup.
''' </param>
Public Function slaveMode(exec As String, 
                             args As String, 
                             request_id As String, 
                             PORT As String, 
                             Optional timeout As String = "1000", 
                             Optional retry As String = "5", 
                             Optional master As String = "localhost", 
                             Optional startups As String = "", 
                             Optional entry As String = "run", 
                             Optional attach As String = "", 
                             Optional debug As Boolean = False) As Integer
Dim cli = GetslaveModeCommandLine(exec:=exec, 
                             args:=args, 
                             request_id:=request_id, 
                             PORT:=PORT, 
                             timeout:=timeout, 
                             retry:=retry, 
                             master:=master, 
                             startups:=startups, 
                             entry:=entry, 
                             attach:=attach, 
                             debug:=debug, internal_pipelineMode:=True)
    Dim proc As IIORedirectAbstract = RunDotNetApp(cli)
    Return proc.Run()
End Function
Public Function GetslaveModeCommandLine(exec As String, 
                             args As String, 
                             request_id As String, 
                             PORT As String, 
                             Optional timeout As String = "1000", 
                             Optional retry As String = "5", 
                             Optional master As String = "localhost", 
                             Optional startups As String = "", 
                             Optional entry As String = "run", 
                             Optional attach As String = "", 
                             Optional debug As Boolean = False, Optional internal_pipelineMode As Boolean = True) As String
    Dim CLI As New StringBuilder("--slave")
    Call CLI.Append(" ")
    Call CLI.Append("/exec " & """" & exec & """ ")
    Call CLI.Append("/args " & """" & args & """ ")
    Call CLI.Append("/request-id " & """" & request_id & """ ")
    Call CLI.Append("/PORT " & """" & PORT & """ ")
    If Not timeout.StringEmpty Then
            Call CLI.Append("/timeout " & """" & timeout & """ ")
    End If
    If Not retry.StringEmpty Then
            Call CLI.Append("/retry " & """" & retry & """ ")
    End If
    If Not master.StringEmpty Then
            Call CLI.Append("/master " & """" & master & """ ")
    End If
    If Not startups.StringEmpty Then
            Call CLI.Append("--startups " & """" & startups & """ ")
    End If
    If Not entry.StringEmpty Then
            Call CLI.Append("/entry " & """" & entry & """ ")
    End If
    If Not attach.StringEmpty Then
            Call CLI.Append("--attach " & """" & attach & """ ")
    End If
    If debug Then
        Call CLI.Append("--debug ")
    End If
     Call CLI.Append($"/@set --internal_pipeline={internal_pipelineMode.ToString.ToUpper()} ")


Return CLI.ToString()
End Function
End Class
End Namespace
