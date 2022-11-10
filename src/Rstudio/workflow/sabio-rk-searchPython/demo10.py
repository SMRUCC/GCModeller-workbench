# ------------------------------------------------------------------------------

# Example SABIO-RK script 10 - returns entry data in SBML format

# ------------------------------------------------------------------------------

import requests

# specify SBML as output format
SBML_URL='http://sabiork.h-its.org/sabioRestWebServices/searchKineticLaws/sbml'

# input: search fields and search terms eg
query_dict = {"Organism":'"Haemophilus influenzae"',"ECNumber":"2.7.7.1"}
query_string = ' AND '.join(['%s:%s' % (k,v) for k,v in query_dict.items()])
query = {'q':query_string}

request = requests.post(SBML_URL, params = query)
request.raise_for_status()


# results

print(request.text)