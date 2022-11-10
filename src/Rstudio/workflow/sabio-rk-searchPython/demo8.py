# ------------------------------------------------------------------------------

# Example SABIO-RK script 8 - returns EC number and enzyme synonym names

# ------------------------------------------------------------------------------

import requests

QUERY_URL = 'http://sabiork.h-its.org/sabioRestWebServices/searchEnzymeSynonyms'


# input: EC number or enzyme name (recommended name or synonymous name)
# valid output fields: "fields[]":["ECNumber","Name","NameType"]

# example 1
query = {"ECNumber":"5.1.99.6", "fields[]":["Name","NameType"]}

# example 2
# query = {"EnzymeName":"isocitrate dehydrogenase (NAD+)", "fields[]":["ECNumber","Name","NameType"]}

# example 3 - wildcard search returns ALL EC numbers, enzyme names and their synomymous names
# query = {"ECNumber":"*", "fields[]":["ECNumber","Name","NameType"]}

request = requests.post(QUERY_URL, params = query)
request.raise_for_status()


# results

print(request.text)
