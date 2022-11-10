# ------------------------------------------------------------------------------

# Example SABIO-RK script 6 - returns reaction modifier details

# ------------------------------------------------------------------------------

import requests

QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/searchReactionModifiers'


# input: SabioReactionID
# valid output fields: "fields[]":["EntryID","Name","Role","SabioCompoundID","ChebiID","PubChemID","KeggCompoundID","InChI","Smiles"]

# example
query = {"SabioReactionID":"128", "fields[]":["EntryID","Name","Role"]}

# note that you can also retrieve the data for ALL reaction modifiers by performing a wildcard search
# for this wildcard query, the output field 'SabioReactionID' is added by default
# query = {"SabioReactionID":"*", "fields[]":["EntryID","Name","Role"]}

request = requests.get(QUERY_URL, params = query)
request.raise_for_status()

# results
print(request.text)