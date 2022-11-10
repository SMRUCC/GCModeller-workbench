# ------------------------------------------------------------------------------

# Example SABIO-RK script 5 - returns reaction participant details

# ------------------------------------------------------------------------------

import requests

QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/searchReactionParticipants'


# input: SabioReactionID
# valid output fields: "fields[]":["Name","Role","SabioCompoundID","ChebiID","PubChemID","KeggCompoundID", "InChI","Smiles"]

# example
query = {"SabioReactionID":"128", "fields[]":["Name","Role"]}

# note that you can also retrieve the data for ALL reaction participants by performing a wildcard search
# for this wildcard query, the output field 'SabioReactionID' is added by default
# query = {"SabioReactionID":"*", "fields[]":["SabioCompoundID","Name","Role"]}

request = requests.get(QUERY_URL, params = query)
request.raise_for_status()

# results
print(request.text)