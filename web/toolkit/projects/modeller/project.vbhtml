<!DOCTYPE html>
<html lang="en">

<?vb $title = "Virtual Cell Project" ?>
<?vb $app = "bioproject" ?>

<head>
    <%= ../../../assets/includes/head.vbhtml %>

        <meta name="web_invoke_load" content="http://localhost:7452/modeller/load_project">
        <meta name="web_invoke_extract_proteins" content="http://localhost:7452/modeller/extract_proteins">
        <meta name="web_invoke_inspect_model" content="http://localhost:7452/modeller/load_summary">

</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <div class="row">
            <div class="col-auto">
                <h1>Virtual Cell Model</h1>

                <p>
                    local file: <code><pre id="path"></pre></code>
                </p>

            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <div id="summary_pie" style="width: 450px;height:400px;">
                </div>
            </div>
            <div class="col-4">
                <div id="summary_enzyme_pie" style="width: 450px;height:400px;">
                </div>
            </div>
            <div class="col-4">
                <div id="summary_location_pie" style="width: 450px;height:400px;">
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-auto">
                <ul>
                    <li><a href="#" onclick="apps.gcmodeller.openEnzymeBlastViewer();">View Enzyme Annotation</a></li>
                    <li><a href="#" onclick="apps.gcmodeller.openSubcellularBlastViewer();">View Subcellular Location Annotation</a></li>
                </ul>
            </div>
        </div>

        <div class="row">
            <div class="col-auto">
                <h2>Project Task</h2>

                <ul>
                    <!-- open blast page and then setup parameters 
                        for project file -->
                    <li><a id="enzyme_anno" href="#" onclick="javascript:void(0);">Enzyme Annotations</a></li>
                    <li><a id="subcellular_anno" href="#" onclick="javascript:void(0);">Subcellular Location
                            Annotations</a></li>
                </ul>
            </div>
        </div>


        <%= ../../../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->

    <script src="/javascript/echarts-5.4.0/echarts.min.js"></script>

</body>

</html>