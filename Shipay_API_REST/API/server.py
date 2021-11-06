from flask import Flask
import urllib
from Controllers.addressStateController import addressStates
from Controllers.addressCityController import addressCities
from Controllers.buyerController import buyersRoute
from Models.addressCities import configure 
from Models.addressState import configure_db
from Models.buyersModel import configure_db as configiure_ma


app = Flask(__name__)
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = True
params = urllib.parse.quote_plus('DRIVER={SQL Server};SERVER=localhost,1433;DATABASE=Shipay;Trusted_Connection=yes;')
app.config['SQLALCHEMY_DATABASE_URI'] = "mssql+pyodbc:///?odbc_connect=%s" % params

configure(app)
configiure_ma(app)
configure_db(app)

app.register_blueprint(addressStates)
app.register_blueprint(addressCities)
app.register_blueprint(buyersRoute)

app.run()
