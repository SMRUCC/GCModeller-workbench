<!doctype html>
<html lang="en">

<?vb $title = "Virtual Cell Dynamics Viewer" ?>
<?vb $app = "vcell_viewer" ?>

<head>
    <%= ../../assets/includes/head.vbhtml %>

    <meta name="counts" content="http://127.0.0.1:83/get/count/" />
    <meta name="idset" content="http://127.0.0.1:83/get/molecule_list" />
    <meta name="vector" content="http://127.0.0.1:83/get/vector" />
</head>

<body>

    <div class="container-fluid container">

        <h1>View Metabolic Network Model</h1>

	<p>
	Metabolic networks describe the relationships between small biomolecules (metabolites) and the enzymes (proteins) that interact with them to catalyze a biochemical reaction. Metabolic networks, metabolic control and modeling of metabolic networks in genome-wide reconstructed models is a central area in systems biology
	</p>


        <div class="row">
            <div class="col-auto">
                <h3>Select subcellular location:</h3>

                <select id="module_list" class="form-control select-input placeholder-active active">

                </select>

                <h3>Select subcellular location:</h3>

                <select id="molecules_list" class="form-control select-input placeholder-active active">

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
                        <div id="number-alert" style="display:none;" class="alert alert-success" role="alert" data-mdb-color="success">
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