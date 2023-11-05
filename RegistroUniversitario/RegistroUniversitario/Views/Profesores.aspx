<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profesores.aspx.cs" Inherits="RegistroUniversitario.Views.Profesores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>window.jQuery || document.write(decodeURIComponent('%3Cscript src="js/jquery.min.js"%3E%3C/script%3E'))</script>
    <link rel="stylesheet" type="text/css" href="https://cdn3.devexpress.com/jslib/23.1.6/css/dx.light.css" />
    <script src="https://cdn3.devexpress.com/jslib/23.1.6/js/dx.all.js"></script>


    <div class="demo-container">
        <div id="data-grid-demo">
            <div id="gridContainer"></div>
        </div>
    </div>


    <script>


        const employees = [{}];

        const states = [{}];
        $(() => {
            $('#gridContainer').dxDataGrid({
                dataSource: employees,
                keyExpr: 'ID',
                showBorders: true,
                editing: {
                    mode: 'popup',
                    allowUpdating: true,
                    allowAdding: true,
                    allowDeleting: true,
                    popup: {
                        title: 'Employee Info',
                        showTitle: true,
                        width: 700,
                        height: 525,
                    },
                    form: {
                        items: [{
                            itemType: 'group',
                            colCount: 2,
                            colSpan: 2,
                            items: ['FirstName', 'LastName', 'Prefix', 'BirthDate', 'Position', 'HireDate', {
                                dataField: 'Notes',
                                editorType: 'dxTextArea',
                                colSpan: 2,
                                editorOptions: {
                                    height: 100,
                                },
                            }],
                        }, {
                            itemType: 'group',
                            colCount: 2,
                            colSpan: 2,
                            caption: 'Home Address',
                            items: ['StateID', 'Address'],
                        }],
                    },
                },
                columns: [
                  {
                      dataField: 'Prefix',
                      caption: 'Title',
                      width: 70,
                  },
                  'FirstName',
                  'LastName',
                  {
                      dataField: 'BirthDate',
                      dataType: 'date',
                  },
                  {
                      dataField: 'Position',
                      width: 170,
                  },
                  {
                      dataField: 'HireDate',
                      dataType: 'date',
                  },
                  {
                      dataField: 'StateID',
                      caption: 'State',
                      width: 125,
                      lookup: {
                          dataSource: states,
                          displayExpr: 'Name',
                          valueExpr: 'ID',
                      },
                  },
                  {
                      dataField: 'Address',
                      visible: false,
                  },
                  {
                      dataField: 'Notes',
                      visible: false,
                  },
                ],
            });
        });

    </script>

</asp:Content>
