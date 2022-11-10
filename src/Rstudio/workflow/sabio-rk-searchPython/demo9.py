# ------------------------------------------------------------------------------

# Example SABIO-RK script 9 - returns recommended and synonym names of pathways

# ------------------------------------------------------------------------------

import requests

QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/searchPathwaySynonyms'


# input: KEGG pathway id or pathway name (recommended name or synonymous name)
# valid output fields: "fields[]":["KeggPathwayID","Name","NameType"]

# example 1
query = {"KeggPathwayID":"00010", "fields[]":["Name","NameType"]}

# example 2
# query = {"PathwayName":"Glycolysis/Gluconeogenesis", "fields[]":["KeggPathwayID","Name","NameType"]}

# example 3 - wildcard search returns ALL pathway data
# query = {"PathwayName":"*", "fields[]":["KeggPathwayID","Name","NameType"]}

request = requests.post(QUERY_URL, params = query)
request.raise_for_status()


# results

print(request.text)