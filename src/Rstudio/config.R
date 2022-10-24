[@info "A directory path that contains the configuration 
        file of the gcmodeller runtime."]
const gcmodeller_config as string = ?"--config" || stop("A valid configuration dir must be provided!");

# set configs dir
options(gcmodeller.config = gcmodeller_config);
# save configuration data to file
options_flush();