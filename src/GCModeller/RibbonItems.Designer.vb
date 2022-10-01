'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports RibbonLib
Imports RibbonLib.Controls
Imports RibbonLib.Interop

Namespace RibbonLib.Controls
    Partial Class RibbonItems
        Private Class Cmd
            Public Const CmdApplicationMenu As UInteger = 56
            Public Const CmdRecentItems As UInteger = 57
            Public Const CmdNew As UInteger = 58
            Public Const CmdOpen As UInteger = 59
            Public Const CmdSave As UInteger = 60
            Public Const CmdSaveAsMore As UInteger = 62
            Public Const CmdSaveAs As UInteger = 61
            Public Const CmdHeaderSave As UInteger = 63
            Public Const CmdRichTextDocument As UInteger = 64
            Public Const CmdOfficeOpenXMLDocument As UInteger = 65
            Public Const CmdOpenDocumentText As UInteger = 66
            Public Const CmdPlainTextDocument As UInteger = 67
            Public Const CmdOtherFormats As UInteger = 68
            Public Const CmdPrintMore As UInteger = 70
            Public Const CmdPrint As UInteger = 69
            Public Const CmdHeaderPrint As UInteger = 71
            Public Const CmdQuickPrint As UInteger = 72
            Public Const CmdPrintPreview As UInteger = 73
            Public Const CmdPageSetup As UInteger = 74
            Public Const CmdEmail As UInteger = 75
            Public Const CmdAbout As UInteger = 76
            Public Const CmdExit As UInteger = 77
            Public Const CmdHelp As UInteger = 90
            Public Const CmdQuickAccessToolbar As UInteger = 87
            Public Const CmdUndo As UInteger = 88
            Public Const CmdRedo As UInteger = 89
            Public Const CmdTabHome As UInteger = 2
            Public Const CmdGroupClipboard As UInteger = 3
            Public Const CmdPasteMore As UInteger = 6
            Public Const CmdPaste As UInteger = 4
            Public Const CmdPasteSpecial As UInteger = 5
            Public Const CmdCut As UInteger = 7
            Public Const CmdCopy As UInteger = 8
            Public Const CmdGroupFont As UInteger = 9
            Public Const CmdFont As UInteger = 10
            Public Const CmdGroupParagraph As UInteger = 11
            Public Const CmdOutdent As UInteger = 12
            Public Const CmdIndent As UInteger = 13
            Public Const CmdList As UInteger = 14
            Public Const CmdLineSpacing As UInteger = 15
            Public Const CmdLineSpacing1_0 As UInteger = 16
            Public Const CmdLineSpacing1_15 As UInteger = 17
            Public Const CmdLineSpacing1_5 As UInteger = 18
            Public Const CmdLineSpacing2 As UInteger = 19
            Public Const CmdLineSpacingAfter As UInteger = 20
            Public Const CmdAlignLeft As UInteger = 21
            Public Const CmdAlignCenter As UInteger = 22
            Public Const CmdAlignRight As UInteger = 23
            Public Const CmdAlignJustify As UInteger = 24
            Public Const CmdParagraph As UInteger = 25
            Public Const CmdGroupInsert As UInteger = 26
            Public Const CmdInsertPictureMore As UInteger = 28
            Public Const CmdInsertPicture As UInteger = 27
            Public Const CmdChangePicture As UInteger = 29
            Public Const CmdResizePicture As UInteger = 30
            Public Const CmdPaintDrawing As UInteger = 31
            Public Const CmdDateAndTime As UInteger = 32
            Public Const CmdInsertObject As UInteger = 33
            Public Const CmdGroupEditing As UInteger = 34
            Public Const CmdFind As UInteger = 35
            Public Const CmdReplace As UInteger = 36
            Public Const CmdSelectAll As UInteger = 37
            Public Const CmdTabView As UInteger = 38
            Public Const CmdGroupZoom As UInteger = 39
            Public Const CmdZoomIn As UInteger = 40
            Public Const CmdZoomOut As UInteger = 41
            Public Const CmdZoom100Percent As UInteger = 42
            Public Const CmdGroupShowOrHide As UInteger = 43
            Public Const CmdRuler As UInteger = 44
            Public Const CmdStatusBar As UInteger = 45
            Public Const CmdGroupSettings As UInteger = 46
            Public Const CmdWordWrap As UInteger = 47
            Public Const CmdNoWrap As UInteger = 48
            Public Const CmdWrapToWindow As UInteger = 49
            Public Const CmdWrapToRuler As UInteger = 50
            Public Const CmdMeasurementUnits As UInteger = 51
            Public Const CmdInches As UInteger = 52
            Public Const CmdCentimeters As UInteger = 53
            Public Const CmdPoints As UInteger = 54
            Public Const CmdPicas As UInteger = 55
            Public Const CmdTabPrintPreview As UInteger = 78
            Public Const CmdGroupPrint As UInteger = 79
            Public Const CmdViewOnePage As UInteger = 80
            Public Const CmdViewTwoPages As UInteger = 81
            Public Const CmdGroupPreview As UInteger = 82
            Public Const CmdPreviousPage As UInteger = 83
            Public Const CmdNextPage As UInteger = 84
            Public Const CmdGroupClose As UInteger = 85
            Public Const CmdClosePrintPreview As UInteger = 86
            Public Const CmdObjectProperties As UInteger = 93
            Public Const CmdOpenObject As UInteger = 94
            Public Const CmdLinks As UInteger = 95
            Public Const CmdContextPopupEditText As UInteger = 91
            Public Const CmdContextPopupEditPicture As UInteger = 92
            Public Const CmdContextPopupObject As UInteger = 96
        End Class

        ' ContextPopup CommandName
        Public Const CmdContextPopupEditText As UInteger = Cmd.CmdContextPopupEditText
        Public Const CmdContextPopupEditPicture As UInteger = Cmd.CmdContextPopupEditPicture
        Public Const CmdContextPopupObject As UInteger = Cmd.CmdContextPopupObject

        Private _ribbon As Ribbon
        Public ReadOnly Property Ribbon As Ribbon
            Get
                Return _ribbon
            End Get
        End Property
        Private _ApplicationMenu As RibbonApplicationMenu
        Public ReadOnly Property ApplicationMenu As RibbonApplicationMenu
            Get
                Return _ApplicationMenu
            End Get
        End Property
        Private _RecentItems As RibbonRecentItems
        Public ReadOnly Property RecentItems As RibbonRecentItems
            Get
                Return _RecentItems
            End Get
        End Property
        Private _New As RibbonButton
        Public ReadOnly Property [New] As RibbonButton
            Get
                Return _New
            End Get
        End Property
        Private _Open As RibbonButton
        Public ReadOnly Property Open As RibbonButton
            Get
                Return _Open
            End Get
        End Property
        Private _Save As RibbonButton
        Public ReadOnly Property Save As RibbonButton
            Get
                Return _Save
            End Get
        End Property
        Private _SaveAsMore As RibbonSplitButton
        Public ReadOnly Property SaveAsMore As RibbonSplitButton
            Get
                Return _SaveAsMore
            End Get
        End Property
        Private _SaveAs As RibbonButton
        Public ReadOnly Property SaveAs As RibbonButton
            Get
                Return _SaveAs
            End Get
        End Property
        Private _HeaderSave As RibbonMenuGroup
        Public ReadOnly Property HeaderSave As RibbonMenuGroup
            Get
                Return _HeaderSave
            End Get
        End Property
        Private _RichTextDocument As RibbonButton
        Public ReadOnly Property RichTextDocument As RibbonButton
            Get
                Return _RichTextDocument
            End Get
        End Property
        Private _OfficeOpenXMLDocument As RibbonButton
        Public ReadOnly Property OfficeOpenXMLDocument As RibbonButton
            Get
                Return _OfficeOpenXMLDocument
            End Get
        End Property
        Private _OpenDocumentText As RibbonButton
        Public ReadOnly Property OpenDocumentText As RibbonButton
            Get
                Return _OpenDocumentText
            End Get
        End Property
        Private _PlainTextDocument As RibbonButton
        Public ReadOnly Property PlainTextDocument As RibbonButton
            Get
                Return _PlainTextDocument
            End Get
        End Property
        Private _OtherFormats As RibbonButton
        Public ReadOnly Property OtherFormats As RibbonButton
            Get
                Return _OtherFormats
            End Get
        End Property
        Private _PrintMore As RibbonSplitButton
        Public ReadOnly Property PrintMore As RibbonSplitButton
            Get
                Return _PrintMore
            End Get
        End Property
        Private _Print As RibbonButton
        Public ReadOnly Property Print As RibbonButton
            Get
                Return _Print
            End Get
        End Property
        Private _HeaderPrint As RibbonMenuGroup
        Public ReadOnly Property HeaderPrint As RibbonMenuGroup
            Get
                Return _HeaderPrint
            End Get
        End Property
        Private _QuickPrint As RibbonButton
        Public ReadOnly Property QuickPrint As RibbonButton
            Get
                Return _QuickPrint
            End Get
        End Property
        Private _PrintPreview As RibbonButton
        Public ReadOnly Property PrintPreview As RibbonButton
            Get
                Return _PrintPreview
            End Get
        End Property
        Private _PageSetup As RibbonButton
        Public ReadOnly Property PageSetup As RibbonButton
            Get
                Return _PageSetup
            End Get
        End Property
        Private _Email As RibbonButton
        Public ReadOnly Property Email As RibbonButton
            Get
                Return _Email
            End Get
        End Property
        Private _About As RibbonButton
        Public ReadOnly Property About As RibbonButton
            Get
                Return _About
            End Get
        End Property
        Private _Exit As RibbonButton
        Public ReadOnly Property [Exit] As RibbonButton
            Get
                Return _Exit
            End Get
        End Property
        Private _Help As RibbonHelpButton
        Public ReadOnly Property Help As RibbonHelpButton
            Get
                Return _Help
            End Get
        End Property
        Private _QuickAccessToolbar As RibbonQuickAccessToolbar
        Public ReadOnly Property QuickAccessToolbar As RibbonQuickAccessToolbar
            Get
                Return _QuickAccessToolbar
            End Get
        End Property
        Private _Undo As RibbonButton
        Public ReadOnly Property Undo As RibbonButton
            Get
                Return _Undo
            End Get
        End Property
        Private _Redo As RibbonButton
        Public ReadOnly Property Redo As RibbonButton
            Get
                Return _Redo
            End Get
        End Property
        Private _TabHome As RibbonTab
        Public ReadOnly Property TabHome As RibbonTab
            Get
                Return _TabHome
            End Get
        End Property
        Private _GroupClipboard As RibbonGroup
        Public ReadOnly Property GroupClipboard As RibbonGroup
            Get
                Return _GroupClipboard
            End Get
        End Property
        Private _PasteMore As RibbonSplitButton
        Public ReadOnly Property PasteMore As RibbonSplitButton
            Get
                Return _PasteMore
            End Get
        End Property
        Private _Paste As RibbonButton
        Public ReadOnly Property Paste As RibbonButton
            Get
                Return _Paste
            End Get
        End Property
        Private _PasteSpecial As RibbonButton
        Public ReadOnly Property PasteSpecial As RibbonButton
            Get
                Return _PasteSpecial
            End Get
        End Property
        Private _Cut As RibbonButton
        Public ReadOnly Property Cut As RibbonButton
            Get
                Return _Cut
            End Get
        End Property
        Private _Copy As RibbonButton
        Public ReadOnly Property Copy As RibbonButton
            Get
                Return _Copy
            End Get
        End Property
        Private _GroupFont As RibbonGroup
        Public ReadOnly Property GroupFont As RibbonGroup
            Get
                Return _GroupFont
            End Get
        End Property
        Private _Font As RibbonFontControl
        Public ReadOnly Property Font As RibbonFontControl
            Get
                Return _Font
            End Get
        End Property
        Private _GroupParagraph As RibbonGroup
        Public ReadOnly Property GroupParagraph As RibbonGroup
            Get
                Return _GroupParagraph
            End Get
        End Property
        Private _Outdent As RibbonButton
        Public ReadOnly Property Outdent As RibbonButton
            Get
                Return _Outdent
            End Get
        End Property
        Private _Indent As RibbonButton
        Public ReadOnly Property Indent As RibbonButton
            Get
                Return _Indent
            End Get
        End Property
        Private _List As RibbonSplitButtonGallery
        Public ReadOnly Property List As RibbonSplitButtonGallery
            Get
                Return _List
            End Get
        End Property
        Private _LineSpacing As RibbonDropDownButton
        Public ReadOnly Property LineSpacing As RibbonDropDownButton
            Get
                Return _LineSpacing
            End Get
        End Property
        Private _LineSpacing1_0 As RibbonToggleButton
        Public ReadOnly Property LineSpacing1_0 As RibbonToggleButton
            Get
                Return _LineSpacing1_0
            End Get
        End Property
        Private _LineSpacing1_15 As RibbonToggleButton
        Public ReadOnly Property LineSpacing1_15 As RibbonToggleButton
            Get
                Return _LineSpacing1_15
            End Get
        End Property
        Private _LineSpacing1_5 As RibbonToggleButton
        Public ReadOnly Property LineSpacing1_5 As RibbonToggleButton
            Get
                Return _LineSpacing1_5
            End Get
        End Property
        Private _LineSpacing2 As RibbonToggleButton
        Public ReadOnly Property LineSpacing2 As RibbonToggleButton
            Get
                Return _LineSpacing2
            End Get
        End Property
        Private _LineSpacingAfter As RibbonToggleButton
        Public ReadOnly Property LineSpacingAfter As RibbonToggleButton
            Get
                Return _LineSpacingAfter
            End Get
        End Property
        Private _AlignLeft As RibbonToggleButton
        Public ReadOnly Property AlignLeft As RibbonToggleButton
            Get
                Return _AlignLeft
            End Get
        End Property
        Private _AlignCenter As RibbonToggleButton
        Public ReadOnly Property AlignCenter As RibbonToggleButton
            Get
                Return _AlignCenter
            End Get
        End Property
        Private _AlignRight As RibbonToggleButton
        Public ReadOnly Property AlignRight As RibbonToggleButton
            Get
                Return _AlignRight
            End Get
        End Property
        Private _AlignJustify As RibbonToggleButton
        Public ReadOnly Property AlignJustify As RibbonToggleButton
            Get
                Return _AlignJustify
            End Get
        End Property
        Private _Paragraph As RibbonButton
        Public ReadOnly Property Paragraph As RibbonButton
            Get
                Return _Paragraph
            End Get
        End Property
        Private _GroupInsert As RibbonGroup
        Public ReadOnly Property GroupInsert As RibbonGroup
            Get
                Return _GroupInsert
            End Get
        End Property
        Private _InsertPictureMore As RibbonSplitButton
        Public ReadOnly Property InsertPictureMore As RibbonSplitButton
            Get
                Return _InsertPictureMore
            End Get
        End Property
        Private _InsertPicture As RibbonButton
        Public ReadOnly Property InsertPicture As RibbonButton
            Get
                Return _InsertPicture
            End Get
        End Property
        Private _ChangePicture As RibbonButton
        Public ReadOnly Property ChangePicture As RibbonButton
            Get
                Return _ChangePicture
            End Get
        End Property
        Private _ResizePicture As RibbonButton
        Public ReadOnly Property ResizePicture As RibbonButton
            Get
                Return _ResizePicture
            End Get
        End Property
        Private _PaintDrawing As RibbonButton
        Public ReadOnly Property PaintDrawing As RibbonButton
            Get
                Return _PaintDrawing
            End Get
        End Property
        Private _DateAndTime As RibbonButton
        Public ReadOnly Property DateAndTime As RibbonButton
            Get
                Return _DateAndTime
            End Get
        End Property
        Private _InsertObject As RibbonButton
        Public ReadOnly Property InsertObject As RibbonButton
            Get
                Return _InsertObject
            End Get
        End Property
        Private _GroupEditing As RibbonGroup
        Public ReadOnly Property GroupEditing As RibbonGroup
            Get
                Return _GroupEditing
            End Get
        End Property
        Private _Find As RibbonButton
        Public ReadOnly Property Find As RibbonButton
            Get
                Return _Find
            End Get
        End Property
        Private _Replace As RibbonButton
        Public ReadOnly Property Replace As RibbonButton
            Get
                Return _Replace
            End Get
        End Property
        Private _SelectAll As RibbonButton
        Public ReadOnly Property SelectAll As RibbonButton
            Get
                Return _SelectAll
            End Get
        End Property
        Private _TabView As RibbonTab
        Public ReadOnly Property TabView As RibbonTab
            Get
                Return _TabView
            End Get
        End Property
        Private _GroupZoom As RibbonGroup
        Public ReadOnly Property GroupZoom As RibbonGroup
            Get
                Return _GroupZoom
            End Get
        End Property
        Private _ZoomIn As RibbonButton
        Public ReadOnly Property ZoomIn As RibbonButton
            Get
                Return _ZoomIn
            End Get
        End Property
        Private _ZoomOut As RibbonButton
        Public ReadOnly Property ZoomOut As RibbonButton
            Get
                Return _ZoomOut
            End Get
        End Property
        Private _Zoom100Percent As RibbonButton
        Public ReadOnly Property Zoom100Percent As RibbonButton
            Get
                Return _Zoom100Percent
            End Get
        End Property
        Private _GroupShowOrHide As RibbonGroup
        Public ReadOnly Property GroupShowOrHide As RibbonGroup
            Get
                Return _GroupShowOrHide
            End Get
        End Property
        Private _Ruler As RibbonCheckBox
        Public ReadOnly Property Ruler As RibbonCheckBox
            Get
                Return _Ruler
            End Get
        End Property
        Private _StatusBar As RibbonCheckBox
        Public ReadOnly Property StatusBar As RibbonCheckBox
            Get
                Return _StatusBar
            End Get
        End Property
        Private _GroupSettings As RibbonGroup
        Public ReadOnly Property GroupSettings As RibbonGroup
            Get
                Return _GroupSettings
            End Get
        End Property
        Private _WordWrap As RibbonDropDownButton
        Public ReadOnly Property WordWrap As RibbonDropDownButton
            Get
                Return _WordWrap
            End Get
        End Property
        Private _NoWrap As RibbonButton
        Public ReadOnly Property NoWrap As RibbonButton
            Get
                Return _NoWrap
            End Get
        End Property
        Private _WrapToWindow As RibbonButton
        Public ReadOnly Property WrapToWindow As RibbonButton
            Get
                Return _WrapToWindow
            End Get
        End Property
        Private _WrapToRuler As RibbonButton
        Public ReadOnly Property WrapToRuler As RibbonButton
            Get
                Return _WrapToRuler
            End Get
        End Property
        Private _MeasurementUnits As RibbonDropDownButton
        Public ReadOnly Property MeasurementUnits As RibbonDropDownButton
            Get
                Return _MeasurementUnits
            End Get
        End Property
        Private _Inches As RibbonButton
        Public ReadOnly Property Inches As RibbonButton
            Get
                Return _Inches
            End Get
        End Property
        Private _Centimeters As RibbonButton
        Public ReadOnly Property Centimeters As RibbonButton
            Get
                Return _Centimeters
            End Get
        End Property
        Private _Points As RibbonButton
        Public ReadOnly Property Points As RibbonButton
            Get
                Return _Points
            End Get
        End Property
        Private _Picas As RibbonButton
        Public ReadOnly Property Picas As RibbonButton
            Get
                Return _Picas
            End Get
        End Property
        Private _TabPrintPreview As RibbonTab
        Public ReadOnly Property TabPrintPreview As RibbonTab
            Get
                Return _TabPrintPreview
            End Get
        End Property
        Private _GroupPrint As RibbonGroup
        Public ReadOnly Property GroupPrint As RibbonGroup
            Get
                Return _GroupPrint
            End Get
        End Property
        Private _ViewOnePage As RibbonToggleButton
        Public ReadOnly Property ViewOnePage As RibbonToggleButton
            Get
                Return _ViewOnePage
            End Get
        End Property
        Private _ViewTwoPages As RibbonToggleButton
        Public ReadOnly Property ViewTwoPages As RibbonToggleButton
            Get
                Return _ViewTwoPages
            End Get
        End Property
        Private _GroupPreview As RibbonGroup
        Public ReadOnly Property GroupPreview As RibbonGroup
            Get
                Return _GroupPreview
            End Get
        End Property
        Private _PreviousPage As RibbonButton
        Public ReadOnly Property PreviousPage As RibbonButton
            Get
                Return _PreviousPage
            End Get
        End Property
        Private _NextPage As RibbonButton
        Public ReadOnly Property NextPage As RibbonButton
            Get
                Return _NextPage
            End Get
        End Property
        Private _GroupClose As RibbonGroup
        Public ReadOnly Property GroupClose As RibbonGroup
            Get
                Return _GroupClose
            End Get
        End Property
        Private _ClosePrintPreview As RibbonButton
        Public ReadOnly Property ClosePrintPreview As RibbonButton
            Get
                Return _ClosePrintPreview
            End Get
        End Property
        Private _ObjectProperties As RibbonButton
        Public ReadOnly Property ObjectProperties As RibbonButton
            Get
                Return _ObjectProperties
            End Get
        End Property
        Private _OpenObject As RibbonButton
        Public ReadOnly Property OpenObject As RibbonButton
            Get
                Return _OpenObject
            End Get
        End Property
        Private _Links As RibbonButton
        Public ReadOnly Property Links As RibbonButton
            Get
                Return _Links
            End Get
        End Property

        Public Sub New(ByVal ribbon As Ribbon)
            If ribbon Is Nothing Then
                Throw New ArgumentNullException(NameOf(ribbon), "Parameter is Nothing")
            End If
            _ribbon = ribbon
            _ApplicationMenu = New RibbonApplicationMenu(_ribbon, Cmd.CmdApplicationMenu)
            _RecentItems = New RibbonRecentItems(_ribbon, Cmd.CmdRecentItems)
            _New = New RibbonButton(_ribbon, Cmd.CmdNew)
            _Open = New RibbonButton(_ribbon, Cmd.CmdOpen)
            _Save = New RibbonButton(_ribbon, Cmd.CmdSave)
            _SaveAsMore = New RibbonSplitButton(_ribbon, Cmd.CmdSaveAsMore)
            _SaveAs = New RibbonButton(_ribbon, Cmd.CmdSaveAs)
            _HeaderSave = New RibbonMenuGroup(_ribbon, Cmd.CmdHeaderSave)
            _RichTextDocument = New RibbonButton(_ribbon, Cmd.CmdRichTextDocument)
            _OfficeOpenXMLDocument = New RibbonButton(_ribbon, Cmd.CmdOfficeOpenXMLDocument)
            _OpenDocumentText = New RibbonButton(_ribbon, Cmd.CmdOpenDocumentText)
            _PlainTextDocument = New RibbonButton(_ribbon, Cmd.CmdPlainTextDocument)
            _OtherFormats = New RibbonButton(_ribbon, Cmd.CmdOtherFormats)
            _PrintMore = New RibbonSplitButton(_ribbon, Cmd.CmdPrintMore)
            _Print = New RibbonButton(_ribbon, Cmd.CmdPrint)
            _HeaderPrint = New RibbonMenuGroup(_ribbon, Cmd.CmdHeaderPrint)
            _QuickPrint = New RibbonButton(_ribbon, Cmd.CmdQuickPrint)
            _PrintPreview = New RibbonButton(_ribbon, Cmd.CmdPrintPreview)
            _PageSetup = New RibbonButton(_ribbon, Cmd.CmdPageSetup)
            _Email = New RibbonButton(_ribbon, Cmd.CmdEmail)
            _About = New RibbonButton(_ribbon, Cmd.CmdAbout)
            _Exit = New RibbonButton(_ribbon, Cmd.CmdExit)
            _Help = New RibbonHelpButton(_ribbon, Cmd.CmdHelp)
            _QuickAccessToolbar = New RibbonQuickAccessToolbar(_ribbon, Cmd.CmdQuickAccessToolbar)
            _Undo = New RibbonButton(_ribbon, Cmd.CmdUndo)
            _Redo = New RibbonButton(_ribbon, Cmd.CmdRedo)
            _TabHome = New RibbonTab(_ribbon, Cmd.CmdTabHome)
            _GroupClipboard = New RibbonGroup(_ribbon, Cmd.CmdGroupClipboard)
            _PasteMore = New RibbonSplitButton(_ribbon, Cmd.CmdPasteMore)
            _Paste = New RibbonButton(_ribbon, Cmd.CmdPaste)
            _PasteSpecial = New RibbonButton(_ribbon, Cmd.CmdPasteSpecial)
            _Cut = New RibbonButton(_ribbon, Cmd.CmdCut)
            _Copy = New RibbonButton(_ribbon, Cmd.CmdCopy)
            _GroupFont = New RibbonGroup(_ribbon, Cmd.CmdGroupFont)
            _Font = New RibbonFontControl(_ribbon, Cmd.CmdFont)
            _GroupParagraph = New RibbonGroup(_ribbon, Cmd.CmdGroupParagraph)
            _Outdent = New RibbonButton(_ribbon, Cmd.CmdOutdent)
            _Indent = New RibbonButton(_ribbon, Cmd.CmdIndent)
            _List = New RibbonSplitButtonGallery(_ribbon, Cmd.CmdList)
            _LineSpacing = New RibbonDropDownButton(_ribbon, Cmd.CmdLineSpacing)
            _LineSpacing1_0 = New RibbonToggleButton(_ribbon, Cmd.CmdLineSpacing1_0)
            _LineSpacing1_15 = New RibbonToggleButton(_ribbon, Cmd.CmdLineSpacing1_15)
            _LineSpacing1_5 = New RibbonToggleButton(_ribbon, Cmd.CmdLineSpacing1_5)
            _LineSpacing2 = New RibbonToggleButton(_ribbon, Cmd.CmdLineSpacing2)
            _LineSpacingAfter = New RibbonToggleButton(_ribbon, Cmd.CmdLineSpacingAfter)
            _AlignLeft = New RibbonToggleButton(_ribbon, Cmd.CmdAlignLeft)
            _AlignCenter = New RibbonToggleButton(_ribbon, Cmd.CmdAlignCenter)
            _AlignRight = New RibbonToggleButton(_ribbon, Cmd.CmdAlignRight)
            _AlignJustify = New RibbonToggleButton(_ribbon, Cmd.CmdAlignJustify)
            _Paragraph = New RibbonButton(_ribbon, Cmd.CmdParagraph)
            _GroupInsert = New RibbonGroup(_ribbon, Cmd.CmdGroupInsert)
            _InsertPictureMore = New RibbonSplitButton(_ribbon, Cmd.CmdInsertPictureMore)
            _InsertPicture = New RibbonButton(_ribbon, Cmd.CmdInsertPicture)
            _ChangePicture = New RibbonButton(_ribbon, Cmd.CmdChangePicture)
            _ResizePicture = New RibbonButton(_ribbon, Cmd.CmdResizePicture)
            _PaintDrawing = New RibbonButton(_ribbon, Cmd.CmdPaintDrawing)
            _DateAndTime = New RibbonButton(_ribbon, Cmd.CmdDateAndTime)
            _InsertObject = New RibbonButton(_ribbon, Cmd.CmdInsertObject)
            _GroupEditing = New RibbonGroup(_ribbon, Cmd.CmdGroupEditing)
            _Find = New RibbonButton(_ribbon, Cmd.CmdFind)
            _Replace = New RibbonButton(_ribbon, Cmd.CmdReplace)
            _SelectAll = New RibbonButton(_ribbon, Cmd.CmdSelectAll)
            _TabView = New RibbonTab(_ribbon, Cmd.CmdTabView)
            _GroupZoom = New RibbonGroup(_ribbon, Cmd.CmdGroupZoom)
            _ZoomIn = New RibbonButton(_ribbon, Cmd.CmdZoomIn)
            _ZoomOut = New RibbonButton(_ribbon, Cmd.CmdZoomOut)
            _Zoom100Percent = New RibbonButton(_ribbon, Cmd.CmdZoom100Percent)
            _GroupShowOrHide = New RibbonGroup(_ribbon, Cmd.CmdGroupShowOrHide)
            _Ruler = New RibbonCheckBox(_ribbon, Cmd.CmdRuler)
            _StatusBar = New RibbonCheckBox(_ribbon, Cmd.CmdStatusBar)
            _GroupSettings = New RibbonGroup(_ribbon, Cmd.CmdGroupSettings)
            _WordWrap = New RibbonDropDownButton(_ribbon, Cmd.CmdWordWrap)
            _NoWrap = New RibbonButton(_ribbon, Cmd.CmdNoWrap)
            _WrapToWindow = New RibbonButton(_ribbon, Cmd.CmdWrapToWindow)
            _WrapToRuler = New RibbonButton(_ribbon, Cmd.CmdWrapToRuler)
            _MeasurementUnits = New RibbonDropDownButton(_ribbon, Cmd.CmdMeasurementUnits)
            _Inches = New RibbonButton(_ribbon, Cmd.CmdInches)
            _Centimeters = New RibbonButton(_ribbon, Cmd.CmdCentimeters)
            _Points = New RibbonButton(_ribbon, Cmd.CmdPoints)
            _Picas = New RibbonButton(_ribbon, Cmd.CmdPicas)
            _TabPrintPreview = New RibbonTab(_ribbon, Cmd.CmdTabPrintPreview)
            _GroupPrint = New RibbonGroup(_ribbon, Cmd.CmdGroupPrint)
            _ViewOnePage = New RibbonToggleButton(_ribbon, Cmd.CmdViewOnePage)
            _ViewTwoPages = New RibbonToggleButton(_ribbon, Cmd.CmdViewTwoPages)
            _GroupPreview = New RibbonGroup(_ribbon, Cmd.CmdGroupPreview)
            _PreviousPage = New RibbonButton(_ribbon, Cmd.CmdPreviousPage)
            _NextPage = New RibbonButton(_ribbon, Cmd.CmdNextPage)
            _GroupClose = New RibbonGroup(_ribbon, Cmd.CmdGroupClose)
            _ClosePrintPreview = New RibbonButton(_ribbon, Cmd.CmdClosePrintPreview)
            _ObjectProperties = New RibbonButton(_ribbon, Cmd.CmdObjectProperties)
            _OpenObject = New RibbonButton(_ribbon, Cmd.CmdOpenObject)
            _Links = New RibbonButton(_ribbon, Cmd.CmdLinks)
        End Sub

    End Class
End Namespace
