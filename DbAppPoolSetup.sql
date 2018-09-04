use Examples
go

drop login [IIS AppPool\Pricing]
go

create login [IIS AppPool\Pricing]
from windows
with default_database = [Examples]
go

create user [IIS AppPool\Pricing] for login [IIS AppPool\Pricing] with default_schema = [RPC]
go