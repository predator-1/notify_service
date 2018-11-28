<template>
  <div>
    <b-form @submit="send">
      <b-form-group label="Subject" label-for="Subject">
        <b-form-input
          id="Subject"
          type="text"
          v-model="form.subject"
          required
          placeholder="Enter subject"
        ></b-form-input>
      </b-form-group>
      <b-form-group label="Body" label-for="Body">
        <b-form-textarea
          id="Body"
          type="text"
          v-model="form.body"
          required
          placeholder="Enter body"
        ></b-form-textarea>
      </b-form-group>
      <b-form-group label="Recipients" label-for="recipients">
        <b-form-select
          id="recipients"
          multiple
          :select-size="4"
          v-model="form.recipients"
          :options="options"
          class="mb-3"
        ></b-form-select>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>
    <b-table striped hover :items="messages"></b-table>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import ApiService from "../servises/apiService";
import { IMessage } from "../models/message";

interface IDataModel {
  messages: {
    subject: string;
    body: string;
    recipients: string;
    isSent: boolean;
  }[];
  apiService: ApiService;
  error: string;
  loading: boolean;
  form: IMessage;
  options: { value: string; text: string }[];
}

export default Vue.extend({
  data(): IDataModel {
    return {
      messages: [],
      apiService: new ApiService(),
      error: "",
      loading: true,
      options: [
        { value: "WebApp", text: "WebApp" },
        { value: "IOS", text: "IOS" },
        { value: "Android", text: "Android" },
        { value: "Teapot", text: "Teapot" }
      ],
      form: {
        body: "",
        subject: "",
        recipients: ["WebApp", "IOS", "Android", "Teapot"]
      }
    };
  },
  mounted: function() {
    this.getAll();
  },
  methods: {
    async getAll() {
      this.loading = true;
      let resp = await this.apiService.getAllMessages();
      if (resp.isSuccess && resp.data && resp.data.length) {
        this.messages = resp.data.map(item => {
          return {
            subject: item.subject,
            body: item.body,
            recipients: item.recipients.join(","),
            isSent: item.isSent || false
          };
        });
      } else {
        this.error = resp.error || "";
      }
      this.loading = false;
    },
    async send(evt: any) {
      evt.preventDefault();
      this.loading = true;
      let resp = await this.apiService.sendMessage(this.form);
      if (resp.isSuccess && resp.data) {
        this.messages.unshift({
          subject: resp.data.subject,
          body: resp.data.body,
          recipients: resp.data.recipients.join(","),
          isSent: resp.data.isSent || false
        });
      } else {
        this.error = resp.error || "";
      }
      this.form.body = "";
      this.form.subject = "";
      this.loading = false;
    }
  }
});
</script>

<style>

</style>