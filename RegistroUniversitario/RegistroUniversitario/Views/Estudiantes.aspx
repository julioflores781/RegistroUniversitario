﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="RegistroUniversitario.Views.Estudiantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>window.jQuery || document.write(decodeURIComponent('%3Cscript src="js/jquery.min.js"%3E%3C/script%3E'))</script>
    <link rel="stylesheet" type="text/css" href="https://cdn3.devexpress.com/jslib/23.1.6/css/dx.light.css" />
    <script src="https://cdn3.devexpress.com/jslib/23.1.6/js/dx.all.js"></script>
    <script src="https://unpkg.com/devextreme-aspnet-data@2.9.2/js/dx.aspnet.data.js"></script>



    <div class="demo-container">
        <div id="data-grid-demo">
            <div id="gridContainer"></div>
        </div>
    </div>


    <script>



        $(() => {

            const URL = '/api/Estudiantes';

            const srv_estudiantes = new DevExpress.data.CustomStore({
                key: 'id',
                load() {
                    return sendRequest(`${URL}/Obtener`);
                },
                insert(values) {
                    return sendRequest(`${URL}/InsertOrder`, 'POST', {
                        values: JSON.stringify(values),
                    });
                },
                update(key, values) {
                    return sendRequest(`${URL}/UpdateOrder`, 'PUT', {
                        key,
                        values: JSON.stringify(values),
                    });
                },
                remove(key) {
                    return sendRequest(`${URL}/DeleteOrder`, 'DELETE', {
                        key,
                    });
                },
            });



            $('#gridContainer').dxDataGrid({
                dataSource: DevExpress.data.AspNet.createStore({
                    key: 'id',
                    loadUrl: URL + '/Obtener'
                    , updateUrl: URL + '/Actualizar'
                    , insertUrl: URL + '/Insertar'
                    , deleteUrl: URL + '/Eliminar'
                }),
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
                            items: [ 'nombre', 'apellido', 'direccion', 'correo_electronico', 'numero_telefono']
                        }],
                    },
                },
                columns: [
                    
                    {
                        dataField: 'nombre'
                    },

                    {
                        dataField: 'apellido'

                    },
                    {
                        dataField: 'direccion',

                    },
                    {
                        dataField: 'correo_electronico'
                    },
                    {
                        dataField: 'numero_telefono'
                    }

                ],
            });
        });

    </script>

</asp:Content>
