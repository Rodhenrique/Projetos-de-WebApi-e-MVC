from flask_sqlalchemy import SQLAlchemy

db = SQLAlchemy()

def configure_db(app):
    db.init_app(app)
    app.db = db

class buyers(db.Model):
    id = db.Column(db.Integer, primary_key= True)
    created_at = db.Column(db.DateTime(timezone=True))
    updated_at = db.Column(db.DateTime(timezone=True))
    first_name = db.Column(db.String(50))
    last_name = db.Column(db.String(100))
    document = db.Column(db.String(50))
    email = db.Column(db.String(100))
    phone = db.Column(db.String(20))
    address = db.Column(db.Text)
    address_city_id = db.Column(db.Integer)

    def to_json(self):
        return {"id": self.id, "created_at": self.created_at, "updated_at": self.updated_at, "first_name": self.first_name,
        "last_name":self.last_name, "document": self.document, "email":self.email, "phone": self.phone, "address": self.address,
        "address_city_id": self.address_city_id}