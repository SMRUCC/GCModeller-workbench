<!DOCTYPE html>
<html lang="en">

<?vb $title = "Data Embedding" ?>
<?vb $app = "dataEmbedding" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_enrichment" content="http://localhost:7452/analysis_apps/enrichment">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/enrichment_plot">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <!-- Tabs navs -->
        <ul class="nav nav-tabs mb-3" id="ex-with-icons" role="tablist">
            <li class="nav-item" role="presentation">
                <a class="nav-link active" id="ex-with-icons-tab-1" data-mdb-toggle="tab" href="#ex-with-icons-tabs-1"
                    role="tab" aria-controls="ex-with-icons-tabs-1" aria-selected="true"><i
                        class="fas fa-chart-pie fa-fw me-2"></i>Configurations</a>
            </li>
            <li class="nav-item" role="presentation">
                <a class="nav-link" id="ex-with-icons-tab-2" data-mdb-toggle="tab" href="#ex-with-icons-tabs-2"
                    role="tab" aria-controls="ex-with-icons-tabs-2" aria-selected="false">
                    <i class="fas fa-cogs fa-fw me-2"></i>
                    Analysis
                    Result
                </a>
            </li>
        </ul>
        <!-- Tabs navs -->

        <!-- Tabs content -->
        <div class="tab-content" id="ex-with-icons-content">
            <div class="tab-pane fade show active" id="ex-with-icons-tabs-1" role="tabpanel"
                aria-labelledby="ex-with-icons-tab-1">

                <!-- Parameter content and data files at here -->
                <div class="row">
                    <div class="col-auto">
                        <label for="dimensions" class="form-label">Dimensions:</label>
                        <input type="text" class="form-control" id="dimensions" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <label for="matrix-file" class="form-label">Select Matrix:</label>
                        <div class="input-group mb-3">
                            <button class="btn btn-primary" type="button" id="button_open"
                                data-mdb-ripple-color="dark">
                                <i class="far fa-folder-open"></i> Select File
                            </button>
                            <input type="text" class="form-control" placeholder="" id="matrix-file"
                                aria-label="Example text with button addon" aria-describedby="button-addon1" />
                        </div>
                    </div>
                </div>

                <br />
                <div class="row">
                    <div class="col-auto">
                        <button id="run" type="submit" class="btn btn-primary mb-3">Run</button>
                    </div>
                </div>

            </div>
            <div class="tab-pane fade" id="ex-with-icons-tabs-2" role="tabpanel" aria-labelledby="ex-with-icons-tab-2">


                <!-- Show data analysis result at here -->

            </div>

        </div>
        <!-- Tabs content -->

        <%= ../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>