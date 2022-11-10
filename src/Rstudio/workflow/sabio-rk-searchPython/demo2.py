# ------------------------------------------------------------------------------

# Example SABIO-RK script 2
# This single-step method is especially recommended for large result sets (> 10000)

# ------------------------------------------------------------------------------

import requests

QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/kineticlawsExportTsv'


# specify search fields and search terms

query_dict = {"Organism":'"lactococcus lactis subsp. lactis bv. diacetylactis"', "Product":'"Tyrosine"'}
query_string = ' AND '.join(['%s:%s' % (k,v) for k,v in query_dict.items()])


# specify output fields and send request

query = {'fields[]':['EntryID', 'Organism', 'UniprotID','ECNumber', 'Parameter'], 'q':query_string}

request = requests.post(QUERY_URL, params = query)
request.raise_for_status()


# results

print(request.text)