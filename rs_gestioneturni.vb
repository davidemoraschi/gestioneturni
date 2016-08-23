﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.0.3705.0
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Xml


<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Diagnostics.DebuggerStepThrough(),  _
 System.ComponentModel.ToolboxItem(true)>  _
Public Class rs_gestioneturni
    Inherits DataSet
    
    Private tableItin As ItinDataTable
    
    Public Sub New()
        MyBase.New
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(System.String)),String)
        If (Not (strSchema) Is Nothing) Then
            Dim ds As DataSet = New DataSet
            ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("Itin")) Is Nothing) Then
                Me.Tables.Add(New ItinDataTable(ds.Tables("Itin")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.InitClass
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property Itin As ItinDataTable
        Get
            Return Me.tableItin
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As rs_gestioneturni = CType(MyBase.Clone,rs_gestioneturni)
        cln.InitVars
        Return cln
    End Function
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
        Me.Reset
        Dim ds As DataSet = New DataSet
        ds.ReadXml(reader)
        If (Not (ds.Tables("Itin")) Is Nothing) Then
            Me.Tables.Add(New ItinDataTable(ds.Tables("Itin")))
        End If
        Me.DataSetName = ds.DataSetName
        Me.Prefix = ds.Prefix
        Me.Namespace = ds.Namespace
        Me.Locale = ds.Locale
        Me.CaseSensitive = ds.CaseSensitive
        Me.EnforceConstraints = ds.EnforceConstraints
        Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
        Me.InitVars
    End Sub
    
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
    End Function
    
    Friend Sub InitVars()
        Me.tableItin = CType(Me.Tables("Itin"),ItinDataTable)
        If (Not (Me.tableItin) Is Nothing) Then
            Me.tableItin.InitVars
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "rs_gestioneturni"
        Me.Prefix = ""
        Me.Namespace = "http://www.tempuri.org/rs_gestioneturni.xsd"
        Me.Locale = New System.Globalization.CultureInfo("it-IT")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableItin = New ItinDataTable
        Me.Tables.Add(Me.tableItin)
    End Sub
    
    Private Function ShouldSerializeItin() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub ItinRowChangeEventHandler(ByVal sender As Object, ByVal e As ItinRowChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class ItinDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnItinID As DataColumn
        
        Private columnStartDate As DataColumn
        
        Private columnStartTime As DataColumn
        
        Private columnVenue As DataColumn
        
        Private columnCity As DataColumn
        
        Private columnState As DataColumn
        
        Private columnCountry As DataColumn
        
        Private columnDateAdded As DataColumn
        
        Friend Sub New()
            MyBase.New("Itin")
            Me.InitClass
        End Sub
        
        Friend Sub New(ByVal table As DataTable)
            MyBase.New(table.TableName)
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
            Me.DisplayExpression = table.DisplayExpression
        End Sub
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Friend ReadOnly Property ItinIDColumn As DataColumn
            Get
                Return Me.columnItinID
            End Get
        End Property
        
        Friend ReadOnly Property StartDateColumn As DataColumn
            Get
                Return Me.columnStartDate
            End Get
        End Property
        
        Friend ReadOnly Property StartTimeColumn As DataColumn
            Get
                Return Me.columnStartTime
            End Get
        End Property
        
        Friend ReadOnly Property VenueColumn As DataColumn
            Get
                Return Me.columnVenue
            End Get
        End Property
        
        Friend ReadOnly Property CityColumn As DataColumn
            Get
                Return Me.columnCity
            End Get
        End Property
        
        Friend ReadOnly Property StateColumn As DataColumn
            Get
                Return Me.columnState
            End Get
        End Property
        
        Friend ReadOnly Property CountryColumn As DataColumn
            Get
                Return Me.columnCountry
            End Get
        End Property
        
        Friend ReadOnly Property DateAddedColumn As DataColumn
            Get
                Return Me.columnDateAdded
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As ItinRow
            Get
                Return CType(Me.Rows(index),ItinRow)
            End Get
        End Property
        
        Public Event ItinRowChanged As ItinRowChangeEventHandler
        
        Public Event ItinRowChanging As ItinRowChangeEventHandler
        
        Public Event ItinRowDeleted As ItinRowChangeEventHandler
        
        Public Event ItinRowDeleting As ItinRowChangeEventHandler
        
        Public Overloads Sub AddItinRow(ByVal row As ItinRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddItinRow(ByVal StartDate As Date, ByVal StartTime As Date, ByVal Venue As String, ByVal City As String, ByVal State As String, ByVal Country As String, ByVal DateAdded As Date) As ItinRow
            Dim rowItinRow As ItinRow = CType(Me.NewRow,ItinRow)
            rowItinRow.ItemArray = New Object() {Nothing, StartDate, StartTime, Venue, City, State, Country, DateAdded}
            Me.Rows.Add(rowItinRow)
            Return rowItinRow
        End Function
        
        Public Function FindByItinID(ByVal ItinID As Integer) As ItinRow
            Return CType(Me.Rows.Find(New Object() {ItinID}),ItinRow)
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As ItinDataTable = CType(MyBase.Clone,ItinDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New ItinDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnItinID = Me.Columns("ItinID")
            Me.columnStartDate = Me.Columns("StartDate")
            Me.columnStartTime = Me.Columns("StartTime")
            Me.columnVenue = Me.Columns("Venue")
            Me.columnCity = Me.Columns("City")
            Me.columnState = Me.Columns("State")
            Me.columnCountry = Me.Columns("Country")
            Me.columnDateAdded = Me.Columns("DateAdded")
        End Sub
        
        Private Sub InitClass()
            Me.columnItinID = New DataColumn("ItinID", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnItinID)
            Me.columnStartDate = New DataColumn("StartDate", GetType(System.DateTime), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnStartDate)
            Me.columnStartTime = New DataColumn("StartTime", GetType(System.DateTime), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnStartTime)
            Me.columnVenue = New DataColumn("Venue", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnVenue)
            Me.columnCity = New DataColumn("City", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnCity)
            Me.columnState = New DataColumn("State", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnState)
            Me.columnCountry = New DataColumn("Country", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnCountry)
            Me.columnDateAdded = New DataColumn("DateAdded", GetType(System.DateTime), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnDateAdded)
            Me.Constraints.Add(New UniqueConstraint("Constraint1", New DataColumn() {Me.columnItinID}, true))
            Me.columnItinID.AutoIncrement = true
            Me.columnItinID.AllowDBNull = false
            Me.columnItinID.ReadOnly = true
            Me.columnItinID.Unique = true
            Me.columnDateAdded.AllowDBNull = false
        End Sub
        
        Public Function NewItinRow() As ItinRow
            Return CType(Me.NewRow,ItinRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New ItinRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(ItinRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.ItinRowChangedEvent) Is Nothing) Then
                RaiseEvent ItinRowChanged(Me, New ItinRowChangeEvent(CType(e.Row,ItinRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.ItinRowChangingEvent) Is Nothing) Then
                RaiseEvent ItinRowChanging(Me, New ItinRowChangeEvent(CType(e.Row,ItinRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.ItinRowDeletedEvent) Is Nothing) Then
                RaiseEvent ItinRowDeleted(Me, New ItinRowChangeEvent(CType(e.Row,ItinRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.ItinRowDeletingEvent) Is Nothing) Then
                RaiseEvent ItinRowDeleting(Me, New ItinRowChangeEvent(CType(e.Row,ItinRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveItinRow(ByVal row As ItinRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class ItinRow
        Inherits DataRow
        
        Private tableItin As ItinDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableItin = CType(Me.Table,ItinDataTable)
        End Sub
        
        Public Property ItinID As Integer
            Get
                Return CType(Me(Me.tableItin.ItinIDColumn),Integer)
            End Get
            Set
                Me(Me.tableItin.ItinIDColumn) = value
            End Set
        End Property
        
        Public Property StartDate As Date
            Get
                Try 
                    Return CType(Me(Me.tableItin.StartDateColumn),Date)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableItin.StartDateColumn) = value
            End Set
        End Property
        
        Public Property StartTime As Date
            Get
                Try 
                    Return CType(Me(Me.tableItin.StartTimeColumn),Date)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableItin.StartTimeColumn) = value
            End Set
        End Property
        
        Public Property Venue As String
            Get
                Try 
                    Return CType(Me(Me.tableItin.VenueColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableItin.VenueColumn) = value
            End Set
        End Property
        
        Public Property City As String
            Get
                Try 
                    Return CType(Me(Me.tableItin.CityColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableItin.CityColumn) = value
            End Set
        End Property
        
        Public Property State As String
            Get
                Try 
                    Return CType(Me(Me.tableItin.StateColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableItin.StateColumn) = value
            End Set
        End Property
        
        Public Property Country As String
            Get
                Try 
                    Return CType(Me(Me.tableItin.CountryColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableItin.CountryColumn) = value
            End Set
        End Property
        
        Public Property DateAdded As Date
            Get
                Return CType(Me(Me.tableItin.DateAddedColumn),Date)
            End Get
            Set
                Me(Me.tableItin.DateAddedColumn) = value
            End Set
        End Property
        
        Public Function IsStartDateNull() As Boolean
            Return Me.IsNull(Me.tableItin.StartDateColumn)
        End Function
        
        Public Sub SetStartDateNull()
            Me(Me.tableItin.StartDateColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsStartTimeNull() As Boolean
            Return Me.IsNull(Me.tableItin.StartTimeColumn)
        End Function
        
        Public Sub SetStartTimeNull()
            Me(Me.tableItin.StartTimeColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsVenueNull() As Boolean
            Return Me.IsNull(Me.tableItin.VenueColumn)
        End Function
        
        Public Sub SetVenueNull()
            Me(Me.tableItin.VenueColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsCityNull() As Boolean
            Return Me.IsNull(Me.tableItin.CityColumn)
        End Function
        
        Public Sub SetCityNull()
            Me(Me.tableItin.CityColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsStateNull() As Boolean
            Return Me.IsNull(Me.tableItin.StateColumn)
        End Function
        
        Public Sub SetStateNull()
            Me(Me.tableItin.StateColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsCountryNull() As Boolean
            Return Me.IsNull(Me.tableItin.CountryColumn)
        End Function
        
        Public Sub SetCountryNull()
            Me(Me.tableItin.CountryColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class ItinRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As ItinRow
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As ItinRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As ItinRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        Public ReadOnly Property Action As DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class