﻿#Region "Microsoft.VisualBasic::48777c24a6deb3e8cca41de48515647e, markdown2pdf\ReportBuilder\HTML\BuilderHelpers.vb"

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

    '     Module BuilderHelpers
    ' 
    '         Function: Hide, Show
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices

Namespace HTML

    Public Module BuilderHelpers

        <Extension>
        Public Function Show(report As HTMLReport, sectionBegin$, sectionEnd$) As HTMLReport
            Call report.Replace(sectionBegin, "")
            Call report.Replace(sectionEnd, "")

            Return report
        End Function

        ''' <summary>
        ''' 将目标区域注释掉，注意如果这个区域内还存在其他的html注释标签，则当前的html注释操作将会失败
        ''' </summary>
        ''' <param name="report"></param>
        ''' <param name="sectionBegin$"></param>
        ''' <param name="sectionEnd$"></param>
        ''' <returns></returns>
        <Extension>
        Public Function Hide(report As HTMLReport, sectionBegin$, sectionEnd$) As HTMLReport
            Call report.Replace(sectionBegin, "<!--")
            Call report.Replace(sectionEnd, "-->")

            Return report
        End Function
    End Module
End Namespace
