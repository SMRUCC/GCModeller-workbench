# ------------------------------------------------------------------------------

# Example SABIO-RK script 3 - returns compound details

# ------------------------------------------------------------------------------

import requests

QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/searchCompoundDetails'


# input: SabioCompoundID
# valid output fields: "fields[]":["Name","ChebiID","PubChemID","InChI","SabioCompoundID","KeggCompoundID","Smiles"]

# example
query = {"SabioCompoundID":"36", "fields[]":["Name","ChebiID","PubChemID"]}

request = requests.post(QUERY_URL, params = query)
request.raise_for_status()


# results

print(request.text)

# note that you can also retrieve the data for ALL compounds by performing a wildcard search
# eg: query = {"SabioCompoundID":"*", "fields[]":["SabioCompoundID","Name","PubChemID"]}
