Toxic Comment Classification

This project classifies comments as Toxic or Non-Toxic using Logistic Regression and SVM (SVC) with TF-IDF vectorization. It also provides a FastAPI backend for integration with web applications (e.g., Angular) and a Streamlit UI for testing comments interactively.

🗂 Project Structure
toxic-comment-classification/
│
├─ data/
│   ├─ train.csv
│   └─ validation.csv
│
├─ models/
│   ├─ tfidf_logreg.pkl
│   └─ tfidf_vectorizer.pkl
│
├─ src/
│   ├─ api/
│   │   └─ app.py          # FastAPI backend
│   ├─ models/
│   │   └─ train_baselines.py
│   ├─ data_utils.py       # CSV loader + preprocessing
│   ├─ features.py         # TF-IDF builder
│   └─ app_streamlit.py    # Streamlit UI
│
├─ venv/                   # Python virtual environment
├─ package.json / angular   # Angular frontend (optional)
└─ README.md

⚡ Setup

Clone the repository

git clone <repo_url>
cd toxic-comment-classification


Create virtual environment and activate

python -m venv venv
# Windows
venv\Scripts\activate
# Mac/Linux
source venv/bin/activate


Install Python dependencies

pip install -r requirements.txt


Dependencies include:

scikit-learn

pandas

joblib

fastapi

uvicorn

streamlit

pydantic

nltk

Download NLTK stopwords

import nltk
nltk.download('stopwords')

🏋️ Training the Models

Run the training script to train Logistic Regression and SVC models and save them in the models/ folder.

python -m src.models.train_baselines


✅ Output:

Validation report (LogReg):
accuracy: 0.93 ...
✅ Model and vectorizer saved successfully in 'models' folder.
Validation report (SVC):
accuracy: 0.93 ...
✅ SVC model saved successfully.


This will generate:

models/tfidf_logreg.pkl

models/tfidf_vectorizer.pkl

models/tfidf_svc.pkl

🖥 Streamlit UI

Launch the interactive web UI:

streamlit run src/app_streamlit.py


Open browser at:

http://localhost:8501


Enter a comment in the textbox.

Click Analyze Comment.

See Toxic / Non-Toxic prediction with confidence.

🌐 FastAPI Backend

Start the API server:

uvicorn src.api.app:app --reload


Open browser at:

http://127.0.0.1:8000/


GET / → check if API is running:

{"message": "✅ Toxic Comment Classifier API is running!"}


POST /predict → classify a comment:

Request (JSON)

{
  "text": "You are such a loser!"
}


Response

{
  "text": "You are such a loser!",
  "is_toxic": true,
  "confidence": 0.858
}
