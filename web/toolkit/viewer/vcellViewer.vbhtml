<!doctype html>
<html lang="en">

<?vb $title = "Virtual Cell Dynamics Viewer" ?>
<?vb $app = "vcell_viewer" ?>

<head>
    <%= ../../assets/includes/head.vbhtml %>

    <!-- http://localhost:19612/toolkit/viewer/vcellViewer.vbhtml?service=83 -->

        <meta name="counts" content="/get/count/" />
        <meta name="idset" content="/get/molecule_list" />
        <meta name="reactions" content="/get/reaction_list" />
        <meta name="graph" content="/get/reaction_graph" />
        <meta name="vector" content="/get/vector" />
</head>

<body>

    <div class="container-fluid container">

        <h1>View Metabolic Network Model</h1>

        <p>
            Metabolic networks describe the relationships between small biomolecules (metabolites) and the enzymes
            (proteins) that interact with them to catalyze a biochemical reaction. Metabolic networks, metabolic control
            and modeling of metabolic networks in genome-wide reconstructed models is a central area in systems biology
        </p>


        <div class="row">
            <div class="col-auto">
                <h3>Select subcellular location:</h3>

                <select id="module_list" class="form-control select-input placeholder-active active">

                </select>

                <h3>Select subcellular location:</h3>

                <select id="molecules_list" class="form-control select-input placeholder-active active">

                </select>

                <a href="#" onclick="javascript:void(0);" id="pin">Pin Current Selection</a>

            </div>
        </div>

        <br /><br />

        <div class="row">
            <div class="col-12" id="container" style="height: 600px;">
                <!-- the graph canvas container -->
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                
                <h3>View Related Reactions:</h3>

                <select id="reaction_list" class="form-control select-input placeholder-active active">

                </select>

                <div class="row">
                    <div class="col-12" id="reaction-container" style="height: 600px;">
                        <!-- the graph canvas container -->
                    </div>
                </div>

            </div>
        </div>

        <%= ../../assets/includes/webapp.vbhtml %>

            <script src="/javascript/viewer.min.js" type="text/javascript"></script>
            <script src="/javascript/echarts-5.4.0/echarts.min.js" type="text/javascript"></script>
    </div>

</body>

</html>