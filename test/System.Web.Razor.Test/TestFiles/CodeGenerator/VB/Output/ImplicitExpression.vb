'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:N.N.NNNNN.N
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System

Namespace TestOutput
Public Class ImplicitExpression
Public Sub New()
MyBase.New
End Sub
Public Overrides Sub Execute()

#ExternalSource("ImplicitExpression.vbhtml",1)
 For i = 1 To 10


#End ExternalSource
WriteLiteral("    ")

WriteLiteral("<p>This is item #")


#ExternalSource("ImplicitExpression.vbhtml",2)
                 Write(i)


#End ExternalSource
WriteLiteral("</p>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))


#ExternalSource("ImplicitExpression.vbhtml",3)
Next


#End ExternalSource
WriteLiteral(""&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))


#ExternalSource("ImplicitExpression.vbhtml",5)
Write(SyntaxSampleHelpers.CodeForLink(Me))


#End ExternalSource
End Sub
End Class
End Namespace
