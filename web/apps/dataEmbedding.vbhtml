<!DOCTYPE html>
<html lang="en">

<?vb $title = "Data Embedding" ?>
<?vb $app = "dataEmbedding" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_embedding" content="http://localhost:7452/analysis_apps/dataEmbedding">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/Rplots/scatter3d">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <h1>Data Embedding Analysis</h1>

        <div class="row">
            <div class="col-md-8">
                <!-- Spied element -->
                <div data-mdb-spy="scroll" data-mdb-target="#scrollspy-collapsible" data-mdb-offset="0"
                    class="scrollspy-example">
                    <section id="example-1-collapsible">
                        <h3>Introduction</h3>

                        <div class="clearfix">
                            <img class="col-md-6 float-md-end mb-3 ms-md-3 hover-shadow hover-zoom"
                                src="/assets/images/gallery/UMAP3d.png" style="width: 300px;">

                            <p> An embedding is a low-dimensional representation of high-dimensional data. Typically, an
                                embedding won’t capture all information contained in the original data. A good
                                embedding,
                                however, will capture enough to solve the problem at hand.</p>

                            <p>
                                All embeddings attempt to reduce the dimensionality of data while preserving “essential”
                                information in the data, but every embedding does it in its own way. Here, we will go
                                through a few popular embeddings that can be applied to a omics expression data matrix,
                                distance or similarity matrix.
                            </p>
                        </div>

                    </section>
                    <section id="example-2-collapsible">
                        <h3>Set Parameters</h3>
                        <!-- Parameter content and data files at here -->
                        <div class="row">
                            <div class="col-auto">
                                <p>
                                    Set the result dimensions of the data embedding output, this value should be smaller
                                    than the columns feature numbers of your input data matrix. recommended at least
                                    result 3 dimensions of your data embedding analysis:
                                </p>
                                <div class="row">
                                    <div class="col-4">
                                        <label for="dimensions" class="form-label">Dimensions:</label>
                                        <input type="text" class="form-control" id="dimensions" value="3" />
                                    </div>
                                </div>
                                <br />
                                <p class="note note-info">
                                    <strong>Note:</strong> This parameter may affects the result data plot of
                                    your data embedding matrix output: for set parameter to 2 dimension, then
                                    analysis script just output a 2d scatter plot, and the 3d scatter plot is
                                    visualized for the data result with at least 3 dimensions.
                                </p>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-auto">

                                <p>Algorithm method to used:</p>

                                <select id="algorithm" class="form-select select-input placeholder-active">
                                    <option value="PCA">PCA</option>
                                    <optgroup label="Nonlinear dimensionality reduction">
                                        <option value="t-SNE">t-SNE</option>
                                        <option value="UMAP" selected>UMAP</option>
                                    </optgroup>
                                </select>

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
                                <div class="col-auto">

                                    <!-- Prepare a DOM with a defined width and height for ECharts -->
                                    <div id="Rplot_js" style="width: 600px;height:400px;">

                                    </div>

                                </div>
                            </div>

                        </section>
                        <section id="example-sub-B-collapsible">
                            <h3>Data Table</h3>
                            <p>Only peeks of the top 10 rows of your data embedding result at here:</p>
                            <div class="row">
                                <div class="col-auto" id="embedding-table">

                                </div>
                            </div>

                        </section>
                    </section>
                    <section id="example-5-collapsible">
                        <h3>Reference</h3>

                        <ol>
                            <li>
                                McInnes, L, Healy, J, UMAP: Uniform Manifold Approximation and Projection for Dimension
                                Reduction, ArXiv e-prints 1802.03426, 2018
                            </li>
                            <li>
                                L.J.P. van der Maaten and G.E. Hinton. Visualizing High-Dimensional Data Using t-SNE.
                                Journal of Machine Learning Research 9(Nov):2579-2605, 2008.
                            </li>
                            <li>
                                Jolliffe, I. T. (1986). Principal Component Analysis. Springer Series in Statistics.
                                Springer-Verlag. pp. 487. CiteSeerX 10.1.1.149.8828. doi:10.1007/b98835. ISBN
                                978-0-387-95442-4.
                            </li>
                        </ol>
                    </section>
                    <section id="example-4-collapsible">
                        <h3>Download</h3>

                        <p>Save your analysis result files.</p>

                        <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                            <button type="button" class="btn btn-info">
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
                            <a class="nav-link" href="#example-5-collapsible">Reference</a>
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

    <script type="text/javascript" src="https://fastly.jsdelivr.net/npm/jquery"></script>
    <script type="text/javascript" src="/javascript/echarts-5.4.0/echarts.min.js"></script>

    <!-- End your project here-->
</body>

</html>