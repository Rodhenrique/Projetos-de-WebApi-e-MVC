from flask_sqlalchemy import SQLAlchemy

db = SQLAlchemy()

def configure(app):
    db.init_app(app)
    app.db = db

class address_cities(db.Model):
    id = db.Column(db.Integer, primary_key= True)
    name = db.Column(db.String(100))
    address_state_id = db.Column(db.Integer)

    def to_json(self):
        return {"id": self.id, "name": self.name, "address_state_id": self.address_state_id}
    