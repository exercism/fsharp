~ "rest-api.ua" ~ RestApi

# No users
database = """{"users":[]}"""
url = "/users"
expected = """{"users":[]}"""
api = RestApi(database)
⍤⤙≍ expected api.Get url

# Add user
database = """{"users":[]}"""
payload = """{"user":"Adam"}"""
url = "/add"
expected = """{"name":"Adam","owes":{},"owed_by":{},"balance":0.0}"""
api = RestApi(database)
⍤⤙≍ expected api.Post url_payload

# Get single user
database = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0}]}"""
payload = """{"users":["Bob"]}"""
url = "/users"
expected = """{"users":[{"name":"Bob","owes":{},"owed_by":{},"balance":0.0}]}"""
api = RestApi(database)
⍤⤙≍ expected api.Get url_payload

# Both users have 0 balance
database = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0}]}"""
payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
url = "/iou"
expected = """{"users":[{"name":"Adam","owes":{},"owed_by":{"Bob":3.0},"balance":3.0},{"name":"Bob","owes":{"Adam":3.0},"owed_by":{},"balance":-3.0}]}"""
api = RestApi(database)
⍤⤙≍ expected api.Post url_payload

# Borrower has negative balance
database = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{},"balance":-3.0},{"name":"Chuck","owes":{},"owed_by":{"Bob":3.0},"balance":3.0}]}"""
payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
url = "/iou"
expected = """{"users":[{"name":"Adam","owes":{},"owed_by":{"Bob":3.0},"balance":3.0},{"name":"Bob","owes":{"Adam":3.0,"Chuck":3.0},"owed_by":{},"balance":-6.0}]}"""
api = RestApi(database)
⍤⤙≍ expected api.Post url_payload

# Lender has negative balance
database = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{},"balance":-3.0},{"name":"Chuck","owes":{},"owed_by":{"Bob":3.0},"balance":3.0}]}"""
payload = """{"lender":"Bob","borrower":"Adam","amount":3.0}"""
url = "/iou"
expected = """{"users":[{"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{"Adam":3.0},"balance":0.0}]}"""
api = RestApi(database)
⍤⤙≍ expected api.Post url_payload

# Lender owes borrower
database = """{"users":[{"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0}]}"""
payload = """{"lender":"Adam","borrower":"Bob","amount":2.0}"""
url = "/iou"
expected = """{"users":[{"name":"Adam","owes":{"Bob":1.0},"owed_by":{},"balance":-1.0},{"name":"Bob","owes":{},"owed_by":{"Adam":1.0},"balance":1.0}]}"""
api = RestApi(database)
⍤⤙≍ expected api.Post url_payload

# Lender owes borrower less than new loan
database = """{"users":[{"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0}]}"""
payload = """{"lender":"Adam","borrower":"Bob","amount":4.0}"""
url = "/iou"
expected = """{"users":[{"name":"Adam","owes":{},"owed_by":{"Bob":1.0},"balance":1.0},{"name":"Bob","owes":{"Adam":1.0},"owed_by":{},"balance":-1.0}]}"""
api = RestApi(database)
⍤⤙≍ expected api.Post url_payload

# Lender owes borrower same as new loan
database = """{"users":[{"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0}]}"""
payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
url = "/iou"
expected = """{"users":[{"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0}]}"""
api = RestApi(database)
⍤⤙≍ expected api.Post url_payload

