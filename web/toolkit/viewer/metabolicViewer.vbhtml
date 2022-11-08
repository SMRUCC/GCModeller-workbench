<!doctype html>
<html lang="en">

<?vb $title = "Metabolic Model Viewer" ?>
<?vb $app = "metabolic_viewer" ?>

<head>
    <%= ../../assets/includes/head.vbhtml %>
</head>

<body>

    <div class="container-fluid container">

        <h1>View Metabolic Network Model</h1>


        <div class="row">
            <div class="col-auto">
                <h3>Select subcellular location:</h3>

                <select id="compartment_list" class="form-control select-input placeholder-active active">

                </select>

            </div>
        </div>

        <br /><br />

        <div class="row">
            <div id="enzyme-class" class="col-4" style="width: 400px;height:400px;">

            </div>

            <div class="col-8" id="container" style="height: 500px;">
                <!-- the graph canvas container -->
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <div class="row">
                    <div class="col-4">
                        <div class="alert alert-success" role="alert" data-mdb-color="success">
                            <i class="fas fa-check-circle me-3"></i>
                            <span id="number_reactions"></span> enzymatic reactions is annotated!
                        </div>
                    </div>
                </div>
                <br />

                <ul id="reaction-graph-data">

                </ul>
            </div>
        </div>

        <%= ../../assets/includes/webapp.vbhtml %>

            <script src="/javascript/viewer.min.js" type="text/javascript"></script>
            <script src="/javascript/echarts-5.4.0/echarts.min.js" type="text/javascript"></script>
    </div>

</body>

</html>