Namespace RichEditAPISample
	Partial Public Class DisplayResultControl
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.richEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
			Me.dockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
			Me.dockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
			Me.dockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
			Me.richEditCommentControl1 = New DevExpress.XtraRichEdit.RichEditCommentControl()
			Me.hideContainerLeft = New DevExpress.XtraBars.Docking.AutoHideContainer()
			CType(Me.dockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.dockPanel1.SuspendLayout()
			Me.dockPanel1_Container.SuspendLayout()
			Me.SuspendLayout()
			' 
			' richEditControl1
			' 
			Me.richEditControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.richEditControl1.EnableToolTips = True
			Me.richEditControl1.Location = New System.Drawing.Point(350, 0)
			Me.richEditControl1.Name = "richEditControl1"
			Me.richEditControl1.Size = New System.Drawing.Size(450, 600)
			Me.richEditControl1.TabIndex = 0
			Me.richEditControl1.Text = "richEditControl1"
			' 
			' dockManager1
			' 
			Me.dockManager1.Form = Me
			Me.dockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() { Me.dockPanel1})
			Me.dockManager1.TopZIndexControls.AddRange(New String() { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane"})
			' 
			' dockPanel1
			' 
			Me.dockPanel1.Controls.Add(Me.dockPanel1_Container)
			Me.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
			Me.dockPanel1.ID = New System.Guid("04db9aca-9506-4fd9-a2cc-9ef27d6a5592")
			Me.dockPanel1.Location = New System.Drawing.Point(0, 0)
			Me.dockPanel1.Name = "dockPanel1"
			Me.dockPanel1.OriginalSize = New System.Drawing.Size(350, 200)
			Me.dockPanel1.Size = New System.Drawing.Size(350, 600)
			Me.dockPanel1.Text = "Main document comments"
			' 
			' dockPanel1_Container
			' 
			Me.dockPanel1_Container.Controls.Add(Me.richEditCommentControl1)
			Me.dockPanel1_Container.Location = New System.Drawing.Point(4, 23)
			Me.dockPanel1_Container.Name = "dockPanel1_Container"
			Me.dockPanel1_Container.Size = New System.Drawing.Size(342, 573)
			Me.dockPanel1_Container.TabIndex = 0
			' 
			' richEditCommentControl1
			' 
			Me.richEditCommentControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
			Me.richEditCommentControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.richEditCommentControl1.Location = New System.Drawing.Point(0, 0)
			Me.richEditCommentControl1.Name = "richEditCommentControl1"
			Me.richEditCommentControl1.ReadOnly = True
			Me.richEditCommentControl1.RichEditControl = Me.richEditControl1
			Me.richEditCommentControl1.RichEditControl.EnableToolTips = True
			Me.richEditCommentControl1.RichEditControl.Options.RangePermissions.Visibility = DevExpress.XtraRichEdit.RichEditRangePermissionVisibility.Hidden
			Me.richEditCommentControl1.Size = New System.Drawing.Size(342, 573)
			Me.richEditCommentControl1.TabIndex = 0
			Me.richEditCommentControl1.RichEditControl.UseDeferredDataBindingNotifications = False
			' 
			' hideContainerLeft
			' 
			Me.hideContainerLeft.BackColor = System.Drawing.SystemColors.Control
			Me.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left
			Me.hideContainerLeft.Location = New System.Drawing.Point(0, 0)
			Me.hideContainerLeft.Name = "hideContainerLeft"
			Me.hideContainerLeft.Size = New System.Drawing.Size(19, 300)
			' 
			' DisplayResultControl
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.richEditControl1)
			Me.Controls.Add(Me.dockPanel1)
			Me.Name = "DisplayResultControl"
			Me.Size = New System.Drawing.Size(800, 600)
			CType(Me.dockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.dockPanel1.ResumeLayout(False)
			Me.dockPanel1_Container.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private richEditControl1 As DevExpress.XtraRichEdit.RichEditControl
		Private dockManager1 As DevExpress.XtraBars.Docking.DockManager
		Private dockPanel1 As DevExpress.XtraBars.Docking.DockPanel
		Private dockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
		Private richEditCommentControl1 As DevExpress.XtraRichEdit.RichEditCommentControl
		Private hideContainerLeft As DevExpress.XtraBars.Docking.AutoHideContainer
	End Class
End Namespace
