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

                                <p>
                                    The matrix file format should be:<br />

                                <ol>
                                    <li>Each row data is the data entity list</li>
                                    <li>Each column data is the feature data vector of the data entity in rows.</li>
                                </ol>

                                For omics data that could be:<br />
                                <ol>
                                    <li>
                                        Each row data should be the samples.
                                    </li>
                                    <li>
                                        Each column data should be the gene features
                                    </li>
                                </ol>
                                </p>

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

                        <p>
                            The data analysis result for data embedding analysis consist with two parts:
                            <br />
                        <ol>
                            <li>Rplot: interactive image plot for visualize your data result in 2D/3D view.</li>
                            <li>Data Table: the data embedding result matrix outputs</li>
                        </ol>
                        </p>

                        <section id="example-sub-A-collapsible">
                            <h3>Rplot</h3>

                            <div class="row">
                                <div class="col-auto"></div>
                            </div>

                        </section>
                        <section id="example-sub-B-collapsible">
                            <h3>Data Table</h3>

                            <div class="row">
                                <div class="col-auto"></div>
                            </div>

                        </section>
                    </section>
                    <section id="example-4-collapsible">
                        <h3>Download</h3>

                        <p>Save your analysis result files.</p>

                        <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                            <button type="button" class="btn btn-primary">
                                Save To Project
                            </button>

                            <div class="btn-group" role="group">
                                <button id="btnGroupDrop1" type="button" class="btn btn-primary dropdown-toggle"
                                    data-mdb-toggle="dropdown" aria-expanded="false">
                                    Download Report
                                </button>
                                <ul class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                                    <li><a class="dropdown-item" href="#">Download Zip Archive</a></li>
                                    <li><a class="dropdown-item" href="#">Print As PDF</a></li>
                                </ul>
                            </div>
                        </div>
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