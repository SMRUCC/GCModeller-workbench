<!DOCTYPE html>
<html lang="en">

<?vb $title = "Just a template page" ?>
<?vb $app = "app_name" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_enrichment" content="http://localhost:7452/analysis_apps/enrichment">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/enrichment_plot">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

      

        

        <%= ../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>