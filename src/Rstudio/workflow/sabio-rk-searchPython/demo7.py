# ------------------------------------------------------------------------------

# Example SABIO-RK script 7 - returns compound id and compound synonym names

# ------------------------------------------------------------------------------

import requests

QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/searchCompoundSynonyms'


# input: SabioCompoundID or compound name (recommended name or synonymous name)
# valid output fields: "fields[]":["SabioCompoundID","Name","NameType"]

# example 1
query = {"SabioCompoundID":"36", "fields[]":["Name","NameType"]}

# example 2
# query = {"CompoundName":"Adenosine triphosphate", "fields[]":["SabioCompoundID","Name","NameType"]}

# example 3 - wildcard search returns all compounds
# query = {"SabioCompoundID":"*", "fields[]":["SabioCompoundID","Name","NameType"]}

request = requests.post(QUERY_URL, params = query)
request.raise_for_status()


# results

print(request.text)
