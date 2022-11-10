# ------------------------------------------------------------------------------

# Example SABIO-RK script 1

# ------------------------------------------------------------------------------

import requests

ENTRYID_QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/searchKineticLaws/entryIDs'
PARAM_QUERY_URL = 'http://sabiork.h-its.org/entry/exportToExcelCustomizable'
entryIDs = []


# ask SABIO-RK for all EntryIDs matching a query

query_dict = {"Organism":'"Homo sapiens"',"ECNumber":"1.1.1.1"}
query_string = ' AND '.join(['%s:%s' % (k,v) for k,v in query_dict.items()])
query = {'format':'txt', 'q':query_string}


# make GET request

request = requests.get(ENTRYID_QUERY_URL, params = query)
request.raise_for_status() # raise if 404 error


# each entry is reported on a new line

entryIDs = [int(x) for x in request.text.strip().split('\n')]
print('%d matching entries found.' % len(entryIDs))


# encode next request, for parameter data given entry IDs

data_field = {'entryIDs[]': entryIDs}
query = {'format':'tsv', 'fields[]':['EntryID', 'Organism', 'UniprotID','ECNumber', 'Parameter','ReactomeReactionID']}


# make POST request

request = requests.post(PARAM_QUERY_URL, params=query, data=data_field)
request.raise_for_status()


# results

print(request.text)