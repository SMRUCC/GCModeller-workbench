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

        <div class="row">
            <div class="col-md-8">
                <!-- Spied element -->
                <div data-mdb-spy="scroll" data-mdb-target="#scrollspy-collapsible" data-mdb-offset="0"
                    class="scrollspy-example">
                    <section id="example-1-collapsible">
                        <h3>Introduction</h3>

                        <p> An embedding is a low-dimensional representation of high-dimensional data. Typically, an
                            embedding won’t capture all information contained in the original data. A good embedding,
                            however, will capture enough to solve the problem at hand.</p>

                    </section>
                    <section id="example-2-collapsible">
                        <h3>Set Parameters</h3>
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
                    </section>
                    <section id="example-3-collapsible">
                        <h3>Analysis Result</h3>
                        ...
                        <section id="example-sub-A-collapsible">
                            <h3>Rplot</h3>
                            ...
                        </section>
                        <section id="example-sub-B-collapsible">
                            <h3>Data Table</h3>
                            ...
                        </section>
                    </section>
                    <section id="example-4-collapsible">
                        <h3>Download</h3>
                        ...
                    </section>
                </div>
                <!-- Spied element -->
            </div>

            <div class="col-md-4">
                <!-- Scrollspy -->
                <div id="scrollspy-collapsible" class="sticky-top">
                    <ul class="nav flex-column nav-pills menu-sidebar">
                        <li class="nav-item">
                            <a class="nav-link" href="#example-1-collapsible">Introduction</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-2-collapsible">Set Parameters</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link collapsible-scrollspy" href="#example-3-collapsible">Analysis Result</a>
                            <ul class="nav flex-column ps-3">
                                <li class="nav-item">
                                    <a class="nav-link" href="#example-sub-A-collapsible">Rplot</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#example-sub-B-collapsible">Data Table</a>
                                </li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-4-collapsible">Download</a>
                        </li>
                    </ul>
                </div>
                <!-- Scrollspy -->
            </div>
        </div>


        <%= ../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>