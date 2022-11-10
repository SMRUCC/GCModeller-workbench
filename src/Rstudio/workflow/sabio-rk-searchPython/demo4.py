# ------------------------------------------------------------------------------

# Example SABIO-RK script 4 - returns reaction details

# ------------------------------------------------------------------------------

import requests

QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/searchReactionDetails'

# input: SabioReactionID
#valid output fields: "fields[]":["KeggReactionID","SabioReactionID","Enzymename","ECNumber", "UniProtKB_AC","ReactionEquation","TransportReaction"]

#example
query = {"SabioReactionID":"128", "fields[]":["KeggReactionID","ReactionEquation"]}

# make GET request
request = requests.get(QUERY_URL, params = query)
request.raise_for_status()

# results
print(request.text)

# note that you can also retrieve the data for ALL reactions by performing a wildcard search
# eg: query = {"SabioReactionID":"*", "fields[]":["SabioReactionID","KeggReactionID"]}
