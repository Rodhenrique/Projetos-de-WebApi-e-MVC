from flask_sqlalchemy import SQLAlchemy

db = SQLAlchemy()

def configure_db(app):
    db.init_app(app)
    app.db = db

class address_states(db.Model):
    id = db.Column(db.Integer, primary_key= True)
    name = db.Column(db.String(100))
    uf = db.Column(db.String(100))

    def to_json(self):
        return {"id": self.id, "name": self.name, "uf": self.uf}