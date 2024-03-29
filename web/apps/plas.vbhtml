<!DOCTYPE html>
<html lang="en">

<?vb $title = "Computational Analysis Of Biochemical Systems" ?>
<?vb $app = "plas" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_run_plas" content="http://localhost:7452/analysis_apps/plas">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/Rplots/odes_line2d">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <h1>Computational Analysis Of Biochemical Systems</h1>

        <div class="row">
            <div class="col-md-8">
                <!-- Spied element -->
                <div data-mdb-spy="scroll" data-mdb-target="#scrollspy1" data-mdb-offset="0" class="scrollspy-example">
                    <section id="example-1">
                        <h3>Introduction</h3>

                        <div class="clearfix">
                            <img class="col-md-6 float-md-end mb-3 ms-md-3 hover-shadow hover-zoom"
                                src="/assets/images/106287.webp" style="width: 200px;">

                            <figure>

                                <p> A true understanding of genetic and metabolic function and design is facilitated
                                    by mathematical and computational methods for analyzing biochemical systems.
                                    This
                                    hands-on reference teaches biochemists and molecular biologists the use of
                                    modern
                                    computational methods for the analysis of complex biomedical systems requiring a
                                    modest
                                    mathematical background.</p>

                                <figcaption class="blockquote-footer">
                                    <cite title="Computational Analysis of Biochemical Systems">Computational Analysis
                                        of Biochemical Systems: A Practical Guide for Biochemists and
                                        Molecular Biologists</cite>
                                </figcaption>
                            </figure>

                            <p>
                                Ordinary differential requations (ODE) are the most frequently used tool for modeling
                                continuous-time nonlinear dynamical systems, used to describe responses of a dynamical
                                system to all possible inputs and initial conditions. Equations which do not have a
                                solution for some valid inputs and initial conditions do not define system’s behavior
                                completely, and, hence, are inappropriate for use in analysis and design.
                            </p>

                        </div>
                    </section>
                    <section id="example-2">
                        <h3>Set Parameters</h3>

                        <p>
                            You can try this <a href="#" id="loadDemo"><i class="fas fa-file-code"></i>&nbsp;demo
                                example</a> at here.
                        </p>

                        <section id="system_parameters">
                            <h3>System Parameters</h3>

                            <div class="row">
                                <div class="col-auto">
                                    <label for="time_final" class="form-label">Time Final:</label>
                                    <input id="time_final" class="form-control" type="text" value="60"></input>

                                    <label for="resolution" class="form-label">Resolution:</label>
                                    <input id="resolution" class="form-control" type="text" value="10000"></input>
                                </div>
                            </div>
                        </section>

                        <section id="odes_system">
                            <h3>ODEs System</h3>

                            <div class="row">
                                <div class="col-auto" id="equations">



                                </div>
                            </div>


                            <div class="row">
                                <div class="col-auto">
                                    <button class="btn btn-success" type="button" id="add_equation">Add Equation
                                    </button>
                                </div>
                            </div>

                        </section>
                        <section id="constants">
                            <h3>Constants</h3>


                            <div class="row">
                                <div class="col-auto" id="constant-list">



                                </div>
                            </div>


                            <div class="row">
                                <div class="col-auto">
                                    <button class="btn btn-success" type="button" id="add_constant">Add Constant
                                    </button>
                                </div>
                            </div>
                        </section>

                        <div class="row">
                            <div class="col-auto">
                                <p>
                                    Finally, click the <code>Run</code> button to run the simulator!
                                </p>

                                <button class="btn btn-info" type="button" id="run">Run
                                </button>
                            </div>
                        </div>

                    </section>
                    <section id="example-3">
                        <h3>Analysis Result</h3>

                        <p>
                            The data analysis result for the simulator output consist with two parts:
                            <br />
                        <ol>
                            <li>Rplot: interactive image plot for visualize your simulator outputs in line plots.</li>
                            <li>Data Table: the simulator time frame snapshots result matrix outputs</li>
                        </ol>
                        </p>

                        <section id="example-sub-A">
                            <h3>Rplot</h3>

                            <section class="pb-4">
                                <div class="bg-white border rounded-5">

                                    <section class="p-4 d-flex justify-content-center text-center w-100">
                                        <div class="lightbox" data-id="lightbox-bm48lj2vb" id="lightbox">
                                            <div class="row">
                                                <div class="col-auto">
                                                    <a href="/assets/images/empty.jpg" data-toggle="lightbox"
                                                        data-caption="2d/3d scatter plot" id="Rplot-box">
                                                        <img src="/assets/images/empty.jpg" alt="2d/3d scatter plot"
                                                            class="img-fluid w-100 my-lightbox-toggle"
                                                            style="max-width: 400px;" id="Rplot_js">
                                                    </a>
                                                </div>

                                            </div>
                                        </div>
                                    </section>

                                </div>
                            </section>

                        </section>
                        <section id="example-sub-B">
                            <h3>Data Table</h3>

                            <p>Only peeks of the top 10 rows of your simulator output result at here:</p>
                            <div class="row">
                                <div class="col-auto" id="plas-table">

                                </div>
                            </div>

                            <p class="note note-info">
                                <strong>Result table format:</strong><br />

                                The output table data contains data fields:
                                <br /><br />
                                a. The first column is the time point data that the simulator in current run.<br />
                                b. the other data fields is depends on the symbol names of your ODEs system variables
                                that you has configed.
                            </p>

                        </section>
                    </section>
                    <section id="example-4">
                        <h3>Reference</h3>

                        <ol>
                            <li>Voit, Eberhard O. Computational analysis of biochemical systems: a practical guide for
                                biochemists and molecular biologists. Cambridge University Press, 2000.</li>
                            <li>
                                W. Johnson, A Treatise on Ordinary and Partial Differential Equations, John Wiley and
                                Sons, 1913, in University of Michigan Historical Math Collection
                            </li>
                        </ol>
                    </section>
                    <section id="example-5">
                        <h3>Download</h3>

                        <p>Save your analysis result files.</p>

                        <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                            <button type="button" class="btn btn-info" id="save_project">
                                Save To Project
                            </button>

                            <div class="btn-group" role="group">
                                <button id="download-group" type="button" class="btn btn-primary dropdown-toggle"
                                    data-mdb-toggle="dropdown" aria-expanded="false">
                                    Download Report
                                </button>
                                <ul class="dropdown-menu" aria-labelledby="download-group">
                                    <li><a class="dropdown-item" href="#" id="download_zip">Download Zip Archive</a>
                                    </li>
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
                <div id="scrollspy1" class="sticky-top">
                    <ul class="nav flex-column nav-pills menu-sidebar">
                        <li class="nav-item">
                            <a class="nav-link" href="#example-1">Introduction</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-2">Set Parameters</a>

                            <ul class="nav flex-column ps-3">
                                <li class="nav-item">
                                    <a class="nav-link" href="#system_parameters">System Parameters</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#odes_system">ODEs System</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#constants">Constants</a>
                                </li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-3">Analysis Result</a>
                            <ul class="nav flex-column ps-3">
                                <li class="nav-item">
                                    <a class="nav-link" href="#example-sub-A">Rplot</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#example-sub-B">Data Table</a>
                                </li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-4">Reference</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-5">Download</a>
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