<!DOCTYPE html>
<html lang="en">

<?vb $title = "Virtual Cell Project" ?>
<?vb $app = "bioproject" ?>

<head>
    <%= ../../../assets/includes/head.vbhtml %>

        <meta name="web_invoke_load" content="http://localhost:7452/modeller/load_project">

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
            <div class="col-auto">
                <h2>Project Task</h2>

                <ul>
                    <li><a href="#" onclick="">Enzyme Annotations</a></li>
                </ul>
            </div>
        </div>


        <%= ../../../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>